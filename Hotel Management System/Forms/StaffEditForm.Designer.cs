namespace Hotel_Management_System.Forms
{
    partial class StaffEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.NumericUpDown nudSalary;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.CheckBox chkIsActive;
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
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.nudSalary = new System.Windows.Forms.NumericUpDown();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(30, 25);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(57, 13);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(110, 22);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(250, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(30, 60);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(110, 57);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 95);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(30, 130);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(47, 13);
            this.lblPosition.TabIndex = 6;
            this.lblPosition.Text = "Position:";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(110, 127);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(250, 20);
            this.txtPosition.TabIndex = 7;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(30, 165);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(39, 13);
            this.lblSalary.TabIndex = 8;
            this.lblSalary.Text = "Salary:";
            // 
            // nudSalary
            // 
            this.nudSalary.DecimalPlaces = 2;
            this.nudSalary.Location = new System.Drawing.Point(110, 163);
            this.nudSalary.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudSalary.Name = "nudSalary";
            this.nudSalary.Size = new System.Drawing.Size(130, 20);
            this.nudSalary.TabIndex = 9;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Location = new System.Drawing.Point(30, 200);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(55, 13);
            this.lblHireDate.TabIndex = 10;
            this.lblHireDate.Text = "Hire Date:";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHireDate.Location = new System.Drawing.Point(110, 197);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(130, 20);
            this.dtpHireDate.TabIndex = 11;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(110, 230);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(56, 17);
            this.chkIsActive.TabIndex = 12;
            this.chkIsActive.Text = "Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(190, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(285, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // StaffEditForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 315);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.dtpHireDate);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.nudSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Staff Member";
            ((System.ComponentModel.ISupportInitialize)(this.nudSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
