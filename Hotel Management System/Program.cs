using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Management_System.Database;
using Hotel_Management_System.Utilities;

namespace Hotel_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Quick DB sanity check and seed default data if needed
            try
            {
                if (!DatabaseInitializer.TestConnection(out var msg))
                {
                    MessageBox.Show($"Database connection failed: {msg}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Log($"Startup: DB connectivity check failed: {msg}");
                    return; // abort startup
                }

                // Ensure basic seed data (admin user) exists
                try { DatabaseInitializer.EnsureSeedData(); }
                catch (Exception ex) { Logger.LogError("Startup: EnsureSeedData failed", ex); }
            }
            catch (Exception ex)
            {
                Logger.LogError("Startup: DB initialization failed", ex);
                MessageBox.Show($"Database initialization error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Start with login form
            Application.Run(new Forms.LoginForm());
        }
    }
}
