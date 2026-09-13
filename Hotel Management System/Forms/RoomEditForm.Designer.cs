namespace Hotel_Management_System.Forms
{
    partial class RoomEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.NumericUpDown nudFloorNumber;
        private System.Windows.Forms.Label lblFloorNumber;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
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
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.nudFloorNumber = new System.Windows.Forms.NumericUpDown();
            this.lblFloorNumber = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Location = new System.Drawing.Point(12, 15);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(78, 15);
            this.lblRoomNumber.TabIndex = 0;
            this.lblRoomNumber.Text = "Room Number";
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Location = new System.Drawing.Point(110, 12);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(200, 23);
            this.txtRoomNumber.TabIndex = 1;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Location = new System.Drawing.Point(12, 50);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(62, 15);
            this.lblRoomType.TabIndex = 2;
            this.lblRoomType.Text = "Room Type";
            // 
            // cboRoomType
            // 
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomType.FormattingEnabled = true;
            this.cboRoomType.Location = new System.Drawing.Point(110, 47);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(200, 23);
            this.cboRoomType.TabIndex = 3;
            // 
            // lblFloorNumber
            // 
            this.lblFloorNumber.AutoSize = true;
            this.lblFloorNumber.Location = new System.Drawing.Point(12, 80);
            this.lblFloorNumber.Name = "lblFloorNumber";
            this.lblFloorNumber.Size = new System.Drawing.Size(72, 15);
            this.lblFloorNumber.TabIndex = 4;
            this.lblFloorNumber.Text = "Floor Number";
            // 
            // nudFloorNumber
            // 
            this.nudFloorNumber.Location = new System.Drawing.Point(110, 78);
            this.nudFloorNumber.Minimum = new decimal(new int[] {0,0,0,0});
            this.nudFloorNumber.Maximum = new decimal(new int[] {100,0,0,0});
            this.nudFloorNumber.Name = "nudFloorNumber";
            this.nudFloorNumber.Size = new System.Drawing.Size(80, 23);
            this.nudFloorNumber.TabIndex = 5;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {"Available","Occupied","Maintenance"});
            this.cboStatus.Location = new System.Drawing.Point(200, 78);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(110, 23);
            this.cboStatus.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 110);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 107);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 80);
            this.txtDescription.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(230, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RoomEditForm
            // 
            this.ClientSize = new System.Drawing.Size(340, 250);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.txtRoomNumber);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.cboRoomType);
            this.Controls.Add(this.lblFloorNumber);
            this.Controls.Add(this.nudFloorNumber);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "RoomEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
