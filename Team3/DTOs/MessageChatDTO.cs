using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.DTOs
{
    public class MessageChatDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }

        public DateTime sentDateTime { get; set; }

        public string UserName { get; set; }

        public MessageChatDTO(int id, string content, int userId, int chatId, DateTime sentDateTime, string userName)
        {
            this.Id = id;
            this.Content = content;
            this.UserId = userId;
            this.ChatId = chatId;
            this.sentDateTime = sentDateTime;
            this.UserName = userName;
        }
    }
}
