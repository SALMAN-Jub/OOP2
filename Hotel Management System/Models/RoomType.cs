using System;

namespace Hotel_Management_System.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
    }
}
