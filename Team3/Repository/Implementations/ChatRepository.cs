using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Team3.Models;
using Team3.DatabaseServices.Interfaces;

namespace Team3.DatabaseServices.Implementations
{
    /// <summary>
    /// This class is responsible for managing chat-related database operations.
    /// </summary>
    public class ChatRepository : IChatRepository
    {
        private readonly string dbConnString;

        public ChatRepository(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        /// <summary>
        /// Retrieves a list of chats for a specific user from the database.
        /// </summary>
        /// <param name="user">The ID of the user whose chats are to be retrieved.</param>
        /// <returns>A list of Chat objects associated with the user.</returns>
        public List<Chat> GetChatsByUserId(int user)
        {
            const string query = "SELECT * FROM chats WHERE user1 = @user OR user2 = @user";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user", user);
                    List<Chat> chats = new List<Chat>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            chats.Add(new Chat((int)reader[0], (int)reader[1], (int)reader[2]));
                        }
                    }

                    return chats;
                }
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
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user1", user1);
                    command.Parameters.AddWithValue("@user2", user2);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding chat", e);
            }
        }
    }
}
