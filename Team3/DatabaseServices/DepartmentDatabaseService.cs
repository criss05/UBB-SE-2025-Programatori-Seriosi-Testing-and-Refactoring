// <copyright file="DepartmentDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Service for interacting with the department database.
    /// </summary>
    public class DepartmentDatabaseService : IDepartmentDatabaseService
    {
        private static DepartmentDatabaseService? instance;
        private readonly Config config;

        private DepartmentDatabaseService()
        {
            this.config = Config.Instance;
        }

        /// <summary>
        /// Gets singleton instance of the DepartmentDatabaseService.
        /// </summary>
        public static DepartmentDatabaseService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DepartmentDatabaseService();
                }

                return instance;
            }
        }

        /// <summary>
        /// Get all departments from the database.
        /// </summary>
        /// <returns>A lkist with departements.</returns>
        /// <exception cref="Exception">throws an error.</exception>
        public List<Department> GetDepartments()
        {
            const string query = "SELECT * FROM departments;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
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
            catch (Exception e)
            {
                throw new Exception("Error getting departments", e);
            }
        }
    }
}
