using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.Entities;

namespace Team3.Models
{
    public class RoomDBService
    {
        private static RoomDBService? _instance;
        private readonly Config _config;

        private RoomDBService()
        {
            _config = Config.Instance;
        }

        public static RoomDBService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RoomDBService();
                }
                return _instance;
            }
        }

        public List<Room> GetRooms()
        {
            const string query = "SELECT RoomId, DepartmentId FROM Room;";
            List<Room> rooms = new List<Room>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.CONNECTION))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(new Room(
                                reader.GetInt32(0), // RoomId
                                reader.GetInt32(1)  // DepartmentId
                            ));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error getting rooms", e);
            }

            return rooms;
        }
    }
}
