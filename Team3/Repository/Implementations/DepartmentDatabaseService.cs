﻿// <copyright file="DepartmentDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Implementations
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Service for interacting with the department database.
    /// </summary>
    public class DepartmentDatabaseService : IDepartmentDatabaseService
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentDatabaseService"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public DepartmentDatabaseService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Get all departments from the database.
        /// </summary>
        /// <returns>A list of departments.</returns>
        /// <exception cref="Exception">Throws if the operation fails.</exception>
        public List<Department> GetDepartments()
        {
            const string query = "SELECT * FROM departments;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    List<Department> departments = new List<Department>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department(
                                reader.GetInt32(0),
                                reader.GetString(1)));
                        }
                    }

                    return departments;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error getting departments", exception);
            }
        }
    }
}
