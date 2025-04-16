namespace Team3.DatabaseServices.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Service for managing drug database operations.
    /// </summary>
    public class DrugDatabaseService : IDrugDatabaseService
    {
        private readonly string dbConnString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugDatabaseService"/> class.
        /// </summary>
        /// <param name="dbConnString">The database connection string.</param>
        public DrugDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        /// <summary>
        /// Gets a drug by its ID from the database.
        /// </summary>
        /// <param name="Id">Drug ID.</param>
        /// <returns>Drug.</returns>
        /// <exception cref="Exception">Throws an error.</exception>
        public Drug GetDrugById(int Id)
        {
            const string query = "SELECT * FROM drugs WHERE id = @id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", Id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Drug(reader.GetString(1), reader.GetString(2));
                        }
                        else
                        {
                            throw new Exception("Drug not found");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error getting drug", exception);
            }
        }
    }
}
