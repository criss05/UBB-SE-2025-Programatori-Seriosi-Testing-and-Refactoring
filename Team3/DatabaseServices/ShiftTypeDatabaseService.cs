﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class ShiftTypeDatabaseService : IShiftTypeDatabaseService
    {
        private static ShiftTypeDatabaseService? instance;
        private readonly Config config;

        private ShiftTypeDatabaseService()
        {
            config = Config.Instance;
        }

        public static ShiftTypeDatabaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShiftTypeDatabaseService();
                }
                return instance;
            }
        }

        // Get all shift types
        public List<ShiftType> GetAllShiftTypes()
        {
            const string query = "SELECT ShiftTypeId, ShiftTypeStartTime, ShiftTypeEndTime FROM ShiftType;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    List<ShiftType> shiftTypes = new List<ShiftType>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shiftTypes.Add(new ShiftType(
                                reader.GetInt32(0), // ShiftTypeId
                                TimeOnly.FromDateTime(reader.GetDateTime(1)), // StartTime
                                TimeOnly.FromDateTime(reader.GetDateTime(2))  // EndTime
                            ));
                        }
                    }
                    return shiftTypes;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error getting shift types", e);
            }
        }

        // Get a single shift type by ID
        public ShiftType? GetShiftType(int shiftTypeId)
        {
            const string query = "SELECT ShiftTypeId, ShiftTypeStartTime, ShiftTypeEndTime FROM ShiftType WHERE ShiftTypeId = @ShiftTypeId;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShiftTypeId", shiftTypeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // If a result is found
                            {
                                return new ShiftType(
                                    reader.GetInt32(0), // ShiftTypeId
                                    TimeOnly.FromDateTime(reader.GetDateTime(1)), // StartTime
                                    TimeOnly.FromDateTime(reader.GetDateTime(2))  // EndTime
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error retrieving shift type with ID {shiftTypeId}", e);
            }

            return null; // Return null if no shift type is found
        }
    }
}
