﻿// <copyright file="DrugDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Implementations
{
    using System;
    using Microsoft.Data.SqlClient;
    using Team3.Models;
    using Team3.Repository.Interfaces;

    /// <summary>
    /// Service for managing drug database operations.
    /// </summary>
    public class DrugRepository : IDrugRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public DrugRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets a drug by its ID from the database.
        /// </summary>
        /// <param name="drugId">Drug ID.</param>
        /// <returns>Drug.</returns>
        /// <exception cref="Exception">Throws an error.</exception>
        public Drug GetDrugById(int drugId)
        {
            const string query = "SELECT * FROM drugs WHERE id = @id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", drugId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Drug(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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
