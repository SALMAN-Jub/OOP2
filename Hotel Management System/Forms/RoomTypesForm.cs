using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class RoomTypesForm : Form
    {
        public RoomTypesForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void LoadData(string filter = null)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT RoomTypeId, TypeName, Description, PricePerNight, Capacity, IsActive FROM RoomTypes";
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        cmd.CommandText += " WHERE TypeName LIKE @f OR Description LIKE @f";
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");
                    }

                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvRoomTypes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load room types", ex);
                MessageBox.Show("Failed to load room types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedRoomTypeId()
        {
            if (dgvRoomTypes.CurrentRow == null) return null;
            if (dgvRoomTypes.CurrentRow.Cells["RoomTypeId"].Value == null) return null;
            return Convert.ToInt32(dgvRoomTypes.CurrentRow.Cells["RoomTypeId"].Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new RoomTypeEditForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedRoomTypeId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a room type first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new RoomTypeEditForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedRoomTypeId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a room type first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show("Delete selected room type?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            try
            {
                var hasRooms = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Rooms WHERE RoomTypeId = @id", new SqlParameter("@id", id.Value))) > 0;
                if (hasRooms)
                {
                    MessageBox.Show("Cannot delete this room type because there are rooms configured with it.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM RoomTypes WHERE RoomTypeId = @id";
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    DatabaseConnection.OpenWithRetry(conn);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to delete room type", ex);
                MessageBox.Show("Failed to delete room type: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
