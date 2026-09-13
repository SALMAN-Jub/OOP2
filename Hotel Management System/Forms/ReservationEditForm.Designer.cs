namespace Hotel_Management_System.Forms
{
    partial class ReservationEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblGuest;
        private System.Windows.Forms.ComboBox cmbGuest;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbRoom;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label lblGuestsCount;
        private System.Windows.Forms.NumericUpDown nudGuests;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
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
            this.lblGuest = new System.Windows.Forms.Label();
            this.cmbGuest = new System.Windows.Forms.ComboBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.lblGuestsCount = new System.Windows.Forms.Label();
            this.nudGuests = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGuest
            // 
            this.lblGuest.AutoSize = true;
            this.lblGuest.Location = new System.Drawing.Point(15, 18);
            this.lblGuest.Name = "lblGuest";
            this.lblGuest.Size = new System.Drawing.Size(39, 13);
            this.lblGuest.TabIndex = 0;
            this.lblGuest.Text = "Guest:";
            // 
            // cmbGuest
            // 
            this.cmbGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuest.Location = new System.Drawing.Point(120, 15);
            this.cmbGuest.Name = "cmbGuest";
            this.cmbGuest.Size = new System.Drawing.Size(280, 21);
            this.cmbGuest.TabIndex = 1;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Location = new System.Drawing.Point(15, 52);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(65, 13);
            this.lblRoomType.TabIndex = 2;
            this.lblRoomType.Text = "Room Type:";
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.Location = new System.Drawing.Point(120, 49);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(280, 21);
            this.cmbRoomType.TabIndex = 3;
            this.cmbRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbRoomType_SelectedIndexChanged);
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(15, 86);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(38, 13);
            this.lblRoom.TabIndex = 4;
            this.lblRoom.Text = "Room:";
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.Location = new System.Drawing.Point(120, 83);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(280, 21);
            this.cmbRoom.TabIndex = 5;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Location = new System.Drawing.Point(15, 120);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(53, 13);
            this.lblCheckIn.TabIndex = 6;
            this.lblCheckIn.Text = "Check-in:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(120, 117);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(200, 20);
            this.dtpCheckIn.TabIndex = 7;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Location = new System.Drawing.Point(15, 154);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(61, 13);
            this.lblCheckOut.TabIndex = 8;
            this.lblCheckOut.Text = "Check-out:";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOut.Location = new System.Drawing.Point(120, 151);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(200, 20);
            this.dtpCheckOut.TabIndex = 9;
            // 
            // lblGuestsCount
            // 
            this.lblGuestsCount.AutoSize = true;
            this.lblGuestsCount.Location = new System.Drawing.Point(15, 188);
            this.lblGuestsCount.Name = "lblGuestsCount";
            this.lblGuestsCount.Size = new System.Drawing.Size(83, 13);
            this.lblGuestsCount.TabIndex = 10;
            this.lblGuestsCount.Text = "Number Guests:";
            // 
            // nudGuests
            // 
            this.nudGuests.Location = new System.Drawing.Point(120, 185);
            this.nudGuests.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.nudGuests.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudGuests.Name = "nudGuests";
            this.nudGuests.Size = new System.Drawing.Size(80, 20);
            this.nudGuests.TabIndex = 11;
            this.nudGuests.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(15, 222);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Confirmed",
            "CheckedIn",
            "CheckedOut",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 219);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 21);
            this.cmbStatus.TabIndex = 13;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(15, 256);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 14;
            this.lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(120, 253);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(280, 70);
            this.txtNotes.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(205, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 32);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(310, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReservationEditForm
            // 
            this.ClientSize = new System.Drawing.Size(430, 390);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.nudGuests);
            this.Controls.Add(this.lblGuestsCount);
            this.Controls.Add(this.dtpCheckOut);
            this.Controls.Add(this.lblCheckOut);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.cmbRoom);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.cmbGuest);
            this.Controls.Add(this.lblGuest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReservationEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reservation";
            ((System.ComponentModel.ISupportInitialize)(this.nudGuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
