using System;
using Microsoft.Data.SqlClient;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;

namespace Team3.DatabaseServices.Implementations
{
    public class PatientDatabaseService : IPatientDatabaseService
    {
        private readonly string dbConnString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientDatabaseService"/> class.
        /// </summary>
        public PatientDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        /// <summary>
        /// Gets a patient by their ID.
        /// </summary>
        /// <param name="id">The patient ID.</param>
        /// <returns>A <see cref="Patient"/> object.</returns>
        public Patient GetPatientById(int id)
        {
            const string query = "SELECT * FROM Patients WHERE id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Patient(
                                    (int)reader[1]
                                );
                            }
                        }
                    }
                }

                throw new Exception("Patient not found");
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving patient", e);
            }
        }
    }
}
