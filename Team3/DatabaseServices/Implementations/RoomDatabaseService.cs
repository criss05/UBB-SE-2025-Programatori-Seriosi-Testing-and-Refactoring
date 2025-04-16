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

        public void AddRoom(Room room)
        {
            const string query = "INSERT INTO Room (DepartmentId) VALUES (@DepartmentId);";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepartmentId", room.DepartmentId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error adding room", exception);
            }
        }

        public Room GetRoom(int departmentId)
        {
            const string query = "SELECT DepartmentId FROM Room WHERE DepartmentId = @DepartmentId;";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepartmentId", departmentId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Room(
                                reader.GetInt32(0),
                                reader.GetInt32(1)
                            );
                        }
                    }
                }

                throw new Exception("Room not found");
            }
            catch (Exception exception)
            {
                throw new Exception("Error getting room", exception);
            }
        }
    }
}
