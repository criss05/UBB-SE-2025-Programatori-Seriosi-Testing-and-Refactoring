// <copyright file="ChatDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// This class is responsible for managing chat-related database operations.
    /// </summary>
    public class ChatDatabaseService : IChatDatabaseService
    {
        private static readonly object LockObject = new object();
        private static ChatDatabaseService? instance;
        private readonly Config config;
        private Task<List<Chat>> chats;

        private ChatDatabaseService()
        {
            this.config = Config.Instance;
        }

        /// <summary>
        /// Gets the singleton instance of the ChatDatabaseService class.
        /// </summary>
        public static ChatDatabaseService Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = new ChatDatabaseService();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Retrieves a list of chats for a specific user from the database.
        /// </summary>
        /// <param name="user">The ID of the user whose chats are to be retrieved.</param>
        /// <returns>A list of Chat objects associated with the user.</returns>
        public List<Chat> getChatsByUserId(int user)
        {
            const string query = "SELECT * FROM chats WHERE user1 = @user OR user2 = @user";

            try
            {
                SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING);

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                List<Chat> chats = new List<Chat>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        chats.Add(new Chat((int)reader[0], (int)reader[1], (int)reader[2]));
                    }
                }

                connection.Close();

                return chats;
            }
            catch (Exception e)
            {
                throw new Exception("Error getting chats", e);
            }
        }

        /// <summary>
        /// Adds a new chat between two users to the database.
        /// </summary>
        /// <param name="user1">The ID of the first user.</param>
        /// <param name="user2">The ID of the second user.</param>
        public void AddNewChat(int user1, int user2)
        {
            const string query = "INSERT INTO chats (user1, user2) VALUES (@user1, @user2)";
            try
            {
                SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@user1", user1);
                command.Parameters.AddWithValue("@user2", user2);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error adding chat", e);
            }
        }
    }
}
