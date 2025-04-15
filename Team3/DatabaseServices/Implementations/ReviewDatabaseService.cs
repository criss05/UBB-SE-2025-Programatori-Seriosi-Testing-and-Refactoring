namespace Team3.DatabaseServices.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Service for managing reviews in the database.
    /// </summary>
    public class ReviewDatabaseService : IReviewDatabaseService
    {
        private readonly string dbConnString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewDatabaseService"/> class.
        /// </summary>
        /// <param name="_dbConnString">The connection string for the database.</param>
        public ReviewDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        /// <summary>
        /// Adds a new review to the database.
        /// </summary>
        /// <param name="review">The review object to add.</param>
        public void AddNewReview(Review review)
        {
            const string query = "INSERT INTO Reviews (id, medicalrecord_id, message, nr_stars) VALUES (@id, @medicalrecord_id, @message, @nr_stars)";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", review.Id);
                    command.Parameters.AddWithValue("@medicalrecord_id", review.MedicalRecordId);
                    command.Parameters.AddWithValue("@message", review.Message);
                    command.Parameters.AddWithValue("@nr_stars", review.NrStars);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding review", e);
            }
        }

        /// <summary>
        /// Gets a review by the medical record ID.
        /// </summary>
        /// <param name="medicalRecordId">The ID of the medical record.</param>
        /// <returns>The review corresponding to the medical record ID.</returns>
        public Review GetReviewByMedicalRecordId(int medicalRecordId)
        {
            const string query = "SELECT * FROM reviews WHERE medicalrecord_id = @medicalrecord_id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@medicalrecord_id", medicalRecordId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Review(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3));
                    }
                    else
                    {
                        throw new Exception("Review not found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error getting review", e);
            }
        }
    }
}
