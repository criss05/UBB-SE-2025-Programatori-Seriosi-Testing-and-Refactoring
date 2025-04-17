using System.Collections.Generic;
using Team3.Models;
using Team3.Services.Interfaces;
using Team3.DatabaseServices.Interfaces;

namespace Team3.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public List<Message> GetMessagesByChatId(int chatId)
        {
            var messages = messageRepository.GetMessagesByChatId(chatId);

            // Sort messages by SentDateTime
            messages.Sort((x, y) => x.SentDateTime.CompareTo(y.SentDateTime));

            return messages;
        }

        public int AddMessage(Message message)
        {
            return messageRepository.AddMessage(message);
        }

        public Message GetMessageById(int id)
        {
            return messageRepository.GetMessageById(id);
        }
    }
}
