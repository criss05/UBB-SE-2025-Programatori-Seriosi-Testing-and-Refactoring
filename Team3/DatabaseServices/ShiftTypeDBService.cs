using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.DBServices;
using Team3.Models;

namespace Team3.DBServices
{
    public class ShiftTypeDBService : IShiftTypeDBService
    {
        private static ShiftTypeDBService? _instance;
        private readonly Config _config;

        private ShiftTypeDBService()
        {
            _config = Config.Instance;
        }

        public static ShiftTypeDBService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShiftTypeDBService();
                }
                return _instance;
            }
        }

        // Get all shift types
        public List<ShiftType> GetShiftTypes()
        {
            const string query = "SELECT ShiftTypeId, ShiftTypeStartTime, ShiftTypeEndTime FROM ShiftType;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.CONNECTION))
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
                using (SqlConnection connection = new SqlConnection(Config.CONNECTION))
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
