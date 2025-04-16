namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.Service.Interfaces;

    /// <summary>
    /// ViewModel for managing chat data and interactions.
    /// </summary>
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepository;

        public ChatService(IChatRepository _chatRepository)
        {
            this.chatRepository = _chatRepository;
        }

        public ObservableCollection<Chat> Chats { get; set; }

        public int UserID { get; set; }

        public List<Chat> GetChatsByUserId(int id)
        {
            return this.chatRepository.GetChatsByUserId(id);
        }

        public void AddNewChat(Chat chat)
        {
            this.chatRepository.AddNewChat(chat.User1, chat.User2);
        }

        public List<Chat> GetChatsByName(string name)
        {
            List<Chat> chats = this.chatRepository.GetChatsByUserId(this.UserID);
            return chats.Where(chat =>
                chat.User1.ToString().Contains(name) ||
                chat.User2.ToString().Contains(name)).ToList();
        }
    }
}
