using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System.Forms
{
    public partial class ServiceOrderForm : Form
    {
        private readonly int _reservationId;
        private DataTable _servicesTable;

        public ServiceOrderForm(int reservationId)
        {
            InitializeComponent();
            _reservationId = reservationId;
            LoadReservationHeader();
            LoadServicesList();
            LoadOrders();
        }

        private void LoadReservationHeader()
        {
            try
            {
                var sql = @"SELECT r.ReservationId, g.FullName, rm.RoomNumber 
                            FROM Reservations r
                            JOIN Guests g ON r.GuestId = g.GuestId
                            JOIN Rooms rm ON r.RoomId = rm.RoomId
                            WHERE r.ReservationId = @id";
                var dt = DatabaseHelper.ExecuteDataTable(sql, new SqlParameter("@id", _reservationId));
                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];
                    lblHeader.Text = $"Service Orders: Room {r["RoomNumber"]} - Guest: {r["FullName"]} (Reservation #{r["ReservationId"]})";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load reservation header", ex);
            }
        }

        private void LoadServicesList()
        {
            try
            {
                _servicesTable = DatabaseHelper.ExecuteDataTable("SELECT ServiceId, ServiceName, Price FROM Services WHERE IsActive = 1 ORDER BY ServiceName");
                cmbService.DisplayMember = "ServiceName";
                cmbService.ValueMember = "ServiceId";
                cmbService.DataSource = _servicesTable;
                UpdatePriceAndTotal();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load services list", ex);
            }
        }

        private void UpdatePriceAndTotal()
        {
            if (cmbService.SelectedValue != null && _servicesTable != null)
            {
                var selectedRow = _servicesTable.Select($"ServiceId = {cmbService.SelectedValue}");
                if (selectedRow.Length > 0)
                {
                    var price = Convert.ToDecimal(selectedRow[0]["Price"]);
                    txtUnitPrice.Text = price.ToString("F2");
                    var total = price * nudQuantity.Value;
                    txtTotal.Text = total.ToString("F2");
                    return;
                }
            }
            txtUnitPrice.Text = "0.00";
            txtTotal.Text = "0.00";
        }

        private void LoadOrders()
        {
            try
            {
                var sql = @"SELECT so.ServiceOrderId, s.ServiceName, so.Quantity, so.UnitPrice, so.TotalPrice, so.OrderDate, so.Status
                            FROM ServiceOrders so
                            JOIN Services s ON so.ServiceId = s.ServiceId
                            WHERE so.ReservationId = @rid
                            ORDER BY so.OrderDate DESC";
                var dt = DatabaseHelper.ExecuteDataTable(sql, new SqlParameter("@rid", _reservationId));
                dgvOrders.DataSource = dt;
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to load service orders", ex);
                MessageBox.Show("Failed to load orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePriceAndTotal();
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceAndTotal();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (cmbService.SelectedValue == null)
            {
                MessageBox.Show("Please select a service.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var serviceId = Convert.ToInt32(cmbService.SelectedValue);
                var qty = (int)nudQuantity.Value;
                var unitPrice = decimal.Parse(txtUnitPrice.Text);
                var totalPrice = unitPrice * qty;

                var sql = @"INSERT INTO ServiceOrders (ReservationId, ServiceId, Quantity, UnitPrice, TotalPrice, OrderDate, Status)
                            VALUES (@rid, @sid, @qty, @up, @tp, GETDATE(), 'Completed')";

                DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@rid", _reservationId),
                    new SqlParameter("@sid", serviceId),
                    new SqlParameter("@qty", qty),
                    new SqlParameter("@up", unitPrice),
                    new SqlParameter("@tp", totalPrice)
                );

                MessageBox.Show("Service order added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrders();
                nudQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to add service order", ex);
                MessageBox.Show("Failed to add service order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null || dgvOrders.CurrentRow.Cells["ServiceOrderId"].Value == null)
            {
                MessageBox.Show("Select an order to remove.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var orderId = Convert.ToInt32(dgvOrders.CurrentRow.Cells["ServiceOrderId"].Value);
            var confirm = MessageBox.Show("Remove selected service order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM ServiceOrders WHERE ServiceOrderId = @id", new SqlParameter("@id", orderId));
                LoadOrders();
            }
            catch (Exception ex)
            {
                Logger.LogError("Failed to delete service order", ex);
                MessageBox.Show("Failed to delete service order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
