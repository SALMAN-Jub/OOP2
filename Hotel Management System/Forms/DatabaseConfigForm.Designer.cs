namespace Hotel_Management_System.Forms
{
    partial class DatabaseConfigForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblAuth;
        private System.Windows.Forms.RadioButton rbWindowsAuth;
        private System.Windows.Forms.RadioButton rbSqlAuth;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkTrustServerCert;
        private System.Windows.Forms.GroupBox grpConnStr;
        private System.Windows.Forms.CheckBox chkManual;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnDefault;
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblAuth = new System.Windows.Forms.Label();
            this.rbWindowsAuth = new System.Windows.Forms.RadioButton();
            this.rbSqlAuth = new System.Windows.Forms.RadioButton();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.chkTrustServerCert = new System.Windows.Forms.CheckBox();
            this.grpConnStr = new System.Windows.Forms.GroupBox();
            this.chkManual = new System.Windows.Forms.CheckBox();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSettings.SuspendLayout();
            this.grpConnStr.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(18, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(262, 21);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "SQL Server Connection Settings";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSub.ForeColor = System.Drawing.Color.DimGray;
            this.lblSub.Location = new System.Drawing.Point(19, 36);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(358, 13);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Configure or test the database connection used by the application.";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.lblServer);
            this.grpSettings.Controls.Add(this.txtServer);
            this.grpSettings.Controls.Add(this.lblDatabase);
            this.grpSettings.Controls.Add(this.txtDatabase);
            this.grpSettings.Controls.Add(this.lblAuth);
            this.grpSettings.Controls.Add(this.rbWindowsAuth);
            this.grpSettings.Controls.Add(this.rbSqlAuth);
            this.grpSettings.Controls.Add(this.lblUser);
            this.grpSettings.Controls.Add(this.txtUser);
            this.grpSettings.Controls.Add(this.lblPass);
            this.grpSettings.Controls.Add(this.txtPass);
            this.grpSettings.Controls.Add(this.chkTrustServerCert);
            this.grpSettings.Location = new System.Drawing.Point(20, 60);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(445, 205);
            this.grpSettings.TabIndex = 2;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Connection Parameters";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(15, 25);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(95, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server / Instance:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(125, 22);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(300, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.TextChanged += new System.EventHandler(this.InputFields_Changed);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(15, 55);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(87, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database Name:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(125, 52);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(300, 20);
            this.txtDatabase.TabIndex = 3;
            this.txtDatabase.TextChanged += new System.EventHandler(this.InputFields_Changed);
            // 
            // lblAuth
            // 
            this.lblAuth.AutoSize = true;
            this.lblAuth.Location = new System.Drawing.Point(15, 85);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(78, 13);
            this.lblAuth.TabIndex = 4;
            this.lblAuth.Text = "Authentication:";
            // 
            // rbWindowsAuth
            // 
            this.rbWindowsAuth.AutoSize = true;
            this.rbWindowsAuth.Checked = true;
            this.rbWindowsAuth.Location = new System.Drawing.Point(125, 83);
            this.rbWindowsAuth.Name = "rbWindowsAuth";
            this.rbWindowsAuth.Size = new System.Drawing.Size(142, 17);
            this.rbWindowsAuth.TabIndex = 5;
            this.rbWindowsAuth.TabStop = true;
            this.rbWindowsAuth.Text = "Windows Authentication";
            this.rbWindowsAuth.UseVisualStyleBackColor = true;
            this.rbWindowsAuth.CheckedChanged += new System.EventHandler(this.AuthMode_Changed);
            // 
            // rbSqlAuth
            // 
            this.rbSqlAuth.AutoSize = true;
            this.rbSqlAuth.Location = new System.Drawing.Point(280, 83);
            this.rbSqlAuth.Name = "rbSqlAuth";
            this.rbSqlAuth.Size = new System.Drawing.Size(135, 17);
            this.rbSqlAuth.TabIndex = 6;
            this.rbSqlAuth.Text = "SQL Server Authentication";
            this.rbSqlAuth.UseVisualStyleBackColor = true;
            this.rbSqlAuth.CheckedChanged += new System.EventHandler(this.AuthMode_Changed);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(15, 115);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(61, 13);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "Username:";
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(125, 112);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(300, 20);
            this.txtUser.TabIndex = 8;
            this.txtUser.TextChanged += new System.EventHandler(this.InputFields_Changed);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(15, 145);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(56, 13);
            this.lblPass.TabIndex = 9;
            this.lblPass.Text = "Password:";
            // 
            // txtPass
            // 
            this.txtPass.Enabled = false;
            this.txtPass.Location = new System.Drawing.Point(125, 142);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(300, 20);
            this.txtPass.TabIndex = 10;
            this.txtPass.TextChanged += new System.EventHandler(this.InputFields_Changed);
            // 
            // chkTrustServerCert
            // 
            this.chkTrustServerCert.AutoSize = true;
            this.chkTrustServerCert.Checked = true;
            this.chkTrustServerCert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrustServerCert.Location = new System.Drawing.Point(125, 172);
            this.chkTrustServerCert.Name = "chkTrustServerCert";
            this.chkTrustServerCert.Size = new System.Drawing.Size(142, 17);
            this.chkTrustServerCert.TabIndex = 11;
            this.chkTrustServerCert.Text = "Trust Server Certificate";
            this.chkTrustServerCert.UseVisualStyleBackColor = true;
            this.chkTrustServerCert.CheckedChanged += new System.EventHandler(this.InputFields_Changed);
            // 
            // grpConnStr
            // 
            this.grpConnStr.Controls.Add(this.chkManual);
            this.grpConnStr.Controls.Add(this.txtConnStr);
            this.grpConnStr.Location = new System.Drawing.Point(20, 275);
            this.grpConnStr.Name = "grpConnStr";
            this.grpConnStr.Size = new System.Drawing.Size(445, 85);
            this.grpConnStr.TabIndex = 3;
            this.grpConnStr.TabStop = false;
            this.grpConnStr.Text = "Active Connection String";
            // 
            // chkManual
            // 
            this.chkManual.AutoSize = true;
            this.chkManual.Location = new System.Drawing.Point(15, 20);
            this.chkManual.Name = "chkManual";
            this.chkManual.Size = new System.Drawing.Size(182, 17);
            this.chkManual.TabIndex = 0;
            this.chkManual.Text = "Edit Connection String Manually";
            this.chkManual.UseVisualStyleBackColor = true;
            this.chkManual.CheckedChanged += new System.EventHandler(this.chkManual_CheckedChanged);
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(15, 45);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.ReadOnly = true;
            this.txtConnStr.Size = new System.Drawing.Size(410, 20);
            this.txtConnStr.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 368);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(445, 20);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Ready";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(20, 395);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(110, 32);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test Connection";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(138, 395);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(100, 32);
            this.btnDefault.TabIndex = 6;
            this.btnDefault.Text = "Reset Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 32);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Connect && Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(385, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DatabaseConfigForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(485, 445);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.grpConnStr);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Connection";
            this.Load += new System.EventHandler(this.DatabaseConfigForm_Load);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.grpConnStr.ResumeLayout(false);
            this.grpConnStr.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
