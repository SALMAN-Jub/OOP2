using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class ServicesForm : Form
    {
        public ServicesForm()
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
                    cmd.CommandText = "SELECT ServiceId, ServiceName, Description, Price, IsActive FROM Services";
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        cmd.CommandText += " WHERE ServiceName LIKE @f OR Description LIKE @f";
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");
                    }

                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvServices.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load services", ex);
                MessageBox.Show("Failed to load services: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedServiceId()
        {
            if (dgvServices.CurrentRow == null) return null;
            if (dgvServices.CurrentRow.Cells["ServiceId"].Value == null) return null;
            return Convert.ToInt32(dgvServices.CurrentRow.Cells["ServiceId"].Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var f = new ServiceEditForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var id = GetSelectedServiceId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a service first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new ServiceEditForm(id.Value))
            {
                if (f.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedServiceId();
            if (!id.HasValue)
            {
                MessageBox.Show("Select a service first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show("Delete selected service?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            try
            {
                var hasOrders = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM ServiceOrders WHERE ServiceId = @id", new SqlParameter("@id", id.Value))) > 0;
                if (hasOrders)
                {
                    MessageBox.Show("Cannot delete this service because it has been ordered in reservations. You can edit it to mark it inactive instead.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Services WHERE ServiceId = @id";
                    cmd.Parameters.AddWithValue("@id", id.Value);
                    DatabaseConnection.OpenWithRetry(conn);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to delete service", ex);
                MessageBox.Show("Failed to delete service: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
