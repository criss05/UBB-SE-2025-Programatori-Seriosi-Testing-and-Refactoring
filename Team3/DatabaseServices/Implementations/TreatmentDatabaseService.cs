﻿namespace Team3.DatabaseServices.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Service for managing treatment database operations.
    /// </summary>
    public class TreatmentDatabaseService : ITreatmentDatabaseService
    {
        private readonly string dbConnString;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentDatabaseService"/> class.
        /// </summary>
        /// <param name="_dbConnString">The database connection string.</param>
        public TreatmentDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        /// <summary>
        /// Adds a new treatment to the database.
        /// </summary>
        /// <param name="treatment">The treatment to add.</param>
        public void AddNewTreatment(Treatment treatment)
        {
            const string query = "INSERT INTO treatments(id, medicalrecord_id) values (@id , @medicalrecord_id)";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", treatment.Id);
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
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
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
