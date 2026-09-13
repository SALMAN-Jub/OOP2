namespace Hotel_Management_System.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel leftNavPanel;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnGuests;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnRoomTypes;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Panel contentPanel;

        // New header and summary controls
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel cardAvailableRooms;
        private System.Windows.Forms.Label lblAvailableRoomsValue;
        private System.Windows.Forms.Label lblAvailableRoomsText;
        private System.Windows.Forms.Panel cardReservationsToday;
        private System.Windows.Forms.Label lblReservationsTodayValue;
        private System.Windows.Forms.Label lblReservationsTodayText;
        private System.Windows.Forms.Panel cardTotalGuests;
        private System.Windows.Forms.Label lblTotalGuestsValue;
        private System.Windows.Forms.Label lblTotalGuestsText;

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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.leftNavPanel = new System.Windows.Forms.Panel();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnRoomTypes = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnGuests = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();

            // header and cards
            this.headerPanel = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.cardAvailableRooms = new System.Windows.Forms.Panel();
            this.lblAvailableRoomsValue = new System.Windows.Forms.Label();
            this.lblAvailableRoomsText = new System.Windows.Forms.Label();
            this.cardReservationsToday = new System.Windows.Forms.Panel();
            this.lblReservationsTodayValue = new System.Windows.Forms.Label();
            this.lblReservationsTodayText = new System.Windows.Forms.Label();
            this.cardTotalGuests = new System.Windows.Forms.Panel();
            this.lblTotalGuestsValue = new System.Windows.Forms.Label();
            this.lblTotalGuestsText = new System.Windows.Forms.Label();

            this.leftNavPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.cardAvailableRooms.SuspendLayout();
            this.cardReservationsToday.SuspendLayout();
            this.cardTotalGuests.SuspendLayout();
            this.SuspendLayout();

            // Theme colors
            var navBg = System.Drawing.Color.FromArgb(34, 40, 49);
            var primary = System.Drawing.Color.FromArgb(45, 62, 80);
            var accent1 = System.Drawing.Color.FromArgb(244, 143, 177); // pink
            var accent2 = System.Drawing.Color.FromArgb(129, 199, 132); // green
            var accent3 = System.Drawing.Color.FromArgb(100, 181, 246); // blue
            var headerBg = System.Drawing.Color.FromArgb(33, 150, 243); // strong hotel blue
            var formBg = System.Drawing.Color.FromArgb(250, 250, 250);

            // leftNavPanel
            this.leftNavPanel.BackColor = navBg;
            this.leftNavPanel.Controls.Add(this.btnServices);
            this.leftNavPanel.Controls.Add(this.btnStaff);
            this.leftNavPanel.Controls.Add(this.btnRoomTypes);
            this.leftNavPanel.Controls.Add(this.btnReservations);
            this.leftNavPanel.Controls.Add(this.btnGuests);
            this.leftNavPanel.Controls.Add(this.btnRooms);
            this.leftNavPanel.Location = new System.Drawing.Point(0, 0);
            this.leftNavPanel.Name = "leftNavPanel";
            this.leftNavPanel.Size = new System.Drawing.Size(200, 720);
            this.leftNavPanel.TabIndex = 99;

            // Navigation buttons styling
            System.Drawing.Font navFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            void StyleNavButton(System.Windows.Forms.Button b, bool primaryBtn = false)
            {
                b.Size = new System.Drawing.Size(180, 42);
                b.UseVisualStyleBackColor = false;
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.Font = navFont;
                if (primaryBtn)
                {
                    b.BackColor = System.Drawing.Color.FromArgb(255, 87, 34);
                    b.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    b.BackColor = System.Drawing.Color.Transparent;
                    b.ForeColor = System.Drawing.Color.WhiteSmoke;
                }
            }

            // btnRooms
            this.btnRooms.Location = new System.Drawing.Point(10, 20);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Text = "Rooms";
            StyleNavButton(this.btnRooms, false);
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);

            // btnGuests
            this.btnGuests.Location = new System.Drawing.Point(10, 72);
            this.btnGuests.Name = "btnGuests";
            this.btnGuests.Text = "Guests";
            StyleNavButton(this.btnGuests);
            this.btnGuests.Click += new System.EventHandler(this.btnGuests_Click);

            // btnReservations
            this.btnReservations.Location = new System.Drawing.Point(10, 124);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Text = "Reservations";
            StyleNavButton(this.btnReservations, true);
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);

            // btnRoomTypes
            this.btnRoomTypes.Location = new System.Drawing.Point(10, 176);
            this.btnRoomTypes.Name = "btnRoomTypes";
            this.btnRoomTypes.Text = "Room Types";
            StyleNavButton(this.btnRoomTypes);
            this.btnRoomTypes.Click += new System.EventHandler(this.btnRoomTypes_Click);

            // btnStaff
            this.btnStaff.Location = new System.Drawing.Point(10, 228);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Text = "Staff";
            StyleNavButton(this.btnStaff);
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);

            // btnServices
            this.btnServices.Location = new System.Drawing.Point(10, 280);
            this.btnServices.Name = "btnServices";
            this.btnServices.Text = "Services";
            StyleNavButton(this.btnServices);
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);

            // headerPanel
            this.headerPanel.BackColor = headerBg;
            this.headerPanel.Location = new System.Drawing.Point(200, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(980, 60);
            this.headerPanel.TabIndex = 110;

            // picLogo
            this.picLogo.Location = new System.Drawing.Point(210, 6);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(48, 48);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // Note: no image embedded; user can set PictureBox.Image at runtime if desired

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(270, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Hotel Management System";

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.lblSubtitle.Location = new System.Drawing.Point(520, 20);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Manage rooms, reservations, guests and services with ease";

            // Summary cards positions
            int cardTop = 70;
            int cardLeftStart = 220;
            int cardWidth = 240;
            int cardHeight = 100;
            int gap = 20;

            // cardAvailableRooms
            this.cardAvailableRooms.Location = new System.Drawing.Point(cardLeftStart, cardTop);
            this.cardAvailableRooms.Name = "cardAvailableRooms";
            this.cardAvailableRooms.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.cardAvailableRooms.BackColor = accent1;
            this.cardAvailableRooms.Padding = new System.Windows.Forms.Padding(12);
            this.cardAvailableRooms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cardAvailableRooms.Controls.Add(this.lblAvailableRoomsValue);
            this.cardAvailableRooms.Controls.Add(this.lblAvailableRoomsText);

            this.lblAvailableRoomsValue.AutoSize = true;
            this.lblAvailableRoomsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAvailableRoomsValue.ForeColor = System.Drawing.Color.White;
            this.lblAvailableRoomsValue.Location = new System.Drawing.Point(12, 10);
            this.lblAvailableRoomsValue.Name = "lblAvailableRoomsValue";
            this.lblAvailableRoomsValue.Text = "0";

            this.lblAvailableRoomsText.AutoSize = true;
            this.lblAvailableRoomsText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvailableRoomsText.ForeColor = System.Drawing.Color.White;
            this.lblAvailableRoomsText.Location = new System.Drawing.Point(14, 55);
            this.lblAvailableRoomsText.Name = "lblAvailableRoomsText";
            this.lblAvailableRoomsText.Text = "Available Rooms";

            // cardReservationsToday
            this.cardReservationsToday.Location = new System.Drawing.Point(cardLeftStart + (cardWidth + gap), cardTop);
            this.cardReservationsToday.Name = "cardReservationsToday";
            this.cardReservationsToday.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.cardReservationsToday.BackColor = accent2;
            this.cardReservationsToday.Padding = new System.Windows.Forms.Padding(12);
            this.cardReservationsToday.Controls.Add(this.lblReservationsTodayValue);
            this.cardReservationsToday.Controls.Add(this.lblReservationsTodayText);

            this.lblReservationsTodayValue.AutoSize = true;
            this.lblReservationsTodayValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblReservationsTodayValue.ForeColor = System.Drawing.Color.White;
            this.lblReservationsTodayValue.Location = new System.Drawing.Point(12, 10);
            this.lblReservationsTodayValue.Name = "lblReservationsTodayValue";
            this.lblReservationsTodayValue.Text = "0";

            this.lblReservationsTodayText.AutoSize = true;
            this.lblReservationsTodayText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReservationsTodayText.ForeColor = System.Drawing.Color.White;
            this.lblReservationsTodayText.Location = new System.Drawing.Point(14, 55);
            this.lblReservationsTodayText.Name = "lblReservationsTodayText";
            this.lblReservationsTodayText.Text = "Today's Reservations";

            // cardTotalGuests
            this.cardTotalGuests.Location = new System.Drawing.Point(cardLeftStart + 2 * (cardWidth + gap), cardTop);
            this.cardTotalGuests.Name = "cardTotalGuests";
            this.cardTotalGuests.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.cardTotalGuests.BackColor = accent3;
            this.cardTotalGuests.Padding = new System.Windows.Forms.Padding(12);
            this.cardTotalGuests.Controls.Add(this.lblTotalGuestsValue);
            this.cardTotalGuests.Controls.Add(this.lblTotalGuestsText);

            this.lblTotalGuestsValue.AutoSize = true;
            this.lblTotalGuestsValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalGuestsValue.ForeColor = System.Drawing.Color.White;
            this.lblTotalGuestsValue.Location = new System.Drawing.Point(12, 10);
            this.lblTotalGuestsValue.Name = "lblTotalGuestsValue";
            this.lblTotalGuestsValue.Text = "0";

            this.lblTotalGuestsText.AutoSize = true;
            this.lblTotalGuestsText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalGuestsText.ForeColor = System.Drawing.Color.White;
            this.lblTotalGuestsText.Location = new System.Drawing.Point(14, 55);
            this.lblTotalGuestsText.Name = "lblTotalGuestsText";
            this.lblTotalGuestsText.Text = "Total Guests";

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(220, 190);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(86, 21);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(1080, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 36);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(255, 87, 34);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // contentPanel
            this.contentPanel.Location = new System.Drawing.Point(220, 230);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(960, 460);
            this.contentPanel.TabIndex = 200;

            // Assemble header
            this.headerPanel.Controls.Add(this.picLogo);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.lblSubtitle);

            // Add controls to form
            this.Controls.Add(this.leftNavPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.cardAvailableRooms);
            this.Controls.Add(this.cardReservationsToday);
            this.Controls.Add(this.cardTotalGuests);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.contentPanel);

            // DashboardForm
            this.BackColor = formBg;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";

            this.leftNavPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.cardAvailableRooms.ResumeLayout(false);
            this.cardAvailableRooms.PerformLayout();
            this.cardReservationsToday.ResumeLayout(false);
            this.cardReservationsToday.PerformLayout();
            this.cardTotalGuests.ResumeLayout(false);
            this.cardTotalGuests.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
