using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public DateTime sentDateTime { get; set; }
        public Message(int id, string content, int userId, int chatId, DateTime sentDateTime)
        {
            this.Id = id;
            this.Content = content;
            this.UserId = userId;
            this.ChatId = chatId;
            this.sentDateTime = sentDateTime;
        }
        public Message(string content, int userId, int chatId, DateTime sentDateTime)
        {
            this.Content = content;
            this.UserId = userId;
            this.ChatId = chatId;
            this.sentDateTime = sentDateTime;
        }
    }
}
