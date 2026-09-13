using System;
using System.Data;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class GuestsForm : Form
    {
        public GuestsForm()
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
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT GuestId, FullName, Phone, Email, CreatedAt FROM Guests";
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        cmd.CommandText += " WHERE FullName LIKE @f OR Phone LIKE @f OR Email LIKE @f";
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");
                    }

                    var da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvGuests.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load guests", ex);
                MessageBox.Show("Failed to load guests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedGuestId()
        {
            if (dgvGuests.CurrentRow == null) return null;
            if (dgvGuests.CurrentRow.Cells["GuestId"].Value == null) return null;
            return Convert.ToInt32(dgvGuests.CurrentRow.Cells["GuestId"].Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new GuestEditForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedGuestId();
            if (!id.HasValue) { MessageBox.Show("Select a guest first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            using (var f = new GuestEditForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedGuestId();
            if (!id.HasValue) { MessageBox.Show("Select a guest first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var res = MessageBox.Show("Delete selected guest?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            try
            {
                var hasReservations = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Reservations WHERE GuestId = @id", new System.Data.SqlClient.SqlParameter("@id", id.Value))) > 0;
                if (hasReservations)
                {
                    MessageBox.Show("Cannot delete this guest because there are reservations associated with them.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Guests WHERE GuestId = @id";
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    DatabaseConnection.OpenWithRetry(conn);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to delete guest", ex);
                MessageBox.Show("Failed to delete guest: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
