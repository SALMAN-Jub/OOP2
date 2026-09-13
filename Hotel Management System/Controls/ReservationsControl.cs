using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Forms;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Controls
{
    public partial class ReservationsControl : UserControl
    {
        public ReservationsControl()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData(string filter = null)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT r.ReservationId, g.FullName AS Guest, g.Phone, rm.RoomNumber AS Room, rt.TypeName AS RoomType,
                                               r.CheckInDate, r.ExpectedCheckOutDate, r.NumberOfGuests, r.Status, r.BookingDate
                                        FROM Reservations r
                                        JOIN Guests g ON r.GuestId = g.GuestId
                                        JOIN Rooms rm ON r.RoomId = rm.RoomId
                                        JOIN RoomTypes rt ON rm.RoomTypeId = rt.RoomTypeId";

                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        cmd.CommandText += " WHERE g.FullName LIKE @f OR rm.RoomNumber LIKE @f OR r.Status LIKE @f OR CAST(r.ReservationId AS NVARCHAR(50)) LIKE @f";
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");
                    }

                    cmd.CommandText += " ORDER BY r.ReservationId DESC";

                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvReservations.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load reservations", ex);
                MessageBox.Show("Failed to load reservations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedReservationId()
        {
            if (dgvReservations.CurrentRow == null) return null;
            if (dgvReservations.CurrentRow.Cells["ReservationId"].Value == null) return null;
            return Convert.ToInt32(dgvReservations.CurrentRow.Cells["ReservationId"].Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new ReservationEditForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedReservationId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a reservation first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new ReservationEditForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedReservationId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a reservation first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show("Delete selected reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            try
            {
                // Check if related records exist
                var hasCheckIns = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM CheckIns WHERE ReservationId = @id", new SqlParameter("@id", id.Value))) > 0;
                var hasPayments = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Payments WHERE ReservationId = @id", new SqlParameter("@id", id.Value))) > 0;
                var hasOrders = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM ServiceOrders WHERE ReservationId = @id", new SqlParameter("@id", id.Value))) > 0;

                if (hasCheckIns || hasPayments || hasOrders)
                {
                    MessageBox.Show("Cannot delete this reservation because it has recorded check-ins, payments, or service orders. You can change its status to 'Cancelled' instead.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Reservations WHERE ReservationId = @id";
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to delete reservation", ex);
                MessageBox.Show("Failed to delete reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            var id = GetSelectedReservationId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a reservation to check in.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var dt = DatabaseHelper.ExecuteDataTable("SELECT RoomId, NumberOfGuests, Status FROM Reservations WHERE ReservationId = @id", new SqlParameter("@id", id.Value));
                if (dt.Rows.Count == 0) return;

                var currentStatus = dt.Rows[0]["Status"].ToString();
                if (string.Equals(currentStatus, "CheckedIn", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Guest is already checked in.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (string.Equals(currentStatus, "CheckedOut", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(currentStatus, "Cancelled", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Cannot check in a reservation that is {currentStatus}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var roomId = Convert.ToInt32(dt.Rows[0]["RoomId"]);
                var numGuests = Convert.ToInt32(dt.Rows[0]["NumberOfGuests"]);
                var userId = SessionManager.CurrentUser?.UserId;

                // 1. Record CheckIn
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO CheckIns (ReservationId, ActualCheckIn, NumberOfGuests, Notes, CreatedBy) VALUES (@rid, GETDATE(), @ng, 'Checked-in at front desk', @cb)",
                    new SqlParameter("@rid", id.Value),
                    new SqlParameter("@ng", numGuests),
                    new SqlParameter("@cb", (object)userId ?? DBNull.Value)
                );

                // 2. Update Room status to Occupied
                DatabaseHelper.ExecuteNonQuery("UPDATE Rooms SET Status = 'Occupied' WHERE RoomId = @rid", new SqlParameter("@rid", roomId));

                // 3. Update Reservation status to CheckedIn
                DatabaseHelper.ExecuteNonQuery("UPDATE Reservations SET Status = 'CheckedIn' WHERE ReservationId = @id", new SqlParameter("@id", id.Value));

                MessageBox.Show("Guest successfully checked in! Room status updated to Occupied.", "Check-In Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to check in", ex);
                MessageBox.Show("Failed to check in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnServiceOrder_Click(object sender, EventArgs e)
        {
            var id = GetSelectedReservationId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a reservation first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new ServiceOrderForm(id.Value))
            {
                f.ShowDialog();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            var id = GetSelectedReservationId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a reservation to check out and bill.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var currentStatus = dgvReservations.CurrentRow?.Cells["Status"]?.Value?.ToString();
            if (string.Equals(currentStatus, "CheckedOut", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This reservation has already been checked out and billed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new BillingForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }
    }
}
