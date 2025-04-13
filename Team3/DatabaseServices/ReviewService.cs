using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class ReviewService : IReviewService
    {
        private static ReviewService? instance;
        private static readonly object LockObject = new object();
        private readonly Config config;
        private ReviewService()
        {
            config = Config.Instance;
        }
        public static ReviewService Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = new ReviewService();
                    }
                }
                return instance;
            }
        }
        
        public void addNewReview(Review review)
        {
            const string query = "INSERT INTO Reviews (id, medicalrecord_id, message, nr_stars) VALUES (@id, @medicalrecord_id, @message, @nr_stars)";
            try
            {
                SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", review.Id);
                command.Parameters.AddWithValue("@medicalrecord_id", review.MedicalRecordId);
                command.Parameters.AddWithValue("@message", review.Message);
                command.Parameters.AddWithValue("@nr_stars", review.NrStars);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error adding review", e);
            }
        }
        public Review GetReviewByMedicalRecordId(int medicalRecordId)
        {
            const string query = "SELECT * FROM reviews WHERE medicalrecord_id = @medicalrecord_id;";

            try
            {
                SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING);

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@medicalrecord_id", medicalRecordId);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                return new Review(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3));



            }
            catch (Exception e)
            {
                throw new Exception("Error getting review", e);
            }

        }

    }
}
