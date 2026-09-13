using System;
using System.Data;
using System.Data.SqlClient;
using Hotel_Management_System.Services;

namespace Hotel_Management_System.Database
{
    public static class DatabaseInitializer
    {
        public static bool TestConnection(out string message)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    message = "Connection successful.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        // Check if database has required tables (simple check)
        public static bool CheckTablesExist(out string message)
        {
            try
            {
                var sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
                var dt = DatabaseHelper.ExecuteDataTable(sql);
                if (dt.Rows.Count == 0)
                {
                    message = "No tables found in database.";
                    return false;
                }
                message = "Tables exist.";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        // Seed basic data if missing (do not overwrite existing data)
        public static void EnsureSeedData()
        {
            try
            {
                // Seed default admin user if Users table exists and empty
                var dt = DatabaseHelper.ExecuteDataTable("SELECT COUNT(1) AS C FROM sys.tables WHERE name='Users'");
                if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
                {
                    var count = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Users"));
                    if (count == 0)
                    {
                        var auth = new AuthenticationService();
                        auth.CreateUserIfNotExists("admin", "admin123", "Administrator", "Admin");
                    }
                }
            }
            catch
            {
                // swallow errors here; Database scripts should be run manually if initialization fails
            }
        }
    }
}
