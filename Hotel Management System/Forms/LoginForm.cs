using System;
using System.Drawing;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Services;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _auth = new AuthenticationService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UpdateDatabaseStatus();
        }

        private void UpdateDatabaseStatus()
        {
            try
            {
                string connStr = DatabaseConnection.ConnectionString;
                if (DatabaseConnection.TestConnection(connStr, out string err, out int tableCount))
                {
                    lblDbStatus.ForeColor = Color.DarkGreen;
                    lblDbStatus.Text = $"● DB Connected: {DatabaseConnection.GetCurrentServerAndDatabase()}";
                }
                else
                {
                    lblDbStatus.ForeColor = Color.Red;
                    lblDbStatus.Text = "● DB Disconnected (Click Settings)";
                }
            }
            catch
            {
                lblDbStatus.ForeColor = Color.Red;
                lblDbStatus.Text = "● DB Error";
            }
        }

        private void btnDbConfig_Click(object sender, EventArgs e)
        {
            using (var dlg = new DatabaseConfigForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateDatabaseStatus();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Quick runtime DB connectivity check
            if (!DatabaseInitializer.TestConnection(out var connMsg))
            {
                Logger.Log($"LoginForm: DB connectivity check failed: {connMsg}");
                var res = MessageBox.Show(
                    $"Database connection failed:\n{connMsg}\n\nWould you like to open Database Settings now?",
                    "Database Error",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (res == DialogResult.Yes)
                {
                    btnDbConfig_Click(sender, e);
                }
                return;
            }

            var user = _auth.Authenticate(txtUsername.Text.Trim(), txtPassword.Text);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials or inactive user.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SessionManager.SetCurrentUser(user);
            var dash = new DashboardForm();
            dash.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
