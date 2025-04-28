// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Data.SqlClient;
    using Team3.Models;
    using Team3.Repository.Interfaces;

    /// <summary>
    /// Repository for user data.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        public UserRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        /// <summary>
        /// Get all users from the database.
        /// </summary>
        /// <returns>The list of all users.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public List<User> GetAllUsers()
        {
            const string query = "SELECT * FROM users;";
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User(
                                (int)reader[0],
                                reader[1].ToString(),
                                reader[2].ToString()));
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error retrieving users", error);
            }

            return users;
        }

        /// <summary>
        /// Get a user by id from the database.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The user with the given id.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public User GetUserById(int userId)
        {
            const string query = "SELECT * FROM users WHERE id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User((int)reader[0], reader[1].ToString(), reader[2].ToString());
                            }
                        }
                    }
                }

                throw new Exception("User not found");
            }
            catch (Exception error)
            {
                throw new Exception("Error retrieving user", error);
            }
        }
    }
}
