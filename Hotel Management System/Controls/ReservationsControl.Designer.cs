namespace Hotel_Management_System.Controls
{
    partial class ReservationsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnServiceOrder;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnRefresh;

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
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnServiceOrder = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 23);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(175, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(245, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 26);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(305, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 26);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(365, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 26);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(435, 9);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(75, 28);
            this.btnCheckIn.TabIndex = 5;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnServiceOrder
            // 
            this.btnServiceOrder.BackColor = System.Drawing.Color.FromArgb(2, 136, 209);
            this.btnServiceOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceOrder.ForeColor = System.Drawing.Color.White;
            this.btnServiceOrder.Location = new System.Drawing.Point(515, 9);
            this.btnServiceOrder.Name = "btnServiceOrder";
            this.btnServiceOrder.Size = new System.Drawing.Size(95, 28);
            this.btnServiceOrder.TabIndex = 6;
            this.btnServiceOrder.Text = "Add Service";
            this.btnServiceOrder.UseVisualStyleBackColor = false;
            this.btnServiceOrder.Click += new System.EventHandler(this.btnServiceOrder_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(230, 81, 0);
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(615, 9);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(125, 28);
            this.btnCheckOut.TabIndex = 7;
            this.btnCheckOut.Text = "Check Out & Bill";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(745, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 26);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvReservations
            // 
            this.dgvReservations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Location = new System.Drawing.Point(10, 50);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.Size = new System.Drawing.Size(940, 430);
            this.dgvReservations.TabIndex = 9;
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.MultiSelect = false;
            this.dgvReservations.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservations.EnableHeadersVisualStyles = false;
            this.dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservations.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            // 
            // ReservationsControl
            // 
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnServiceOrder);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvReservations);
            this.Name = "ReservationsControl";
            this.Size = new System.Drawing.Size(960, 490);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
