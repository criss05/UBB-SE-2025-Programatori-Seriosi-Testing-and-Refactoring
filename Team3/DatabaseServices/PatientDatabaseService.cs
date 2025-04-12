using System;
using System.Data.SqlClient;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class PatientDatabaseService : IPatientDBService
    {
        private static PatientDatabaseService? _instance;
        private static readonly object _lock = new object();
        private readonly Config _config;
        private PatientDatabaseService() {
            _config = Config.Instance;
        }
        public static PatientDatabaseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new PatientDatabaseService();
                        }
                    }
                }
                return _instance;
            }
        }

        //public Patient GetPatientByUserId(int userId)
        //{
        //    const string query = "SELECT user_id FROM Patients WHERE user_id = @UserId";

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(Config.CONNECTION))
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@UserId", userId);

        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read()) // Check if data is available before accessing it
        //                    {
        //                        return new Patient(
        //                            reader.GetInt32(reader.GetOrdinal("user_id"))
        //                        );
        //                    }
        //                }
        //            }
        //        }

        //        throw new Exception("Patient not found");
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error retrieving patient", e);
        //    }
        //}


        public Patient GetPatientById(int id)
        {
            const string query = "SELECT * FROM Patients WHERE id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if data is available before accessing it
                            {
                                return new Patient(
                                    (int)reader[0], (int)reader[1]
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
