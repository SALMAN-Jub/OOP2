using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class StaffEditForm : Form
    {
        private readonly int? _staffId;

        public StaffEditForm(int? staffId = null)
        {
            InitializeComponent();
            _staffId = staffId;

            if (_staffId.HasValue)
                LoadStaff(_staffId.Value);
        }

        private void LoadStaff(int id)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT FullName, Phone, Email, Position, Salary, HireDate, IsActive FROM Staff WHERE StaffId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) return;
                    var r = dt.Rows[0];
                    txtFullName.Text = r["FullName"].ToString();
                    txtPhone.Text = r["Phone"].ToString();
                    txtEmail.Text = r["Email"].ToString();
                    txtPosition.Text = r["Position"].ToString();
                    if (r["Salary"] != DBNull.Value)
                        nudSalary.Value = Convert.ToDecimal(r["Salary"]);
                    if (r["HireDate"] != DBNull.Value)
                        dtpHireDate.Value = Convert.ToDateTime(r["HireDate"]);
                    if (r["IsActive"] != DBNull.Value)
                        chkIsActive.Checked = Convert.ToBoolean(r["IsActive"]);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load staff", ex);
                MessageBox.Show("Failed to load staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    if (_staffId.HasValue)
                    {
                        cmd.CommandText = "UPDATE Staff SET FullName=@fn, Phone=@ph, Email=@em, Position=@pos, Salary=@sal, HireDate=@hd, IsActive=@ia WHERE StaffId=@id";
                        cmd.Parameters.AddWithValue("@id", _staffId.Value);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO Staff (FullName, Phone, Email, Position, Salary, HireDate, IsActive) VALUES (@fn, @ph, @em, @pos, @sal, @hd, @ia); SELECT SCOPE_IDENTITY();";
                    }

                    cmd.Parameters.AddWithValue("@fn", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ph", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@pos", txtPosition.Text.Trim());
                    cmd.Parameters.AddWithValue("@sal", nudSalary.Value);
                    cmd.Parameters.AddWithValue("@hd", dtpHireDate.Value.Date);
                    cmd.Parameters.AddWithValue("@ia", chkIsActive.Checked ? 1 : 0);

                    DatabaseConnection.OpenWithRetry(conn);

                    if (_staffId.HasValue)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Staff member updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var id = cmd.ExecuteScalar();
                        MessageBox.Show("Staff member added (ID: " + id + ").", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to save staff", ex);
                MessageBox.Show("Failed to save staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
