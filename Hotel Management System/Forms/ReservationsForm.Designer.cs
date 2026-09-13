namespace Hotel_Management_System.Forms
{
    partial class ReservationsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnLoad;

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
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReservations
            // 
            this.dgvReservations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Location = new System.Drawing.Point(200, 50);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.Size = new System.Drawing.Size(760, 400);
            this.dgvReservations.TabIndex = 0;
            this.dgvReservations.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservations.EnableHeadersVisualStyles = false;
            this.dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservations.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(200, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(63, 81, 181);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ReservationsForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvReservations);
            this.Name = "ReservationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reservations";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
