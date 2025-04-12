using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class ScheduleDatabaseService : IScheduleDatabaseService
    {
        private static ScheduleDatabaseService? _instance;
        private readonly Config _config;

        private ScheduleDatabaseService()
        {
            _config = Config.Instance;
        }

        public static ScheduleDatabaseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScheduleDatabaseService();
                }
                return _instance;
            }
        }

        public List<Schedule> GetAllSchedules()
        {
            const string query = "SELECT ScheduleId, ScheduleWorkDay, DoctorId, ShiftTypeId FROM Schedule;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    List<Schedule> schedules = new List<Schedule>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(new Schedule(
                               reader.GetInt32(0),  // ScheduleId
                               DateOnly.FromDateTime(reader.GetDateTime(1)),  // Fixed: Convert to DateOnly
                               reader.GetInt32(2),  // DoctorId
                               reader.GetInt32(3)   // ShiftTypeId
                            ));
                        }
                    }
                    return schedules;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error getting schedules", e);
            }
        }
    }
}
