namespace Team3.DatabaseServices.Implementations
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    public class ScheduleDatabaseService : IScheduleDatabaseService
    {
        private readonly string dbConnString;

        // Constructor that accepts the connection string
        public ScheduleDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        public List<Schedule> GetAllSchedules()
        {
            const string query = "SELECT ScheduleId, ScheduleWorkDay, DoctorId, ShiftTypeId FROM Schedule;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    List<Schedule> schedules = new List<Schedule>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(new Schedule(
                               reader.GetInt32(0), // Id
                               DateOnly.FromDateTime(reader.GetDateTime(1)),  // Fixed: Convert to DateOnly
                               reader.GetInt32(2),  // DoctorId
                               reader.GetInt32(3)   // ShiftTypeId
                            ));
                        }
                    }
                    return schedules;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error getting schedules", exception);
            }
        }
    }
}
