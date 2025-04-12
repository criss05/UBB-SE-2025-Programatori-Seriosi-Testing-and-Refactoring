using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DBServices;
using Team3.Models;

namespace Team3.DBServices
{
    public class ChatDBService : IChatDBService
    {
        private static ChatDBService? _instance;
        private readonly Config _config;
        private Task<List<Chat>> _chats;
        private static readonly object _lock = new object();

        private ChatDBService()
        {
            _config = Config.Instance;
        }

        public static ChatDBService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ChatDBService();
                    }
                }
                return _instance;
            }
        }

        public List<Chat> getChats(int user)
        {
            const string query = "SELECT * FROM chats WHERE user1 = @user OR user2 = @user";

            try
            {
                SqlConnection connection = new SqlConnection(Config.CONNECTION);

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

        public void addChat(int user1, int user2)
        {
            const string query = "INSERT INTO chats (user1, user2) VALUES (@user1, @user2)";
            try
            {
                SqlConnection connection = new SqlConnection(Config.CONNECTION);
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
