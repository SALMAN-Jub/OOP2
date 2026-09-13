using System;

namespace Hotel_Management_System.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime ExpectedCheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; }
        public string SpecialRequest { get; set; }
        public int? CreatedBy { get; set; }
    }
}
