using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class RoomEditForm : Form
    {
        private readonly int? _roomId;

        public RoomEditForm(int? roomId = null)
        {
            InitializeComponent();
            _roomId = roomId;
            LoadRoomTypes();

            if (_roomId.HasValue)
                LoadRoom(_roomId.Value);
        }

        private void LoadRoomTypes()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT RoomTypeId, TypeName FROM RoomTypes";
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    cboRoomType.DisplayMember = "TypeName";
                    cboRoomType.ValueMember = "RoomTypeId";
                    cboRoomType.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load room types", ex);
                MessageBox.Show("Failed to load room types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoom(int id)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT RoomNumber, RoomTypeId, FloorNumber, ISNULL(Status,'') AS Status, ISNULL(Description,'') AS Description FROM Rooms WHERE RoomId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) return;
                    var r = dt.Rows[0];
                    txtRoomNumber.Text = r["RoomNumber"].ToString();
                    cboRoomType.SelectedValue = Convert.ToInt32(r["RoomTypeId"]);
                    if (r["FloorNumber"] != DBNull.Value)
                        nudFloorNumber.Value = Convert.ToDecimal(r["FloorNumber"]);
                    var st = r["Status"].ToString();
                    try { cboStatus.SelectedItem = string.IsNullOrWhiteSpace(st) ? "Available" : st; } catch { }
                    txtDescription.Text = r["Description"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load room", ex);
                MessageBox.Show("Failed to load room: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                MessageBox.Show("Room number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    if (_roomId.HasValue)
                    {
                        cmd.CommandText = "UPDATE Rooms SET RoomNumber=@rn, RoomTypeId=@rt, FloorNumber=@fl, Status=@st, Description=@ds WHERE RoomId=@id";
                        cmd.Parameters.AddWithValue("@id", _roomId.Value);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO Rooms (RoomNumber, RoomTypeId, FloorNumber, Status, Description) VALUES (@rn,@rt,@fl,@st,@ds); SELECT SCOPE_IDENTITY();";
                    }

                    cmd.Parameters.AddWithValue("@rn", txtRoomNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@rt", Convert.ToInt32(cboRoomType.SelectedValue));
                    cmd.Parameters.AddWithValue("@fl", Convert.ToInt32(nudFloorNumber.Value));
                    cmd.Parameters.AddWithValue("@st", cboStatus.SelectedItem?.ToString() ?? "Available");
                    cmd.Parameters.AddWithValue("@ds", txtDescription.Text.Trim());

                    DatabaseConnection.OpenWithRetry(conn);

                    if (_roomId.HasValue)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Room updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var id = cmd.ExecuteScalar();
                        MessageBox.Show("Room created (ID: " + id + ").", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to save room", ex);
                MessageBox.Show("Failed to save room: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
