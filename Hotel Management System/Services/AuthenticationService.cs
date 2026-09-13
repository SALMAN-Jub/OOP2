using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Hotel_Management_System.Models;
using Hotel_Management_System.Database;

namespace Hotel_Management_System.Services
{
    public class AuthenticationService
    {
        private readonly string _connectionString;

        public AuthenticationService(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Parameterless ctor for consumers that rely on the application's configured connection string.
        // This will throw if the application has no valid configured connection string, surfacing a clear error.
        public AuthenticationService() : this(DatabaseConnection.ConnectionString)
        {
        }

        // PBKDF2 settings
        private const int Pbkdf2Iterations = 10000;
        private const int Pbkdf2SaltBytes = 16;
        private const int Pbkdf2HashBytes = 32;

        private static string GenerateSalt()
        {
            var salt = new byte[Pbkdf2SaltBytes];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private static string HashPasswordPbkdf2(string password, string saltBase64)
        {
            var salt = Convert.FromBase64String(saltBase64);
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Pbkdf2Iterations))
            {
                var hash = pbkdf2.GetBytes(Pbkdf2HashBytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Old SHA256 fallback for migration
        public static string HashPasswordSha256(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                var sb = new StringBuilder();
                foreach (var b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public User Authenticate(string username, string password)
        {
            var sql = "SELECT UserId, Username, PasswordHash, PasswordSalt, FullName, Role, IsActive, CreatedAt FROM Users WHERE Username=@u";
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var reader = DatabaseHelper.ExecuteReader(sql, conn, new SqlParameter("@u", username)))
                    {
                        if (!reader.Read())
                        {
                            Utilities.Logger.Log($"Authenticate: username '{username}' not found.");
                            return null;
                        }

                        var storedHash = reader["PasswordHash"]?.ToString();
                        var storedSalt = reader["PasswordSalt"] == DBNull.Value ? null : reader["PasswordSalt"]?.ToString();
                        if (string.IsNullOrEmpty(storedHash))
                        {
                            Utilities.Logger.Log($"Authenticate: username '{username}' has no stored password hash.");
                            return null;
                        }

                        var passwordValid = false;
                        if (!string.IsNullOrEmpty(storedSalt))
                        {
                            // New salted PBKDF2 path
                            try
                            {
                                var providedHash = HashPasswordPbkdf2(password, storedSalt);
                                passwordValid = string.Equals(storedHash, providedHash, StringComparison.Ordinal);
                            }
                            catch
                            {
                                passwordValid = false;
                            }
                        }
                        else
                        {
                            // Backward-compatible: verify legacy SHA256
                            var legacyHash = HashPasswordSha256(password);
                            if (string.Equals(storedHash, legacyHash, StringComparison.OrdinalIgnoreCase))
                            {
                                // Migrate user to PBKDF2
                                try
                                {
                                    var newSalt = GenerateSalt();
                                    var newHash = HashPasswordPbkdf2(password, newSalt);
                                    DatabaseHelper.ExecuteNonQuery("UPDATE Users SET PasswordHash=@ph, PasswordSalt=@ps WHERE UserId=@id",
                                        new SqlParameter("@ph", newHash), new SqlParameter("@ps", newSalt), new SqlParameter("@id", Convert.ToInt32(reader["UserId"])));
                                    passwordValid = true;
                                }
                                catch (Exception ex)
                                {
                                    Utilities.Logger.LogError("Failed to migrate user password to PBKDF2", ex);
                                    // still accept legacy password for this login
                                    passwordValid = true;
                                }
                            }
                        }

                        if (!passwordValid)
                        {
                            Utilities.Logger.Log($"Authenticate: username '{username}' provided invalid password.");
                            return null;
                        }

                        var user = new User
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            Username = reader["Username"].ToString(),
                            PasswordHash = storedHash,
                            PasswordSalt = reader["PasswordSalt"] == DBNull.Value ? null : reader["PasswordSalt"]?.ToString(),
                            FullName = reader["FullName"]?.ToString(),
                            Role = reader["Role"]?.ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                        };

                        if (!user.IsActive)
                        {
                            Utilities.Logger.Log($"Authenticate: username '{username}' is inactive.");
                            return null;
                        }

                        Utilities.Logger.Log($"Authenticate: username '{username}' authenticated successfully (UserId={user.UserId}).");
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Logger.LogError($"Authentication failed for '{username}'", ex);
                // Do not expose exception details to UI; return null to indicate authentication failure
            }

            return null;
        }

        public void CreateUserIfNotExists(string username, string password, string fullName, string role)
        {
            var exists = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Users WHERE Username=@u", new SqlParameter("@u", username)));
            if (exists == 0)
            {
                // If PasswordSalt column exists, create PBKDF2 salted hash. Otherwise fall back to legacy SHA256.
                if (DatabaseHelper.ColumnExists("Users", "PasswordSalt"))
                {
                    var salt = GenerateSalt();
                    var hash = HashPasswordPbkdf2(password, salt);
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO Users(Username,PasswordHash,PasswordSalt,FullName,Role,IsActive) VALUES(@u,@p,@s,@f,@r,1)",
                        new SqlParameter("@u", username),
                        new SqlParameter("@p", hash),
                        new SqlParameter("@s", salt),
                        new SqlParameter("@f", fullName),
                        new SqlParameter("@r", role)
                    );
                }
                else
                {
                    var hash = HashPasswordSha256(password);
                    DatabaseHelper.ExecuteNonQuery(
                        "INSERT INTO Users(Username,PasswordHash,FullName,Role,IsActive) VALUES(@u,@p,@f,@r,1)",
                        new SqlParameter("@u", username),
                        new SqlParameter("@p", hash),
                        new SqlParameter("@f", fullName),
                        new SqlParameter("@r", role)
                    );
                }
            }
        }
    }
}
