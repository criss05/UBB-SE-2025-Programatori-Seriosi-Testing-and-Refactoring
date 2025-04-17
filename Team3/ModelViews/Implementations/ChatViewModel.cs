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

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatViewModel"/> class.
        /// </summary>
        /// <param name="chatService">The chat service.</param>
        public ChatViewModel(IChatService chatService)
        {
            this.chatService = chatService;
            this.Chats = new ObservableCollection<Chat>();
        }

        /// <summary>
        /// Gets or sets the collection of chats.
        /// </summary>
        public ObservableCollection<Chat> Chats { get; set; }

        /// <summary>
        /// Gets or sets the user ID for the current user.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Loads all chats for the current user.
        /// </summary>
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

        /// <summary>
        /// Gets the list of chats for a specific user ID.
        /// </summary>
        /// <param name="id">The id of the chat.</param>
        /// <returns>The chats with that Id.</returns>
        public List<Chat> GetChatsByUserId(int id)
        {
            return this.chatService.GetChatsByUserId(id);
        }

        /// <summary>
        /// Adds a new chat to the collection and the database.
        /// </summary>
        /// <param name="chat">The chat to be added.</param>
        public void AddNewChat(Chat chat)
        {
            this.chatService.AddNewChat(chat);
            this.Chats.Add(chat);
        }

        /// <summary>
        /// Sets the user ID for the current user.
        /// </summary>
        /// <param name="id">The user id to be set with.</param>
        public void SetUserId(int id)
        {
            this.UserID = id;
        }

        /// <summary>
        /// Gets the list of chats by name.
        /// </summary>
        /// <param name="name">The name of the chat.</param>
        /// <returns>The chats with the given name.</returns>
        public List<Chat> GetChatsByName(string name)
        {
            return this.chatService.GetChatsByName(name);
        }

        /// <summary>
        /// Handles the back button click event.
        /// </summary>
        public void BackButtonHandler()
        {
            Debug.WriteLine("Back button clicked in Chats");
        }

        /// <summary>
        /// Handles the search button click event.
        /// </summary>
        /// <param name="searchQuery">The query to search for.</param>
        public void SearchButtonHandler(string searchQuery)
        {
            Debug.WriteLine("Search button clicked in Chats");
            this.GetChatsByName(searchQuery);
        }
    }
}
