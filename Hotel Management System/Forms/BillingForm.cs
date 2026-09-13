using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class BillingForm : Form
    {
        private readonly int _reservationId;
        private int _roomId;
        private decimal _nightlyRate;
        private int _nights;
        private decimal _totalRoomCharge;
        private decimal _totalServiceCharge;

        public BillingForm(int reservationId)
        {
            InitializeComponent();
            _reservationId = reservationId;
            cmbPaymentMethod.SelectedIndex = 0;
            LoadBillingData();
        }

        private void LoadBillingData()
        {
            try
            {
                var sql = @"SELECT r.ReservationId, r.RoomId, g.FullName, rm.RoomNumber, rt.TypeName, rt.PricePerNight,
                                   r.CheckInDate, r.ExpectedCheckOutDate
                            FROM Reservations r
                            JOIN Guests g ON r.GuestId = g.GuestId
                            JOIN Rooms rm ON r.RoomId = rm.RoomId
                            JOIN RoomTypes rt ON rm.RoomTypeId = rt.RoomTypeId
                            WHERE r.ReservationId = @id";
                var dt = DatabaseHelper.ExecuteDataTable(sql, new SqlParameter("@id", _reservationId));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                var r = dt.Rows[0];
                _roomId = Convert.ToInt32(r["RoomId"]);
                _nightlyRate = Convert.ToDecimal(r["PricePerNight"]);

                txtGuestName.Text = r["FullName"].ToString();
                txtRoomInfo.Text = $"Room {r["RoomNumber"]} ({r["TypeName"]}) @ {_nightlyRate:C}/night";

                var checkIn = Convert.ToDateTime(r["CheckInDate"]);
                var checkOut = DateTime.Today > checkIn ? DateTime.Today : Convert.ToDateTime(r["ExpectedCheckOutDate"]);
                if (checkOut <= checkIn) checkOut = checkIn.AddDays(1);

                _nights = (int)(checkOut.Date - checkIn.Date).TotalDays;
                if (_nights < 1) _nights = 1;

                txtDates.Text = $"{checkIn:yyyy-MM-dd} to {checkOut:yyyy-MM-dd}";
                txtNights.Text = _nights.ToString();

                _totalRoomCharge = _nightlyRate * _nights;
                txtRoomCharge.Text = _totalRoomCharge.ToString("F2");

                // Calculate services
                var svcTotalObj = DatabaseHelper.ExecuteScalar("SELECT ISNULL(SUM(TotalPrice), 0) FROM ServiceOrders WHERE ReservationId = @rid", new SqlParameter("@rid", _reservationId));
                _totalServiceCharge = svcTotalObj != null && svcTotalObj != DBNull.Value ? Convert.ToDecimal(svcTotalObj) : 0m;
                txtServiceCharge.Text = _totalServiceCharge.ToString("F2");

                RecalculateTotal();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load billing data", ex);
                MessageBox.Show("Failed to load billing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalculateTotal()
        {
            var subTotal = _totalRoomCharge + _totalServiceCharge;
            var discount = nudDiscount.Value;
            var afterDiscount = Math.Max(0, subTotal - discount);
            var tax = Math.Round(afterDiscount * 0.10m, 2);
            var grandTotal = afterDiscount + tax;

            txtTax.Text = tax.ToString("F2");
            txtGrandTotal.Text = grandTotal.ToString("F2");
        }

        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            RecalculateTotal();
        }

        private void btnConfirmCheckOut_Click(object sender, EventArgs e)
        {
            var grandTotal = decimal.Parse(txtGrandTotal.Text);
            var discount = nudDiscount.Value;
            var tax = decimal.Parse(txtTax.Text);
            var paymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";
            var refNo = txtRef.Text.Trim();
            var notes = txtNotes.Text.Trim();
            var userId = SessionManager.CurrentUser?.UserId;

            var confirm = MessageBox.Show($"Confirm Check-Out and record payment of {grandTotal:F2} via {paymentMethod}?", "Confirm Check-Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                // 1. Record CheckOut
                var sqlCheckOut = @"INSERT INTO CheckOuts (ReservationId, ActualCheckOut, TotalRoomCharge, TotalServiceCharge, Discount, Tax, GrandTotal, Notes, CreatedBy)
                                    VALUES (@rid, GETDATE(), @rc, @sc, @dc, @tx, @gt, @nt, @cb); SELECT SCOPE_IDENTITY();";
                DatabaseHelper.ExecuteScalar(sqlCheckOut,
                    new SqlParameter("@rid", _reservationId),
                    new SqlParameter("@rc", _totalRoomCharge),
                    new SqlParameter("@sc", _totalServiceCharge),
                    new SqlParameter("@dc", discount),
                    new SqlParameter("@tx", tax),
                    new SqlParameter("@gt", grandTotal),
                    new SqlParameter("@nt", notes),
                    new SqlParameter("@cb", (object)userId ?? DBNull.Value)
                );

                // 2. Record Payment
                var sqlPayment = @"INSERT INTO Payments (ReservationId, Amount, PaymentDate, PaymentMethod, TransactionReference, Status, ReceivedBy)
                                   VALUES (@rid, @amt, GETDATE(), @pm, @ref, 'Completed', @rb);";
                DatabaseHelper.ExecuteNonQuery(sqlPayment,
                    new SqlParameter("@rid", _reservationId),
                    new SqlParameter("@amt", grandTotal),
                    new SqlParameter("@pm", paymentMethod),
                    new SqlParameter("@ref", refNo),
                    new SqlParameter("@rb", (object)userId ?? DBNull.Value)
                );

                // 3. Update Room Status to Available
                DatabaseHelper.ExecuteNonQuery("UPDATE Rooms SET Status = 'Available' WHERE RoomId = @rid", new SqlParameter("@rid", _roomId));

                // 4. Update Reservation Status to CheckedOut
                DatabaseHelper.ExecuteNonQuery("UPDATE Reservations SET Status = 'CheckedOut' WHERE ReservationId = @id", new SqlParameter("@id", _reservationId));

                MessageBox.Show("Check-Out and payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to complete check-out", ex);
                MessageBox.Show("Failed to complete check-out: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
