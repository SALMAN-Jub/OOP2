using System;

namespace Hotel_Management_System.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        // New: per-user salt for PBKDF2 hashing (nullable for backward compatibility)
        public string PasswordSalt { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
