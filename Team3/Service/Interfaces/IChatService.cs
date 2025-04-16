using System.Collections.Generic;
using System.Collections.ObjectModel;
using Team3.Models;

namespace Team3.Service.Interfaces
{
    public interface IChatService
    {
        List<Chat> GetChatsByUserId(int id);

        void AddNewChat(Chat chat);

        List<Chat> GetChatsByName(string name);
    }
}
