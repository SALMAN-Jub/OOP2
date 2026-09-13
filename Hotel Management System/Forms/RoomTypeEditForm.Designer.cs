namespace Hotel_Management_System.Forms
{
    partial class RoomTypeEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown nudCapacity;
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
            this.lblTypeName = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.nudCapacity = new System.Windows.Forms.NumericUpDown();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTypeName
            // 
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(30, 25);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(65, 13);
            this.lblTypeName.TabIndex = 0;
            this.lblTypeName.Text = "Type Name:";
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(120, 22);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(240, 20);
            this.txtTypeName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 65);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(120, 62);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(240, 60);
            this.txtDescription.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(30, 140);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(83, 13);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price Per Night:";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(120, 138);
            this.nudPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(120, 20);
            this.nudPrice.TabIndex = 5;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(30, 180);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(51, 13);
            this.lblCapacity.TabIndex = 6;
            this.lblCapacity.Text = "Capacity:";
            // 
            // nudCapacity
            // 
            this.nudCapacity.Location = new System.Drawing.Point(120, 178);
            this.nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCapacity.Name = "nudCapacity";
            this.nudCapacity.Size = new System.Drawing.Size(120, 20);
            this.nudCapacity.TabIndex = 7;
            this.nudCapacity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(120, 215);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(56, 17);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(180, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RoomTypeEditForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 310);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.nudCapacity);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.lblTypeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomTypeEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Room Type";
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
