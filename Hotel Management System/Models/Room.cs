using System;

namespace Hotel_Management_System.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public int? FloorNumber { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
