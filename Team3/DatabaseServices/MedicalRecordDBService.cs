using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Team3.Entities;

namespace Team3.Models
{
    public class MedicalRecordDBService
    {
        private static MedicalRecordDBService? _instance;
        private readonly Config _config;

        private static readonly object _lock = new object();

        private MedicalRecordDBService()
        {
            _config = Config.Instance;
        }

        public static MedicalRecordDBService Instance
        {
            get
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MedicalRecordDBService();
                    }
                    return _instance;
                }
            }
        }




        // maybe we don't need this
        
        public MedicalRecord GetMedicalRecord(int id)
        {
            const string query = "SELECT * FROM medicalrecords WHERE id = @id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.CONNECTION))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return new MedicalRecord((int)reader[0], (int)reader[1], (int)reader[2], (DateTime)reader[3]); 
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
