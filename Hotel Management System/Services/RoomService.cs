using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Hotel_Management_System.Database;
using Hotel_Management_System.Models;

namespace Hotel_Management_System.Services
{
    public class RoomService
    {
        public IEnumerable<Room> GetAllRooms()
        {
            var dt = DatabaseHelper.ExecuteDataTable("SELECT RoomId, RoomNumber, RoomTypeId, FloorNumber, ISNULL(Status,'') AS Status, ISNULL(Description,'') AS Description FROM Rooms");
            var list = new List<Room>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new Room
                {
                    RoomId = Convert.ToInt32(r["RoomId"]),
                    RoomNumber = r["RoomNumber"].ToString(),
                    RoomTypeId = Convert.ToInt32(r["RoomTypeId"]),
                    FloorNumber = r["FloorNumber"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["FloorNumber"]),
                    Status = r["Status"].ToString(),
                    Description = r["Description"].ToString()
                });
            }
            return list;
        }

        public Room GetRoom(int roomId)
        {
            var dt = DatabaseHelper.ExecuteDataTable("SELECT RoomId, RoomNumber, RoomTypeId, FloorNumber, ISNULL(Status,'') AS Status, ISNULL(Description,'') AS Description FROM Rooms WHERE RoomId=@id", new SqlParameter("@id", roomId));
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new Room
            {
                RoomId = Convert.ToInt32(r["RoomId"]),
                RoomNumber = r["RoomNumber"].ToString(),
                RoomTypeId = Convert.ToInt32(r["RoomTypeId"]),
                FloorNumber = r["FloorNumber"] == DBNull.Value ? (int?)null : Convert.ToInt32(r["FloorNumber"]),
                Status = r["Status"].ToString(),
                Description = r["Description"].ToString()
            };
        }

        public void CreateRoom(string roomNumber, int roomTypeId, int? floorNumber, string status, string description)
        {
            DatabaseHelper.ExecuteNonQuery("INSERT INTO Rooms(RoomNumber, RoomTypeId, FloorNumber, Status, Description) VALUES(@rn,@rt,@fl,@st,@ds)", new SqlParameter("@rn", roomNumber), new SqlParameter("@rt", roomTypeId), new SqlParameter("@fl", (object)floorNumber ?? DBNull.Value), new SqlParameter("@st", status ?? "Available"), new SqlParameter("@ds", description ?? string.Empty));
        }

        public void UpdateRoom(int roomId, string roomNumber, int roomTypeId, int? floorNumber, string status, string description)
        {
            DatabaseHelper.ExecuteNonQuery("UPDATE Rooms SET RoomNumber=@rn, RoomTypeId=@rt, FloorNumber=@fl, Status=@st, Description=@ds WHERE RoomId=@id", new SqlParameter("@rn", roomNumber), new SqlParameter("@rt", roomTypeId), new SqlParameter("@fl", (object)floorNumber ?? DBNull.Value), new SqlParameter("@st", status ?? "Available"), new SqlParameter("@ds", description ?? string.Empty), new SqlParameter("@id", roomId));
        }

        public void DeleteRoom(int roomId)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM Rooms WHERE RoomId=@id", new SqlParameter("@id", roomId));
        }
    }
}
