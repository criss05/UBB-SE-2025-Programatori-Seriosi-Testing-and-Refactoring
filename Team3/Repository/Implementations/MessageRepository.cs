// <copyright file="MessageRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.Data.SqlClient;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;

    /// <summary>
    /// Repository class for managing messages in the database.
    /// </summary>
    public class MessageRepository : IMessageRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public MessageRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Get messages from a chat using the id.
        /// </summary>
        /// <param name="chatId">Id of the chat.</param>
        /// <returns>The messages from that chat.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public List<Message> GetMessagesByChatId(int chatId)
        {
            const string query = "SELECT content, user_id, chat_id, sent_datetime FROM messages WHERE chat_id = @chat_id";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@chat_id", chatId);
                    Debug.WriteLine("The chat ID is: " + chatId);

                    connection.Open();

                    List<Message> messages = new List<Message>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            messages.Add(new Message(
                                id: reader.GetInt32(0),
                                content: reader.GetString(1),
                                userId: reader.GetInt32(2),
                                chatId: reader.GetInt32(3),
                                sentDateTime: reader.GetDateTime(4)));
                        }
                    }

                    return messages;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error while loading messages: " + exception.Message, exception);
            }
        }

        /// <summary>
        /// Add a message to the database.
        /// </summary>
        /// <param name="message">The message to be added.</param>
        /// <returns>The status code if succeed.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public int AddMessage(Message message)
        {
            const string query = "INSERT INTO messages (content, user_id, chat_id, sent_datetime) VALUES (@content, @user_id, @chat_id, @sent_datetime)";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@content", message.Content);
                    command.Parameters.AddWithValue("@user_id", message.UserId);
                    command.Parameters.AddWithValue("@chat_id", message.ChatId);
                    command.Parameters.AddWithValue("@sent_datetime", message.SentDateTime);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return 1; // Indicates success
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error while adding message: " + exception.Message, exception);
            }
        }

        /// <summary>
        /// Get message from the database based on id.
        /// </summary>
        /// <param name="messageId">The id of the message.</param>
        /// <returns>The message wiht the given id.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public Message GetMessageById(int messageId)
        {
            const string query = "SELECT message_id, content, userId, chatId, sentDateTie FROM messages WHERE message_id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", messageId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new Exception("Message not found");
                            }

                            return new Message(
                                (int)reader[0],
                                reader[1].ToString(),
                                (int)reader[2],
                                (int)reader[3],
                                (DateTime)reader[4]);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error retrieving message", exception);
            }
        }
    }
}
