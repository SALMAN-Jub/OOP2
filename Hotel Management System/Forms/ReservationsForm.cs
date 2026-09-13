using System;
using System.Data;
using System.Windows.Forms;
using Hotel_Management_System.Database;

namespace Hotel_Management_System.Forms
{
    public partial class ReservationsForm : Form
    {
        public ReservationsForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    var da = new System.Data.SqlClient.SqlDataAdapter("SELECT ReservationId, GuestId, RoomId, BookingDate, CheckInDate, ExpectedCheckOutDate, Status FROM Reservations", conn);
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvReservations.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load reservations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
