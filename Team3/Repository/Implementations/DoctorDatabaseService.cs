// <copyright file="DoctorDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Service for interacting with the doctor database.
    /// </summary>
    public class DoctorDatabaseService : IDoctorDatabaseService
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorDatabaseService"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public DoctorDatabaseService(string connectionString)
        {
           this.connectionString = connectionString;
        }

        /// <inheritdoc/>
        public Doctor GetDoctorById(int doctorId)
        {
            const string query = "SELECT * FROM doctors WHERE id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", doctorId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Doctor((int)reader[1]);
                            }
                        }
                    }
                }

                throw new Exception("Doctor not found");
            }
            catch (Exception exception)
            {
                throw new Exception("Error retrieving doctor", exception);
            }
        }
    }
}
