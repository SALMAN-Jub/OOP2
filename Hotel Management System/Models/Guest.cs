using System;

namespace Hotel_Management_System.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string NationalId { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
