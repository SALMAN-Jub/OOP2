using System;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management_System.Database
{
    public static class DatabaseHelper
    {
        // Convenience overload: caller does not supply a connection; helper will create and own the connection.
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            return ExecuteReader(sql, null, parameters);
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static SqlDataReader ExecuteReader(string sql, SqlConnection conn1, params SqlParameter[] parameters)
        {
            // Use the provided connection if supplied; otherwise create one. Track ownership so we only dispose what we created.
            var ownsConnection = false;
            var conn = conn1;
            if (conn == null)
            {
                conn = DatabaseConnection.GetConnection();
                ownsConnection = true;
            }

            var cmd = new SqlCommand(sql, conn);
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            try
            {
                // Ensure the connection is open. If we created the connection, use CloseConnection so reader disposal closes it.
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                return cmd.ExecuteReader(ownsConnection ? CommandBehavior.CloseConnection : CommandBehavior.Default);
            }
            catch
            {
                try { cmd.Dispose(); } catch { }
                try { if (ownsConnection) conn.Dispose(); } catch { }
                throw;
            }
        }

        public static bool ColumnExists(string tableName, string columnName)
        {
            try
            {
                var dt = ExecuteDataTable("SELECT COUNT(1) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME=@t AND COLUMN_NAME=@c", new SqlParameter("@t", tableName), new SqlParameter("@c", columnName));
                if (dt.Rows.Count == 0) return false;
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
