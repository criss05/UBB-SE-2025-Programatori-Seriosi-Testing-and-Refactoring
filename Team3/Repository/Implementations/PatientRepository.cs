using System;
using Microsoft.Data.SqlClient;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;

namespace Team3.DatabaseServices.Implementations
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string dbConnString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRepository"/> class.
        /// </summary>
        public PatientRepository(string _dbConnString)
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
                                    (int)reader[0],
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

        /// <summary>
        /// add a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public void AddPatient(Patient patient)
        {
            const string query = "INSERT INTO Patients(userId) VALUES (@userId)";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", patient.UserId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding patient", e);
            }
        }
    }
}
