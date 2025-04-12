﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Documents;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class TreatmentDatabaseService : ITreatmentDatabaseService
    {
        private static TreatmentDatabaseService? _instance;
        private static readonly object _lock = new object();
        private readonly Config _config;

        private TreatmentDatabaseService()
        {
            _config = Config.Instance;
        }

        public static TreatmentDatabaseService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new TreatmentDatabaseService();
                    }
                }
                return _instance;
            }
        }

        public void AddNewTreatment(Treatment treatment)
        {
            const string query = "INSERT INTO treatments(id, memdicalrecord_id) values (@id , @memdicalrecord_id)";
            try
            {
                SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", treatment.Id);
                command.Parameters.AddWithValue("@memdicalrecord_id", treatment.MedicalRecordId);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error adding treatment", e);
            }
        }


        public Treatment GetTreatmentByMedicalRecordId(int mrId)
        {
            const string query = "SELECT * FROM treatments WHERE medicalrecord_id = @medicalrecord_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@medicalrecord_id", mrId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Treatment((int)reader[0], (int)reader[1]);
                            }
                        }
                    }
                }

                throw new Exception("Treatment not found");
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving treatment", e);
            }
        }


    }
}
