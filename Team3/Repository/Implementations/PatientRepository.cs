// <copyright file="PatientRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Repository for managing patient data in the database.
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRepository"/> class.
        /// </summary>
        /// <param name="connectionString">Connection string to the database.</param>
        public PatientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets a patient by their ID.
        /// </summary>
        /// <param name="patientId">The patient ID.</param>
        /// <returns>A <see cref="Patient"/> object.</returns>
        public Patient GetPatientById(int patientId)
        {
            const string query = "SELECT * FROM Patients WHERE id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", patientId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Patient(
                                    (int)reader[0],
                                    (int)reader[1]);
                            }
                        }
                    }
                }

                throw new Exception("Patient not found");
            }
            catch (Exception error)
            {
                throw new Exception("Error retrieving patient", error);
            }
        }

        /// <summary>
        /// add a patient.
        /// </summary>
        /// <param name="patient">The patient to be added.</param>
        public void AddPatient(Patient patient)
        {
            const string query = "INSERT INTO Patients(userId) VALUES (@userId)";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", patient.UserId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error adding patient", error);
            }
        }
    }
}
