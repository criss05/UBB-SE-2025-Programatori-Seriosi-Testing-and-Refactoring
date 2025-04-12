using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Team3.DBServices;
using Team3.Models;

namespace Team3.DBServices
{
    public class UserDatabaseService
    {

        private static UserDatabaseService? _instance;
        private readonly Config _config;
        private static readonly object _lock = new object();
        private UserDatabaseService()
        {
            _config = Config.Instance;
        }
        public static UserDatabaseService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserDatabaseService();
                    }   
                }
                return _instance;
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
