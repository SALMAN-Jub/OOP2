namespace Hotel_Management_System.Forms
{
    partial class BillingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Label lblRoomInfo;
        private System.Windows.Forms.TextBox txtRoomInfo;
        private System.Windows.Forms.Label lblDates;
        private System.Windows.Forms.TextBox txtDates;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.TextBox txtNights;
        private System.Windows.Forms.Label lblRoomCharge;
        private System.Windows.Forms.TextBox txtRoomCharge;
        private System.Windows.Forms.Label lblServiceCharge;
        private System.Windows.Forms.TextBox txtServiceCharge;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblRef;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnConfirmCheckOut;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblGuestName = new System.Windows.Forms.Label();
            this.txtGuestName = new System.Windows.Forms.TextBox();
            this.lblRoomInfo = new System.Windows.Forms.Label();
            this.txtRoomInfo = new System.Windows.Forms.TextBox();
            this.lblDates = new System.Windows.Forms.Label();
            this.txtDates = new System.Windows.Forms.TextBox();
            this.lblNights = new System.Windows.Forms.Label();
            this.txtNights = new System.Windows.Forms.TextBox();
            this.lblRoomCharge = new System.Windows.Forms.Label();
            this.txtRoomCharge = new System.Windows.Forms.TextBox();
            this.lblServiceCharge = new System.Windows.Forms.Label();
            this.txtServiceCharge = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblRef = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnConfirmCheckOut = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(45, 62, 80);
            this.lblHeader.Location = new System.Drawing.Point(20, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(212, 21);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Guest Check-Out & Billing";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Location = new System.Drawing.Point(20, 52);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(38, 13);
            this.lblGuestName.TabIndex = 1;
            this.lblGuestName.Text = "Guest:";
            // 
            // txtGuestName
            // 
            this.txtGuestName.Location = new System.Drawing.Point(120, 49);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.ReadOnly = true;
            this.txtGuestName.Size = new System.Drawing.Size(320, 20);
            this.txtGuestName.TabIndex = 2;
            // 
            // lblRoomInfo
            // 
            this.lblRoomInfo.AutoSize = true;
            this.lblRoomInfo.Location = new System.Drawing.Point(20, 82);
            this.lblRoomInfo.Name = "lblRoomInfo";
            this.lblRoomInfo.Size = new System.Drawing.Size(38, 13);
            this.lblRoomInfo.TabIndex = 3;
            this.lblRoomInfo.Text = "Room:";
            // 
            // txtRoomInfo
            // 
            this.txtRoomInfo.Location = new System.Drawing.Point(120, 79);
            this.txtRoomInfo.Name = "txtRoomInfo";
            this.txtRoomInfo.ReadOnly = true;
            this.txtRoomInfo.Size = new System.Drawing.Size(320, 20);
            this.txtRoomInfo.TabIndex = 4;
            // 
            // lblDates
            // 
            this.lblDates.AutoSize = true;
            this.lblDates.Location = new System.Drawing.Point(20, 112);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new System.Drawing.Size(38, 13);
            this.lblDates.TabIndex = 5;
            this.lblDates.Text = "Dates:";
            // 
            // txtDates
            // 
            this.txtDates.Location = new System.Drawing.Point(120, 109);
            this.txtDates.Name = "txtDates";
            this.txtDates.ReadOnly = true;
            this.txtDates.Size = new System.Drawing.Size(210, 20);
            this.txtDates.TabIndex = 6;
            // 
            // lblNights
            // 
            this.lblNights.AutoSize = true;
            this.lblNights.Location = new System.Drawing.Point(340, 112);
            this.lblNights.Name = "lblNights";
            this.lblNights.Size = new System.Drawing.Size(40, 13);
            this.lblNights.TabIndex = 7;
            this.lblNights.Text = "Nights:";
            // 
            // txtNights
            // 
            this.txtNights.Location = new System.Drawing.Point(385, 109);
            this.txtNights.Name = "txtNights";
            this.txtNights.ReadOnly = true;
            this.txtNights.Size = new System.Drawing.Size(55, 20);
            this.txtNights.TabIndex = 8;
            // 
            // lblRoomCharge
            // 
            this.lblRoomCharge.AutoSize = true;
            this.lblRoomCharge.Location = new System.Drawing.Point(20, 145);
            this.lblRoomCharge.Name = "lblRoomCharge";
            this.lblRoomCharge.Size = new System.Drawing.Size(75, 13);
            this.lblRoomCharge.TabIndex = 9;
            this.lblRoomCharge.Text = "Room Charge:";
            // 
            // txtRoomCharge
            // 
            this.txtRoomCharge.Location = new System.Drawing.Point(120, 142);
            this.txtRoomCharge.Name = "txtRoomCharge";
            this.txtRoomCharge.ReadOnly = true;
            this.txtRoomCharge.Size = new System.Drawing.Size(120, 20);
            this.txtRoomCharge.TabIndex = 10;
            // 
            // lblServiceCharge
            // 
            this.lblServiceCharge.AutoSize = true;
            this.lblServiceCharge.Location = new System.Drawing.Point(20, 175);
            this.lblServiceCharge.Name = "lblServiceCharge";
            this.lblServiceCharge.Size = new System.Drawing.Size(83, 13);
            this.lblServiceCharge.TabIndex = 11;
            this.lblServiceCharge.Text = "Service Charge:";
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.Location = new System.Drawing.Point(120, 172);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.ReadOnly = true;
            this.txtServiceCharge.Size = new System.Drawing.Size(120, 20);
            this.txtServiceCharge.TabIndex = 12;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(20, 205);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(52, 13);
            this.lblDiscount.TabIndex = 13;
            this.lblDiscount.Text = "Discount:";
            // 
            // nudDiscount
            // 
            this.nudDiscount.DecimalPlaces = 2;
            this.nudDiscount.Location = new System.Drawing.Point(120, 202);
            this.nudDiscount.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(120, 20);
            this.nudDiscount.TabIndex = 14;
            this.nudDiscount.ValueChanged += new System.EventHandler(this.nudDiscount_ValueChanged);
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(20, 235);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(57, 13);
            this.lblTax.TabIndex = 15;
            this.lblTax.Text = "Tax (10%):";
            // 
            // txtTax
            // 
            this.txtTax.Location = new System.Drawing.Point(120, 232);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(120, 20);
            this.txtTax.TabIndex = 16;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(20, 268);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(73, 15);
            this.lblGrandTotal.TabIndex = 17;
            this.lblGrandTotal.Text = "Grand Total:";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtGrandTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtGrandTotal.Location = new System.Drawing.Point(120, 263);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(140, 25);
            this.txtGrandTotal.TabIndex = 18;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 305);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(90, 13);
            this.lblPaymentMethod.TabIndex = 19;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Credit Card",
            "Debit Card",
            "Mobile Banking"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(120, 302);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(140, 21);
            this.cmbPaymentMethod.TabIndex = 20;
            // 
            // lblRef
            // 
            this.lblRef.AutoSize = true;
            this.lblRef.Location = new System.Drawing.Point(270, 305);
            this.lblRef.Name = "lblRef";
            this.lblRef.Size = new System.Drawing.Size(46, 13);
            this.lblRef.TabIndex = 21;
            this.lblRef.Text = "Ref No.:";
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(320, 302);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(120, 20);
            this.txtRef.TabIndex = 22;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(20, 340);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 23;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(120, 337);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(320, 20);
            this.txtNotes.TabIndex = 24;
            // 
            // btnConfirmCheckOut
            // 
            this.btnConfirmCheckOut.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnConfirmCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnConfirmCheckOut.Location = new System.Drawing.Point(180, 380);
            this.btnConfirmCheckOut.Name = "btnConfirmCheckOut";
            this.btnConfirmCheckOut.Size = new System.Drawing.Size(170, 34);
            this.btnConfirmCheckOut.TabIndex = 25;
            this.btnConfirmCheckOut.Text = "Confirm Check-Out & Pay";
            this.btnConfirmCheckOut.UseVisualStyleBackColor = false;
            this.btnConfirmCheckOut.Click += new System.EventHandler(this.btnConfirmCheckOut_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(360, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 34);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BillingForm
            // 
            this.ClientSize = new System.Drawing.Size(465, 430);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmCheckOut);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtRef);
            this.Controls.Add(this.lblRef);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.lblGrandTotal);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.nudDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.txtServiceCharge);
            this.Controls.Add(this.lblServiceCharge);
            this.Controls.Add(this.txtRoomCharge);
            this.Controls.Add(this.lblRoomCharge);
            this.Controls.Add(this.txtNights);
            this.Controls.Add(this.lblNights);
            this.Controls.Add(this.txtDates);
            this.Controls.Add(this.lblDates);
            this.Controls.Add(this.txtRoomInfo);
            this.Controls.Add(this.lblRoomInfo);
            this.Controls.Add(this.txtGuestName);
            this.Controls.Add(this.lblGuestName);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BillingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check-Out & Billing";
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
