using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class DatabaseConfigForm : Form
    {
        private bool _isUpdating = false;

        public DatabaseConfigForm()
        {
            InitializeComponent();
        }

        private void DatabaseConfigForm_Load(object sender, EventArgs e)
        {
            LoadCurrentConfiguration();
        }

        private void LoadCurrentConfiguration()
        {
            try
            {
                _isUpdating = true;
                string current = DatabaseConnection.ConnectionString;
                if (!string.IsNullOrWhiteSpace(current))
                {
                    var csb = new SqlConnectionStringBuilder(current);
                    txtServer.Text = csb.DataSource;
                    txtDatabase.Text = csb.InitialCatalog;
                    if (csb.IntegratedSecurity)
                    {
                        rbWindowsAuth.Checked = true;
                        txtUser.Text = string.Empty;
                        txtPass.Text = string.Empty;
                        txtUser.Enabled = false;
                        txtPass.Enabled = false;
                    }
                    else
                    {
                        rbSqlAuth.Checked = true;
                        txtUser.Text = csb.UserID;
                        txtPass.Text = csb.Password;
                        txtUser.Enabled = true;
                        txtPass.Enabled = true;
                    }
                    chkTrustServerCert.Checked = csb.TrustServerCertificate;
                    txtConnStr.Text = current;
                }
                else
                {
                    ResetToDefaultFields();
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Error parsing connection string: {ex.Message}");
                ResetToDefaultFields();
            }
            finally
            {
                _isUpdating = false;
            }

            // Test current connection on load
            RunQuickTest();
        }

        private void ResetToDefaultFields()
        {
            txtServer.Text = @".\SQLEXPRESS";
            txtDatabase.Text = "HotelManagementDB";
            rbWindowsAuth.Checked = true;
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            chkTrustServerCert.Checked = true;
            chkManual.Checked = false;
            BuildConnectionStringFromFields();
        }

        private void AuthMode_Changed(object sender, EventArgs e)
        {
            txtUser.Enabled = rbSqlAuth.Checked;
            txtPass.Enabled = rbSqlAuth.Checked;
            if (!_isUpdating)
            {
                BuildConnectionStringFromFields();
            }
        }

        private void InputFields_Changed(object sender, EventArgs e)
        {
            if (!_isUpdating && !chkManual.Checked)
            {
                BuildConnectionStringFromFields();
            }
        }

        private void chkManual_CheckedChanged(object sender, EventArgs e)
        {
            txtConnStr.ReadOnly = !chkManual.Checked;
            if (!chkManual.Checked)
            {
                BuildConnectionStringFromFields();
            }
        }

        private void BuildConnectionStringFromFields()
        {
            try
            {
                var csb = new SqlConnectionStringBuilder
                {
                    DataSource = string.IsNullOrWhiteSpace(txtServer.Text) ? @".\SQLEXPRESS" : txtServer.Text.Trim(),
                    InitialCatalog = string.IsNullOrWhiteSpace(txtDatabase.Text) ? "HotelManagementDB" : txtDatabase.Text.Trim(),
                    IntegratedSecurity = rbWindowsAuth.Checked,
                    TrustServerCertificate = chkTrustServerCert.Checked
                };

                if (rbSqlAuth.Checked)
                {
                    csb.UserID = txtUser.Text.Trim();
                    csb.Password = txtPass.Text;
                }

                txtConnStr.Text = csb.ConnectionString;
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = $"Error building connection string: {ex.Message}";
            }
        }

        private void RunQuickTest()
        {
            string connStr = txtConnStr.Text.Trim();
            if (DatabaseConnection.TestConnection(connStr, out string err, out int count))
            {
                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text = $"Connection OK! Found {count} database tables.";
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = $"Database Disconnected: {err}";
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connStr = txtConnStr.Text.Trim();
            Cursor.Current = Cursors.WaitCursor;

            if (DatabaseConnection.TestConnection(connStr, out string err, out int count))
            {
                lblStatus.ForeColor = Color.DarkGreen;
                lblStatus.Text = $"Connection OK! Found {count} database tables.";
                MessageBox.Show(
                    $"Successfully connected to the database!\n\nDatabase: {txtDatabase.Text}\nTables found: {count}",
                    "Connection Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = $"Connection Failed: {err}";
                MessageBox.Show(
                    $"Unable to connect to the database.\n\nError:\n{err}\n\nPlease verify:\n1. The SQL Server instance name is correct (e.g. .\\SQLEXPRESS).\n2. The SQL Server service is running.\n3. The database exists.",
                    "Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            _isUpdating = true;
            ResetToDefaultFields();
            _isUpdating = false;
            RunQuickTest();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = txtConnStr.Text.Trim();
            if (string.IsNullOrWhiteSpace(connStr))
            {
                MessageBox.Show("Connection string cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            if (!DatabaseConnection.TestConnection(connStr, out string err, out int count))
            {
                var result = MessageBox.Show(
                    $"Connection test failed:\n{err}\n\nDo you still want to save and use this connection string?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            // Apply new connection string
            DatabaseConnection.SetConnectionString(connStr);
            Logger.Log($"Database connection string updated to: {connStr}");

            // Ensure seed data if connecting to fresh database
            DatabaseInitializer.EnsureSeedData();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
