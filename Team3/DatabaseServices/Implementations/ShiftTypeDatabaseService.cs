using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;

namespace Team3.DatabaseServices.Implementations
{
    public class ShiftTypeDatabaseService : IShiftTypeDatabaseService
    {
        private readonly string dbConnString;

        public ShiftTypeDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        // Get all shift types
        public List<ShiftType> GetAllShiftTypes()
        {
            const string query = "SELECT ShiftTypeId, ShiftTypeStartTime, ShiftTypeEndTime FROM ShiftType;";
            List<ShiftType> shiftTypes = new List<ShiftType>();

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
                            shiftTypes.Add(new ShiftType(
                                TimeOnly.FromDateTime(reader.GetDateTime(1)), // StartTime
                                TimeOnly.FromDateTime(reader.GetDateTime(2))  // EndTime
                            ));
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

        // Get a single shift type by ID
        public ShiftType? GetShiftType(int shiftTypeId)
        {
            const string query = "SELECT ShiftTypeId, ShiftTypeStartTime, ShiftTypeEndTime FROM ShiftType WHERE ShiftTypeId = @ShiftTypeId;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
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

            return null;
        }
    }
}
