using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Utilities;
using Hotel_Management_System.Controls;
using Hotel_Management_System.Database;

namespace Hotel_Management_System.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            lblWelcome.Text = SessionManager.CurrentUser != null ? $"Welcome, {SessionManager.CurrentUser.FullName}" : "Welcome";
            LoadSummary();

            // Load reservations module by default with active button highlight
            try
            {
                SetActiveButton(btnReservations);
                LoadModule(new ReservationsControl());
            }
            catch { }
        }

        private void SetActiveButton(Button activeBtn)
        {
            var buttons = new[] { btnRooms, btnGuests, btnReservations, btnRoomTypes, btnStaff, btnServices };
            foreach (var b in buttons)
            {
                if (b == activeBtn)
                {
                    b.BackColor = System.Drawing.Color.FromArgb(255, 87, 34);
                    b.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    b.BackColor = System.Drawing.Color.Transparent;
                    b.ForeColor = System.Drawing.Color.WhiteSmoke;
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Clear();
            var login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void LoadModule(Control ctrl)
        {
            contentPanel.Controls.Clear();
            if (ctrl is Form f)
            {
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(f);
                f.Show();
                return;
            }

            ctrl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(ctrl);
        }

        private void LoadSummary()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    // Available rooms: rooms with status 'Available'
                    try
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Rooms WHERE Status = 'Available'";
                        var rooms = Convert.ToInt32(cmd.ExecuteScalar());
                        lblAvailableRoomsValue.Text = rooms.ToString();
                    }
                    catch
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Rooms WHERE Status IS NULL OR Status <> 'Maintenance'";
                        lblAvailableRoomsValue.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                    }

                    // Reservations today
                    cmd.CommandText = "SELECT COUNT(*) FROM Reservations WHERE CONVERT(date, BookingDate) = CONVERT(date, GETDATE())";
                    lblReservationsTodayValue.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();

                    // Total guests
                    cmd.CommandText = "SELECT COUNT(*) FROM Guests";
                    lblTotalGuestsValue.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load dashboard summary", ex);
            }
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnRooms);
            LoadModule(new RoomsForm());
            LoadSummary();
        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnGuests);
            LoadModule(new GuestsForm());
            LoadSummary();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnReservations);
            LoadModule(new ReservationsControl());
            LoadSummary();
        }

        private void btnRoomTypes_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnRoomTypes);
            LoadModule(new RoomTypesForm());
            LoadSummary();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnStaff);
            LoadModule(new StaffForm());
            LoadSummary();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnServices);
            LoadModule(new ServicesForm());
            LoadSummary();
        }
    }
}
