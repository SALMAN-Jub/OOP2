using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class RoomTypeEditForm : Form
    {
        private readonly int? _roomTypeId;

        public RoomTypeEditForm(int? roomTypeId = null)
        {
            InitializeComponent();
            _roomTypeId = roomTypeId;

            if (_roomTypeId.HasValue)
                LoadRoomType(_roomTypeId.Value);
        }

        private void LoadRoomType(int id)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT TypeName, Description, PricePerNight, Capacity, IsActive FROM RoomTypes WHERE RoomTypeId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) return;
                    var r = dt.Rows[0];
                    txtTypeName.Text = r["TypeName"].ToString();
                    txtDescription.Text = r["Description"].ToString();
                    nudPrice.Value = Convert.ToDecimal(r["PricePerNight"]);
                    nudCapacity.Value = Convert.ToDecimal(r["Capacity"]);
                    chkIsActive.Checked = Convert.ToBoolean(r["IsActive"]);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load room type", ex);
                MessageBox.Show("Failed to load room type: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                MessageBox.Show("Type name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    if (_roomTypeId.HasValue)
                    {
                        cmd.CommandText = "UPDATE RoomTypes SET TypeName=@tn, Description=@ds, PricePerNight=@pr, Capacity=@cp, IsActive=@ia WHERE RoomTypeId=@id";
                        cmd.Parameters.AddWithValue("@id", _roomTypeId.Value);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO RoomTypes (TypeName, Description, PricePerNight, Capacity, IsActive) VALUES (@tn, @ds, @pr, @cp, @ia); SELECT SCOPE_IDENTITY();";
                    }

                    cmd.Parameters.AddWithValue("@tn", txtTypeName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ds", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@pr", nudPrice.Value);
                    cmd.Parameters.AddWithValue("@cp", Convert.ToInt32(nudCapacity.Value));
                    cmd.Parameters.AddWithValue("@ia", chkIsActive.Checked ? 1 : 0);

                    DatabaseConnection.OpenWithRetry(conn);

                    if (_roomTypeId.HasValue)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Room type updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var id = cmd.ExecuteScalar();
                        MessageBox.Show("Room type created (ID: " + id + ").", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to save room type", ex);
                MessageBox.Show("Failed to save room type: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
