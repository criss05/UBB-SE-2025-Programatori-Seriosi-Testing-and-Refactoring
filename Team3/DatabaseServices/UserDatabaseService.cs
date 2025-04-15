using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class UserDatabaseService : IUserDatabaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDatabaseService"/> class.
        /// </summary>
        public UserDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        private string dbConnString { get; }

        public List<User> GetAllUsers()
        {
            const string query = "SELECT * FROM users;";
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
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
                                reader[2].ToString()
                            ));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving users", e);
            }

            return users;
        }

        public User GetUserById(int id)
        {
            const string query = "SELECT * FROM users WHERE id = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

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
            catch (Exception e)
            {
                throw new Exception("Error retrieving user", e);
            }
        }
    }
}
