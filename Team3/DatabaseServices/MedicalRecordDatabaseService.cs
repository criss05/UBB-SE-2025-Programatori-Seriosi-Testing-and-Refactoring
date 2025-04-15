using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class MedicalRecordDatabaseService : IMedicalRecordDatabaseService
    {
        private readonly string dbConnString;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalRecordDatabaseService"/> class.
        /// </summary>
        /// <param name="dbConnString">The database connection string.</param>
        public MedicalRecordDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            const string query = "SELECT * FROM medicalrecords WHERE id = @id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new MedicalRecord(
                            (int)reader[0],
                            (int)reader[1],
                            (int)reader[2],
                            (DateTime)reader[3]
                        );
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving medical record", e);
            }
        }
    }
}
