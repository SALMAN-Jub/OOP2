using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class ServiceEditForm : Form
    {
        private readonly int? _serviceId;

        public ServiceEditForm(int? serviceId = null)
        {
            InitializeComponent();
            _serviceId = serviceId;

            if (_serviceId.HasValue)
                LoadService(_serviceId.Value);
        }

        private void LoadService(int id)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT ServiceName, Description, Price, IsActive FROM Services WHERE ServiceId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) return;
                    var r = dt.Rows[0];
                    txtServiceName.Text = r["ServiceName"].ToString();
                    txtDescription.Text = r["Description"].ToString();
                    if (r["Price"] != DBNull.Value)
                        nudPrice.Value = Convert.ToDecimal(r["Price"]);
                    if (r["IsActive"] != DBNull.Value)
                        chkIsActive.Checked = Convert.ToBoolean(r["IsActive"]);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load service", ex);
                MessageBox.Show("Failed to load service: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Service name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    if (_serviceId.HasValue)
                    {
                        cmd.CommandText = "UPDATE Services SET ServiceName=@sn, Description=@ds, Price=@pr, IsActive=@ia WHERE ServiceId=@id";
                        cmd.Parameters.AddWithValue("@id", _serviceId.Value);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO Services (ServiceName, Description, Price, IsActive) VALUES (@sn, @ds, @pr, @ia); SELECT SCOPE_IDENTITY();";
                    }

                    cmd.Parameters.AddWithValue("@sn", txtServiceName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ds", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@pr", nudPrice.Value);
                    cmd.Parameters.AddWithValue("@ia", chkIsActive.Checked ? 1 : 0);

                    DatabaseConnection.OpenWithRetry(conn);

                    if (_serviceId.HasValue)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Service updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var id = cmd.ExecuteScalar();
                        MessageBox.Show("Service added (ID: " + id + ").", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to save service", ex);
                MessageBox.Show("Failed to save service: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
