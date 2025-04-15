namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// ViewModel for managing chat data and interactions.
    /// </summary>
    public class ChatViewModel : IChatModelView
    {
        private readonly IChatDatabaseService chatDatabaseService;

        public ChatViewModel(IChatDatabaseService chatDatabaseService)
        {
            this.chatDatabaseService = chatDatabaseService;
            this.Chats = new ObservableCollection<Chat>();
        }

        public ObservableCollection<Chat> Chats { get; set; }

        public int UserID { get; set; }

        public void LoadAllChats()
        {
            try
            {
                var chatList = this.chatDatabaseService.GetChatsByUserId(this.UserID);
                this.Chats.Clear();

                if (chatList != null && chatList.Any())
                {
                    foreach (var chat in chatList)
                    {
                        this.Chats.Add(chat);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Dictionary<Chat, string> GetChatsByUserId(int id)
        {
            List<Chat> chats = this.chatDatabaseService.GetChatsByUserId(id);
            return chats.ToDictionary(chat => chat, chat => chat.ChatID.ToString());
        }

        public void AddNewChat(Chat chat)
        {
            this.chatDatabaseService.AddNewChat(chat.User1, chat.User2);
            this.Chats.Add(chat);
        }

        public void SetUserId(int id)
        {
            this.UserID = id;
        }

        public List<Chat> GetChatsByName(string name)
        {
            List<Chat> chats = this.chatDatabaseService.GetChatsByUserId(this.UserID);
            return chats.Where(chat =>
                chat.User1.ToString().Contains(name) ||
                chat.User2.ToString().Contains(name)).ToList();
        }

        public void BackButtonHandler()
        {
            Debug.WriteLine("Back button clicked in Chats");
        }

        public void SearchButtonHandler(string searchQuery)
        {
            Debug.WriteLine("Search button clicked in Chats");
            this.GetChatsByName(searchQuery);
        }
    }
}
