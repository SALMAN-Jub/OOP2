using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Hotel_Management_System.Database;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Services
{
    public class ReservationService
    {
        public IEnumerable<Reservation> GetAll()
        {
            var dt = DatabaseHelper.ExecuteDataTable("SELECT ReservationId, GuestId, RoomId, BookingDate, CheckInDate, ExpectedCheckOutDate, NumberOfGuests, Status, SpecialRequest, CreatedBy FROM Reservations");
            var list = new List<Reservation>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new Reservation
                {
                    ReservationId = Convert.ToInt32(r["ReservationId"]),
                    GuestId = Convert.ToInt32(r["GuestId"]),
                    RoomId = Convert.ToInt32(r["RoomId"]),
                    BookingDate = Convert.ToDateTime(r["BookingDate"]),
                    CheckInDate = Convert.ToDateTime(r["CheckInDate"]),
                    ExpectedCheckOutDate = Convert.ToDateTime(r["ExpectedCheckOutDate"]),
                    NumberOfGuests = Convert.ToInt32(r["NumberOfGuests"]),
                    Status = r["Status"].ToString(),
                    SpecialRequest = r["SpecialRequest"].ToString(),
                    CreatedBy = r["CreatedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["CreatedBy"])
                });
            }
            return list;
        }

        public Reservation Get(int id)
        {
            var dt = DatabaseHelper.ExecuteDataTable("SELECT ReservationId, GuestId, RoomId, BookingDate, CheckInDate, ExpectedCheckOutDate, NumberOfGuests, Status, SpecialRequest, CreatedBy FROM Reservations WHERE ReservationId=@id", new SqlParameter("@id", id));
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new Reservation
            {
                ReservationId = Convert.ToInt32(r["ReservationId"]),
                GuestId = Convert.ToInt32(r["GuestId"]),
                RoomId = Convert.ToInt32(r["RoomId"]),
                BookingDate = Convert.ToDateTime(r["BookingDate"]),
                CheckInDate = Convert.ToDateTime(r["CheckInDate"]),
                ExpectedCheckOutDate = Convert.ToDateTime(r["ExpectedCheckOutDate"]),
                NumberOfGuests = Convert.ToInt32(r["NumberOfGuests"]),
                Status = r["Status"].ToString(),
                SpecialRequest = r["SpecialRequest"].ToString(),
                CreatedBy = r["CreatedBy"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["CreatedBy"])
            };
        }

        public void Create(int guestId, int roomId, DateTime checkInDate, DateTime expectedCheckOutDate, int numberOfGuests, string status, string specialRequest, int? createdBy)
        {
            DatabaseHelper.ExecuteNonQuery(
                @"INSERT INTO Reservations (GuestId, RoomId, BookingDate, CheckInDate, ExpectedCheckOutDate, NumberOfGuests, Status, SpecialRequest, CreatedBy)
                  VALUES (@g,@r,GETDATE(),@ci,@co,@ng,@st,@sr,@cb)",
                new SqlParameter("@g", guestId),
                new SqlParameter("@r", roomId),
                new SqlParameter("@ci", checkInDate),
                new SqlParameter("@co", expectedCheckOutDate),
                new SqlParameter("@ng", numberOfGuests),
                new SqlParameter("@st", status ?? "Booked"),
                new SqlParameter("@sr", specialRequest ?? string.Empty),
                new SqlParameter("@cb", (object)createdBy ?? DBNull.Value)
            );
        }

        public void Update(int id, int guestId, int roomId, DateTime checkInDate, DateTime expectedCheckOutDate, int numberOfGuests, string status, string specialRequest)
        {
            DatabaseHelper.ExecuteNonQuery(
                @"UPDATE Reservations SET GuestId=@g, RoomId=@r, CheckInDate=@ci, ExpectedCheckOutDate=@co, NumberOfGuests=@ng, Status=@st, SpecialRequest=@sr WHERE ReservationId=@id",
                new SqlParameter("@g", guestId),
                new SqlParameter("@r", roomId),
                new SqlParameter("@ci", checkInDate),
                new SqlParameter("@co", expectedCheckOutDate),
                new SqlParameter("@ng", numberOfGuests),
                new SqlParameter("@st", status ?? "Booked"),
                new SqlParameter("@sr", specialRequest ?? string.Empty),
                new SqlParameter("@id", id)
            );
        }

        public void Delete(int id)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Reservations WHERE ReservationId=@id", new SqlParameter("@id", id));
        }
    }
}
