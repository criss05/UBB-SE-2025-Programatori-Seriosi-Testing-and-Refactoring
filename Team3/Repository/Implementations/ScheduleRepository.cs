// <copyright file="ScheduleRepository.cs" company="PlaceholderCompany">
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
    /// Repository for managing schedule data.
    /// </summary>
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public ScheduleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Get the schedules from the database.
        /// </summary>
        /// <returns>The list of schedules.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public List<Schedule> GetAllSchedules()
        {
            const string query = "SELECT ScheduleId, ScheduleWorkDay, DoctorId, ShiftTypeId FROM Schedule;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    List<Schedule> schedules = new List<Schedule>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(new Schedule(
                               reader.GetInt32(0),
                               DateOnly.FromDateTime(reader.GetDateTime(1)),
                               reader.GetInt32(2),
                               reader.GetInt32(3)));
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
