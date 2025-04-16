using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;

namespace Team3.DatabaseServices.Implementations
{
    public class RoomDatabaseService : IRoomDatabaseService
    {
        private readonly string dbConnString;

        public RoomDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        public List<Room> GetRooms()
        {
            const string query = "SELECT RoomId, DepartmentId FROM Room;";
            List<Room> rooms = new List<Room>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(new Room(
                                reader.GetInt32(0), // Id
                                reader.GetInt32(1)  // DepartmentId
                            ));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error getting rooms", exception);
            }

            return rooms;
        }
    }
}
