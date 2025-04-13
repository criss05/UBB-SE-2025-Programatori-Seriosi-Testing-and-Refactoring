using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class RoomDatabaseService : IRoomDatabaseService
    {
        private static RoomDatabaseService? instance;
        private readonly Config config;

        private RoomDatabaseService()
        {
            config = Config.Instance;
        }

        public static RoomDatabaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomDatabaseService();
                }
                return instance;
            }
        }

        public List<Room> GetRooms()
        {
            const string query = "SELECT RoomId, DepartmentId FROM Room;";
            List<Room> rooms = new List<Room>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
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
