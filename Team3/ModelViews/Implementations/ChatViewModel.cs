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
    using Team3.Service.Interfaces;

    /// <summary>
    /// ViewModel for managing chat data and interactions.
    /// </summary>
    public class ChatViewModel : IChatModelView
    {
        private readonly IChatService chatService;

        public ChatViewModel(IChatService _chatService)
        {
            this.chatService = _chatService;
            this.Chats = new ObservableCollection<Chat>();
        }

        public ObservableCollection<Chat> Chats { get; set; }

        public int UserID { get; set; }

        public void LoadAllChats()
        {
            try
            {
                var chatList = this.chatService.GetChatsByUserId(this.UserID);
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

        public List<Chat> GetChatsByUserId(int id)
        {
            return this.chatService.GetChatsByUserId(id);
        }

        public void AddNewChat(Chat chat)
        {
            this.chatService.AddNewChat(chat);
            this.Chats.Add(chat);
        }

        public void SetUserId(int id)
        {
            this.UserID = id;
        }

        public List<Chat> GetChatsByName(string name)
        {
            return this.chatService.GetChatsByName(name);
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
