// <copyright file="DrugDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.UI.Xaml.CustomAttributes;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Service for managing drug database operations.
    /// </summary>
    public class DrugDatabaseService :IDrugDatabaseService
    {
        private static readonly object LockObject = new object();
        private static DrugDatabaseService? instance;
        private readonly Config config;

        private DrugDatabaseService()
        {
            this.config = Config.Instance;
        }

        /// <summary>
        /// Gets dingleton instance of the DrugDatabaseService.
        /// </summary>
        public static DrugDatabaseService Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = new DrugDatabaseService();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets a drug by its ID from the database.
        /// </summary>
        /// <param name="Id">drug id.</param>
        /// <returns>drug.</returns>
        /// <exception cref="Exception">throw error.</exception>
        public Drug getDrugById(int Id)
        {
            const string query = "SELECT * FROM drugs WHERE id = @id;";

            try
            {
                SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING);

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", Id);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Drug(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            catch (Exception e)
            {
                throw new Exception("Error getting drug", e);
            }
        }
    }
}
