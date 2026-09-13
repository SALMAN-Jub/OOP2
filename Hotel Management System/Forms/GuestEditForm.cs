using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class GuestEditForm : Form
    {
        private readonly int? _guestId;

        public GuestEditForm(int? guestId = null)
        {
            InitializeComponent();
            _guestId = guestId;

            if (_guestId.HasValue)
                LoadGuest(_guestId.Value);
        }

        private void LoadGuest(int id)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT FullName, Phone, Email, Address FROM Guests WHERE GuestId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    var da = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0) return;
                    var r = dt.Rows[0];
                    txtFullName.Text = r["FullName"].ToString();
                    txtPhone.Text = r["Phone"].ToString();
                    txtEmail.Text = r["Email"].ToString();
                    txtAddress.Text = r["Address"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load guest", ex);
                MessageBox.Show("Failed to load guest: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (_guestId.HasValue)
                    {
                        cmd.CommandText = "UPDATE Guests SET FullName=@fn, Phone=@ph, Email=@em, Address=@ad WHERE GuestId=@id";
                        cmd.Parameters.AddWithValue("@id", _guestId.Value);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO Guests (FullName, Phone, Email, Address, CreatedAt) VALUES (@fn,@ph,@em,@ad,GETDATE()); SELECT SCOPE_IDENTITY();";
                    }

                    cmd.Parameters.AddWithValue("@fn", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@ph", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@ad", txtAddress.Text.Trim());

                    DatabaseConnection.OpenWithRetry(conn);

                    if (_guestId.HasValue)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Guest updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var id = cmd.ExecuteScalar();
                        MessageBox.Show("Guest created (ID: " + id + ").", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to save guest", ex);
                MessageBox.Show("Failed to save guest: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
