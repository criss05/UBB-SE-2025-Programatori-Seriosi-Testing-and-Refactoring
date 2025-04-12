using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.DBServices;
using Team3.Models;

namespace Team3.DBServices
{
    public class MedicalRecordDatabaseService
    {
        private static MedicalRecordDatabaseService? _instance;
        private readonly Config _config;
        private static readonly object _lock = new object();
        private MedicalRecordDatabaseService()
        {
            _config = Config.Instance;
        }
        public static MedicalRecordDatabaseService Instance
        {
            get
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MedicalRecordDatabaseService();
                    }
                    return _instance;
                }
            }
        }
        // maybe we don't need this   
        public MedicalRecord GetMedicalRecordById(int id)
        {
            const string query = "SELECT * FROM medicalrecords WHERE id = @id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
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
