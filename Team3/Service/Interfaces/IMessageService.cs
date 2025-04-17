namespace Team3.Services.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    public interface IMessageService
    {
        List<Message> GetMessagesByChatId(int chatId);
        int AddMessage(Message message);
        Message GetMessageById(int id);
    }
}
