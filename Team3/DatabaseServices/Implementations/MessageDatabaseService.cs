using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Team3.Models;
using System.Diagnostics;
using Team3.DatabaseServices.Interfaces;

namespace Team3.DatabaseServices.Implementations
{
    public class MessageDatabaseService : IMessageDatabaseService
    {
        private static MessageDatabaseService? instance;
        private static readonly object LockObject = new object();
        private MessageDatabaseService()
        {

        }
        public static MessageDatabaseService Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = new MessageDatabaseService();
                    }   
                }
                return instance;
            }
        }
        public List<Message> GetMessagesByChatId(int chatId)
        {
            Console.WriteLine($"Attempting to connect to: {Config.DbConnectionString}");
            const string query = "SELECT id, content, user_id, chat_id, sent_datetime FROM messages WHERE chat_id = @chat_id";
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DbConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@chat_id", chatId);
                    Debug.WriteLine("the chat it is:" +  chatId);

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
                                sentDateTime: (DateTime)reader[4]
                            ));
                        }
                    }
                    return messages;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error while loading messages: " + e.Message);
            }
        }

        public int addMessage(Message message)
        {
            const string query = "INSERT INTO messages (content, use_iId, chat_id, sent_datetime) VALUES (@content, @user_id, @chat_id, @sent_datetime)";
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DbConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@content", message.Content);
                    command.Parameters.AddWithValue("@user_id", message.UserId);
                    command.Parameters.AddWithValue("@chat_id", message.ChatId);
                    command.Parameters.AddWithValue("@sent_datetime", message.SentDateTime);
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error while adding message: " + e.Message);
            }
        }

    }
}
