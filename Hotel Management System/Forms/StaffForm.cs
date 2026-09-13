using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class StaffForm : Form
    {
        public StaffForm()
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
                    cmd.CommandText = "SELECT StaffId, FullName, Phone, Email, Position, Salary, HireDate, IsActive FROM Staff";
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        cmd.CommandText += " WHERE FullName LIKE @f OR Phone LIKE @f OR Email LIKE @f OR Position LIKE @f";
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");
                    }

                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvStaff.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load staff", ex);
                MessageBox.Show("Failed to load staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedStaffId()
        {
            if (dgvStaff.CurrentRow == null) return null;
            if (dgvStaff.CurrentRow.Cells["StaffId"].Value == null) return null;
            return Convert.ToInt32(dgvStaff.CurrentRow.Cells["StaffId"].Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new StaffEditForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedStaffId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a staff member first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new StaffEditForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedStaffId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a staff member first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show("Delete selected staff member?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Staff WHERE StaffId = @id";
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    DatabaseConnection.OpenWithRetry(conn);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to delete staff member", ex);
                MessageBox.Show("Failed to delete staff member: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
