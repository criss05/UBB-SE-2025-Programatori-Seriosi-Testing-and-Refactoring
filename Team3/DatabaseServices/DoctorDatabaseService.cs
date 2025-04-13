// <copyright file="DoctorDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Service for interacting with the doctor database.
    /// </summary>
    public class DoctorDatabaseService : IDoctorDatabaseService
    {
        private static readonly object LockObject = new object();
        private static DoctorDatabaseService? instance;
        private readonly Config config;

        private DoctorDatabaseService()
        {
            this.config = Config.Instance;
        }

        /// <summary>
        /// Gets the singleton instance of the DoctorDatabaseService class.
        /// </summary>
        public static DoctorDatabaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (LockObject)
                    {
                        if (instance == null)
                        {
                            instance = new DoctorDatabaseService();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Get all doctors from the database.
        /// </summary>
        /// <param name="id">Id of doctor.</param>
        /// <returns>The doctor.</returns>
        /// <exception cref="Exception">Throws an error.</exception>
        public Doctor GetDoctorById(int id)
        {
            const string query = "SELECT * FROM doctors WHERE id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Doctor((int)reader[0], (int)reader[1]);
                            }
                        }
                    }
                }

                throw new Exception("Doctor not found");
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving doctor", e);
            }
        }
    }
}
