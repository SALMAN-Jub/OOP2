namespace Hotel_Management_System.Forms
{
    partial class ServiceOrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(15, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(185, 19);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Service Orders for Room ...";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(15, 45);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(46, 13);
            this.lblService.TabIndex = 1;
            this.lblService.Text = "Service:";
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.Location = new System.Drawing.Point(70, 42);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(200, 21);
            this.cmbService.TabIndex = 2;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.cmbService_SelectedIndexChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(280, 45);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(335, 43);
            this.nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(60, 20);
            this.nudQuantity.TabIndex = 4;
            this.nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(405, 45);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(34, 13);
            this.lblUnitPrice.TabIndex = 5;
            this.lblUnitPrice.Text = "Price:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(445, 42);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(70, 20);
            this.txtUnitPrice.TabIndex = 6;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(525, 45);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(565, 42);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(75, 20);
            this.txtTotal.TabIndex = 8;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.btnAddOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOrder.ForeColor = System.Drawing.Color.White;
            this.btnAddOrder.Location = new System.Drawing.Point(650, 40);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(80, 25);
            this.btnAddOrder.TabIndex = 9;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(15, 340);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(90, 28);
            this.btnDeleteOrder.TabIndex = 11;
            this.btnDeleteOrder.Text = "Remove Order";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(15, 80);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Size = new System.Drawing.Size(715, 250);
            this.dgvOrders.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(645, 340);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 28);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ServiceOrderForm
            // 
            this.ClientSize = new System.Drawing.Size(745, 380);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room Service Orders";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
