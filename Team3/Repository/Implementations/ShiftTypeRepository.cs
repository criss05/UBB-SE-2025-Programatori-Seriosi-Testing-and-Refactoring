// <copyright file="ShiftTypeRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Implementations
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Repository for managing shift types in the database.
    /// </summary>
    public class ShiftTypeRepository : IShiftTypeRepo
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftTypeRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>"
        public ShiftTypeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets all shift types from the database.
        /// </summary>
        /// <returns>The list of shifts with the given type.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public List<ShiftType> GetAllShiftTypes()
        {
            const string query = "SELECT ShiftTypeId, ShiftTypeStartTime, ShiftTypeEndTime FROM ShiftType;";
            List<ShiftType> shiftTypes = new List<ShiftType>();

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
                            shiftTypes.Add(new ShiftType(
                                reader.GetInt32(0), // Id
                                TimeOnly.FromDateTime(reader.GetDateTime(1)), // StartTime
                                TimeOnly.FromDateTime(reader.GetDateTime(2))));
                        }
                    }
                }

                return shiftTypes;
            }
            catch (Exception exception)
            {
                throw new Exception("Error getting shift types", exception);
            }
        }

        /// <summary>
        /// Gets a specific shift type by its ID.
        /// </summary>
        /// <param name="shiftTypeId">The id of the shift type.</param>
        /// <returns>The shift type with the given id.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public ShiftType? GetShiftType(int shiftTypeId)
        {
            const string query = "SELECT ShiftTypeId, ShiftTypeStartTime, ShiftTypeEndTime FROM ShiftType WHERE ShiftTypeId = @ShiftTypeId;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShiftTypeId", shiftTypeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ShiftType(
                                    reader.GetInt32(0), // Id
                                    TimeOnly.FromDateTime(reader.GetDateTime(1)), // StartTime
                                    TimeOnly.FromDateTime(reader.GetDateTime(2)));
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception($"Error retrieving shift type with ID {shiftTypeId}", error);
            }

            return null;
        }
    }
}
