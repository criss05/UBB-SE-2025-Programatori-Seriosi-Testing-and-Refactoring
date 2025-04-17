// <copyright file="TreatmentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.Models;
    using Team3.Repository.Interfaces;

    /// <summary>
    /// Service for managing treatment database operations.
    /// </summary>
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public TreatmentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Adds a new treatment to the database.
        /// </summary>
        /// <param name="treatment">The treatment to add.</param>
        public void AddNewTreatment(Treatment treatment)
        {
            const string query = "INSERT INTO treatments(medicalrecord_id) values (@medicalrecord_id)";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@medicalrecord_id", treatment.MedicalRecordId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error adding treatment", exception);
            }
        }

        /// <summary>
        /// Gets a treatment by its medical record id.
        /// </summary>
        /// <param name="mrId">The medical record ID.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int mrId)
        {
            const string query = "SELECT * FROM treatments WHERE medicalrecord_id = @medicalrecord_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@medicalrecord_id", mrId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Treatment((int)reader[0], (int)reader[1]);
                            }
                        }
                    }
                }

                throw new Exception("Treatment not found");
            }
            catch (Exception exception)
            {
                throw new Exception("Error retrieving treatment", exception);
            }
        }
    }
}
