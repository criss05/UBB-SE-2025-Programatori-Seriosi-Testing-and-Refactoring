using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class UserDatabaseService : IUserDatabaseService
    {

        private static UserDatabaseService? instance;
        private readonly Config config;
        private static readonly object LockObject = new object();
        private UserDatabaseService()
        {
            config = Config.Instance;
        }
        public static UserDatabaseService Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = new UserDatabaseService();
                    }   
                }
                return instance;
            }   
        }
        public List<User> GetAllUsers()
        {
            const string query = "SELECT * FROM users;";
            List<User> notifications = new List<User>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notifications.Add(new User(
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
                throw new Exception("Error retrieving notifications", e);
            }

            return notifications;
        }

        /// <summary>
        /// gets the user by the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public User GetUserById(int id)
        {
            const string query = "SELECT * FROM users WHERE id = @id";

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
                                return new User((int)reader[0], reader[1].ToString(), reader[2].ToString());
                            }
                        }
                    }
                }

                throw new Exception("User not found");
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving doctor", e);
            }
        }
    }


}
