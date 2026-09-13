using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class ReservationEditForm : Form
    {
        private readonly int? _reservationId;

        public ReservationEditForm(int? reservationId = null)
        {
            InitializeComponent();
            _reservationId = reservationId;
            LoadGuests();
            LoadRoomTypes();
            LoadRooms();

            if (_reservationId.HasValue)
            {
                LoadReservation(_reservationId.Value);
            }
            else
            {
                cmbStatus.SelectedItem = "Confirmed";
                dtpCheckIn.Value = DateTime.Today;
                dtpCheckOut.Value = DateTime.Today.AddDays(1);
            }
        }

        private void LoadGuests()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT GuestId, FullName + ' (' + ISNULL(Phone,'') + ')' AS DisplayName FROM Guests ORDER BY FullName";
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    cmbGuest.DisplayMember = "DisplayName";
                    cmbGuest.ValueMember = "GuestId";
                    cmbGuest.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load guests", ex);
                MessageBox.Show("Failed to load guests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoomTypes()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT RoomTypeId, TypeName FROM RoomTypes ORDER BY TypeName";
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    var dr = dt.NewRow();
                    dr["RoomTypeId"] = 0;
                    dr["TypeName"] = "All";
                    dt.Rows.InsertAt(dr, 0);

                    cmbRoomType.DisplayMember = "TypeName";
                    cmbRoomType.ValueMember = "RoomTypeId";
                    cmbRoomType.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load room types", ex);
                MessageBox.Show("Failed to load room types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    if (cmbRoomType != null && cmbRoomType.SelectedValue != null && int.TryParse(cmbRoomType.SelectedValue.ToString(), out int rt) && rt > 0)
                    {
                        cmd.CommandText = "SELECT RoomId, 'Room ' + RoomNumber + ' (' + ISNULL(Status,'Available') + ')' AS DisplayRoom FROM Rooms WHERE (Status IS NULL OR Status NOT IN ('Maintenance')) AND RoomTypeId = @rt ORDER BY RoomNumber";
                        cmd.Parameters.AddWithValue("@rt", rt);
                    }
                    else
                    {
                        cmd.CommandText = "SELECT RoomId, 'Room ' + RoomNumber + ' (' + ISNULL(Status,'Available') + ')' AS DisplayRoom FROM Rooms WHERE (Status IS NULL OR Status NOT IN ('Maintenance')) ORDER BY RoomNumber";
                    }
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    cmbRoom.DisplayMember = "DisplayRoom";
                    cmbRoom.ValueMember = "RoomId";
                    cmbRoom.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load rooms", ex);
                MessageBox.Show("Failed to load rooms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRooms();
            }
            catch { }
        }

        private void LoadReservation(int id)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT GuestId, RoomId, CheckInDate, ExpectedCheckOutDate, NumberOfGuests, Status, SpecialRequest FROM Reservations WHERE ReservationId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) return;
                    var r = dt.Rows[0];
                    cmbGuest.SelectedValue = Convert.ToInt32(r["GuestId"]);

                    var roomId = Convert.ToInt32(r["RoomId"]);
                    using (var cmd2 = conn.CreateCommand())
                    {
                        cmd2.CommandText = "SELECT ISNULL(RoomTypeId,0) AS RoomTypeId FROM Rooms WHERE RoomId = @rid";
                        cmd2.Parameters.AddWithValue("@rid", roomId);
                        if (conn.State != ConnectionState.Open)
                            DatabaseConnection.OpenWithRetry(conn);
                        var val = cmd2.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            try { cmbRoomType.SelectedValue = Convert.ToInt32(val); } catch { }
                        }
                    }

                    LoadRooms();
                    try { cmbRoom.SelectedValue = roomId; } catch { }

                    dtpCheckIn.Value = Convert.ToDateTime(r["CheckInDate"]);
                    dtpCheckOut.Value = Convert.ToDateTime(r["ExpectedCheckOutDate"]);
                    nudGuests.Value = Convert.ToDecimal(r["NumberOfGuests"]);

                    var st = r["Status"].ToString();
                    if (cmbStatus.Items.Contains(st))
                        cmbStatus.SelectedItem = st;
                    else
                        cmbStatus.SelectedIndex = 0;

                    txtNotes.Text = r["SpecialRequest"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load reservation", ex);
                MessageBox.Show("Failed to load reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbGuest.SelectedValue == null || cmbRoom.SelectedValue == null)
            {
                MessageBox.Show("Guest and Room must be selected.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var roomId = Convert.ToInt32(cmbRoom.SelectedValue);

                // Availability check: ensure no overlapping active reservation on the same room (ignoring current reservation)
                var conflictSql = @"SELECT COUNT(1) FROM Reservations 
                                   WHERE RoomId = @rid 
                                     AND Status IN ('Pending','Confirmed','CheckedIn','Booked') 
                                     AND NOT (ExpectedCheckOutDate <= @ci OR CheckInDate >= @co)";
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@rid", roomId),
                    new SqlParameter("@ci", dtpCheckIn.Value.Date),
                    new SqlParameter("@co", dtpCheckOut.Value.Date)
                };

                if (_reservationId.HasValue)
                {
                    conflictSql += " AND ReservationId <> @resId";
                    pList.Add(new SqlParameter("@resId", _reservationId.Value));
                }

                var conflictCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(conflictSql, pList.ToArray()));
                if (conflictCount > 0)
                {
                    MessageBox.Show("Selected room is not available for the chosen dates.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var svc = new Hotel_Management_System.Services.ReservationService();
                var guestId = Convert.ToInt32(cmbGuest.SelectedValue);
                var checkIn = dtpCheckIn.Value.Date;
                var checkOut = dtpCheckOut.Value.Date;
                var numGuests = (int)nudGuests.Value;
                var status = cmbStatus.SelectedItem?.ToString() ?? "Confirmed";
                var notes = txtNotes.Text.Trim();
                var createdBy = SessionManager.CurrentUser?.UserId;

                if (_reservationId.HasValue)
                {
                    svc.Update(_reservationId.Value, guestId, roomId, checkIn, checkOut, numGuests, status, notes);
                    MessageBox.Show("Reservation updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    svc.Create(guestId, roomId, checkIn, checkOut, numGuests, status, notes, createdBy);
                    MessageBox.Show("Reservation created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to save reservation", ex);
                MessageBox.Show("Failed to save reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
