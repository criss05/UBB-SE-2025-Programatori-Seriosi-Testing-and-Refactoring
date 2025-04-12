using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Entities
{
    public class Chat
    {
        public int ChatID { get; set; }
        public int user1 { get; set; }
        public int user2 { get; set; }
        public Chat(int chatID, int u1, int u2)
        {
            ChatID = chatID;
            user1 = u1;
            user2 = u2;
        }
        override
        public string ToString()
        {
            return $"ID: {ChatID}, User 1: {user1}, User 2: {user2}";
        }
    }
}
