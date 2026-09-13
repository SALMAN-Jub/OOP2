using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Hotel_Management_System.Database;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Services
{
    public class GuestService
    {
        public IEnumerable<Guest> GetAllGuests()
        {
            var dt = DatabaseHelper.ExecuteDataTable("SELECT GuestId, FullName, Phone, Email, CreatedAt FROM Guests");
            var list = new List<Guest>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new Guest
                {
                    GuestId = Convert.ToInt32(r["GuestId"]),
                    FullName = r["FullName"].ToString(),
                    Phone = r["Phone"].ToString(),
                    Email = r["Email"].ToString(),
                    CreatedAt = Convert.ToDateTime(r["CreatedAt"])
                });
            }
            return list;
        }

        public Guest GetGuest(int guestId)
        {
            var dt = DatabaseHelper.ExecuteDataTable("SELECT GuestId, FullName, Phone, Email, CreatedAt FROM Guests WHERE GuestId=@id", new SqlParameter("@id", guestId));
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new Guest
            {
                GuestId = Convert.ToInt32(r["GuestId"]),
                FullName = r["FullName"].ToString(),
                Phone = r["Phone"].ToString(),
                Email = r["Email"].ToString(),
                CreatedAt = Convert.ToDateTime(r["CreatedAt"])
            };
        }

        public void CreateGuest(string fullName, string phone, string email)
        {
            DatabaseHelper.ExecuteNonQuery("INSERT INTO Guests(FullName, Phone, Email) VALUES(@n,@p,@e)", new SqlParameter("@n", fullName), new SqlParameter("@p", phone ?? (object)DBNull.Value), new SqlParameter("@e", email ?? (object)DBNull.Value));
        }

        public void UpdateGuest(int guestId, string fullName, string phone, string email)
        {
            DatabaseHelper.ExecuteNonQuery("UPDATE Guests SET FullName=@n, Phone=@p, Email=@e WHERE GuestId=@id", new SqlParameter("@n", fullName), new SqlParameter("@p", phone ?? (object)DBNull.Value), new SqlParameter("@e", email ?? (object)DBNull.Value), new SqlParameter("@id", guestId));
        }

        public void DeleteGuest(int guestId)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Guests WHERE GuestId=@id", new SqlParameter("@id", guestId));
        }
    }
}
