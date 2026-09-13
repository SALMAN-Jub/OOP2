using System;
using System.Data;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class RoomsForm : Form
    {
        public RoomsForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string filter = null)
        {
            try
            {
                var svc = new Hotel_Management_System.Services.RoomService();
                var list = svc.GetAllRooms();
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    filter = filter.ToLower();
                    list = new System.Collections.Generic.List<Hotel_Management_System.Models.Room>(list).FindAll(r => (r.RoomNumber ?? "").ToLower().Contains(filter) || (r.Description ?? "").ToLower().Contains(filter));
                }
                dgvRooms.DataSource = new System.Collections.Generic.List<Hotel_Management_System.Models.Room>(list);
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load rooms", ex);
                MessageBox.Show("Failed to load rooms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedRoomId()
        {
            if (dgvRooms.CurrentRow == null) return null;
            if (dgvRooms.CurrentRow.Cells["RoomId"].Value == null) return null;
            return Convert.ToInt32(dgvRooms.CurrentRow.Cells["RoomId"].Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new RoomEditForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedRoomId();
            if (!id.HasValue) { MessageBox.Show("Select a room first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            using (var f = new RoomEditForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedRoomId();
            if (!id.HasValue) { MessageBox.Show("Select a room first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var res = MessageBox.Show("Delete selected room?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            try
            {
                var hasReservations = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Reservations WHERE RoomId = @id", new System.Data.SqlClient.SqlParameter("@id", id.Value))) > 0;
                if (hasReservations)
                {
                    MessageBox.Show("Cannot delete this room because it is associated with existing reservations.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Rooms WHERE RoomId = @id";
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    DatabaseConnection.OpenWithRetry(conn);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to delete room", ex);
                MessageBox.Show("Failed to delete room: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
