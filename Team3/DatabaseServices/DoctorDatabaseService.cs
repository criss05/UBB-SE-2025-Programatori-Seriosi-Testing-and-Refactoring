
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class DoctorDatabaseService : IDoctorDatabaseService
    {
        /// <summary>
        /// Singleton instance of the ChatDatabaseService class.
        /// </summary>

        private static DoctorDatabaseService? _instance;
        /// <summary>
        /// Lock object used to ensure thread safety when accessing the singleton instance.
        /// </summary>

        private static readonly object _lock = new object();
        private readonly Config _config;

        private DoctorDatabaseService() {
            _config = Config.Instance;
        }


        public static DoctorDatabaseService Instance
        {
            get
            {
                if (_instance == null)
                {

                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoctorDatabaseService();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// Get all doctors from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Doctor GetDoctorById(int id)
        {
            const string query = "SELECT * FROM doctors WHERE id = @id";
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
                            if (reader.Read())
                            {
                                return new Doctor((int)reader[0], (int)reader[1]);
                            }
                        }
                    }
                }
                throw new Exception("Doctor not found");
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving doctor", e);
            }
        }
    }
}
