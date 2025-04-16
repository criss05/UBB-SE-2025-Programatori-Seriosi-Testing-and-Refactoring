using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Team3.Models;
using Team3.DatabaseServices.Interfaces;

namespace Team3.DatabaseServices.Implementations
{
    public class MessageDatabaseService : IMessageDatabaseService
    {
        private readonly string dbConnString;

        public MessageDatabaseService(string _dbConnString)
        {
            this.dbConnString = _dbConnString;
        }

        public List<Message> GetMessagesByChatId(int chatId)
        {
            const string query = "SELECT id, content, user_id, chat_id, sent_datetime FROM messages WHERE chat_id = @chat_id";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
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
                                content: reader.GetString(1),
                                userId: reader.GetInt32(2),
                                chatId: reader.GetInt32(3),
                                sentDateTime: reader.GetDateTime(4)
                            ));
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

        public int addMessage(Message message)
        {
            const string query = "INSERT INTO messages (content, user_id, chat_id, sent_datetime) VALUES (@content, @user_id, @chat_id, @sent_datetime)";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.dbConnString))
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
    }
}
