using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Xml;

namespace Hotel_Management_System.Database
{
    public static class DatabaseConnection
    {
        private static string _connectionString = ReadConnectionString();

        // Expose connection string for callers that need it or update it dynamically
        public static string ConnectionString
        {
            get => _connectionString ?? ReadConnectionString();
            set => _connectionString = value;
        }

        public static void SetConnectionString(string newConnStr)
        {
            _connectionString = newConnStr;
        }

        public static void ResetToDefault()
        {
            _connectionString = ReadConnectionString();
        }

        public static string GetCurrentServerAndDatabase()
        {
            try
            {
                var cs = ConnectionString;
                if (string.IsNullOrWhiteSpace(cs)) return "No Connection";
                var builder = new SqlConnectionStringBuilder(cs);
                return $"{builder.DataSource} / {builder.InitialCatalog}";
            }
            catch
            {
                return "Configured";
            }
        }

        public static bool TestConnection(string connStr, out string errorMessage, out int tableCount)
        {
            tableCount = 0;
            errorMessage = null;
            try
            {
                if (string.IsNullOrWhiteSpace(connStr))
                {
                    errorMessage = "Connection string is empty.";
                    return false;
                }
                var csb = new SqlConnectionStringBuilder(connStr);
                if (csb.ConnectTimeout == 15 || csb.ConnectTimeout == 0)
                {
                    csb.ConnectTimeout = 5;
                }
                using (var conn = new SqlConnection(csb.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
                        tableCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private static string ReadConnectionString()
        {
            try
            {
                // 1) Environment variable override (highest priority)
                var env = Environment.GetEnvironmentVariable("HOTELDB_CONNECTION_STRING");
                if (!string.IsNullOrWhiteSpace(env))
                    return env;

                // 2) Try runtime configuration file (e.g., AppName.exe.config)
                try
                {
                    var runtimeConfigPath = AppDomain.CurrentDomain.SetupInformation?.ConfigurationFile;
                    if (!string.IsNullOrWhiteSpace(runtimeConfigPath) && File.Exists(runtimeConfigPath))
                    {
                        var docRuntime = new XmlDocument();
                        docRuntime.Load(runtimeConfigPath);
                        var nodeRuntime = docRuntime.SelectSingleNode("/configuration/connectionStrings/add[@name='HotelDB']");
                        if (nodeRuntime?.Attributes != null)
                        {
                            var attrRuntime = nodeRuntime.Attributes["connectionString"];
                            if (!string.IsNullOrWhiteSpace(attrRuntime?.Value))
                                return attrRuntime.Value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceWarning($"Failed to read runtime config for connection string: {ex.Message}");
                }

                // 4) Fallback: attempt to read App.config shipped next to the executable
                var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.config");
                if (!File.Exists(configPath)) return null;
                var doc = new XmlDocument();
                doc.Load(configPath);
                var node = doc.SelectSingleNode("/configuration/connectionStrings/add[@name='HotelDB']");
                if (node?.Attributes == null) return null;
                var attr = node.Attributes["connectionString"];
                return attr?.Value;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError($"Failed to read connection string: {ex}");
                return null;
            }
        }

        public static SqlConnection GetConnection()
        {
            var cs = ConnectionString;
            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException("Database connection string 'HotelDB' not found. Provide it via App.config/Exe.config, environment variable 'HOTELDB_CONNECTION_STRING', or project settings.");

            var conn = new SqlConnection(cs);
            // Set a reasonable connect timeout if not present
            if (!cs.ToLower().Contains("connect timeout") && !cs.ToLower().Contains("connection timeout"))
            {
                conn.ConnectionString = conn.ConnectionString + ";Connect Timeout=5";
            }
            return conn;
        }

        /// <summary>
        /// Attempts to open the provided SqlConnection with a small retry/backoff.
        /// </summary>
        public static void OpenWithRetry(SqlConnection conn, int maxAttempts = 3, int delayMs = 300)
        {
            if (conn == null) throw new ArgumentNullException(nameof(conn));
            int attempts = 0;
            while (true)
            {
                try
                {
                    attempts++;
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    return;
                }
                catch (Exception) when (attempts < maxAttempts)
                {
                    Thread.Sleep(delayMs);
                    delayMs *= 2; // exponential backoff
                }
            }
        }
    }
}
