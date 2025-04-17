// <copyright file="RoomRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Team3.Models;
    using Team3.Repository.Interfaces;

    /// <summary>
    /// Repository for managing room data.
    /// </summary>
    public class RoomRepository : IRoomRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public RoomRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets the rooms from the database.
        /// </summary>
        /// <returns>The list of rooms.</returns>
        /// <exeption cref="Exception">Throws error if failed.</exeption>
        public List<Room> GetRooms()
        {
            const string query = "SELECT RoomId, DepartmentId FROM Room;";
            List<Room> rooms = new List<Room>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(new Room(
                                reader.GetInt32(0),
                                reader.GetInt32(1)));
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

        /// <summary>
        /// Add a new room.
        /// </summary>
        /// <param name="room">the room to be added.</param>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public void AddRoom(Room room)
        {
            const string query = "INSERT INTO Room (DepartmentId) VALUES (@DepartmentId);";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
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

        /// <summary>
        /// Get a room by department id.
        /// </summary>
        /// <param name="departmentId">The id of the department.</param>
        /// <returns>The room for the department.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public Room GetRoom(int departmentId)
        {
            const string query = "SELECT DepartmentId FROM Room WHERE DepartmentId = @DepartmentId;";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
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
                                reader.GetInt32(1));
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
