// <copyright file="MedicalRecordDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.Repository.Interfaces;

    /// <summary>
    /// Service for managing medical records in the database.
    /// </summary>
    public class MedicalRecordRepository : IMedicalRecordDatabaseService
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalRecordRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public MedicalRecordRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Inserts a new medical record into the database.
        /// </summary>
        /// <param name="medicalRecordId">The id of the medical record.</param>
        /// <returns>The medical record with the given id.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public MedicalRecord GetMedicalRecordById(int medicalRecordId)
        {
            const string query = "SELECT * FROM medicalrecords WHERE id = @id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", medicalRecordId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new MedicalRecord(
                            (int)reader[0],
                            (int)reader[1],
                            (int)reader[2],
                            (DateTime)reader[3]);
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error retrieving medical record", error);
            }
        }
    }
}
