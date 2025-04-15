namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Implementations;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// ViewModel for managing chat data and interactions.
    /// </summary>
    internal class ChatViewModel : IChatModelView
    {
        private readonly ChatDatabaseService chatDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatViewModel"/> class and loads all chats.
        /// </summary>
        /// <param name="chatDatabaseService">An instance of the ChatDatabaseService.</param>
        public ChatViewModel(ChatDatabaseService chatDatabaseService)
        {
            this.chatDatabaseService = chatDatabaseService;
            Chats = new ObservableCollection<Chat>();
        }

        /// <summary>
        /// Gets to initialize a new instance of the <see cref="ChatViewModel"/> class.
        /// </summary>
        public ObservableCollection<Chat> Chats { get; private set; }

        /// <summary>
        /// Gets or sets the user ID for the current user.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Loads all chats for the current user from the database.
        /// </summary>
        public void LoadAllChats()
        {
            try
            {
                var chatList = chatDatabaseService.getChatsByUserId(UserID);

                if (chatList != null && chatList.Any())
                {
                    foreach (var chat in chatList)
                    {
                        Debug.WriteLine(chat.ToString());
                        Chats.Add(chat);
                    }
                }
                else
                {
                    throw new Exception("No chats found");
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Retrieves chats for a specific user ID from the database.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>List of all chats for the user and the messages from the chat.</returns>
        public Dictionary<Chat, string> GetChatsByUserId(int id)
        {
            List<Chat> chats = chatDatabaseService.getChatsByUserId(id);

            Dictionary<Chat, string> chatDict = new Dictionary<Chat, string>();
            foreach (Chat chat in chats)
            {
                chatDict.Add(chat, chat.ChatID.ToString());
            }

            return chatDict;
        }

        /// <summary>
        /// Adds a new chat to the list of chats and updates the database.
        /// </summary>
        /// <param name="chat">The chat.</param>
        public void AddNewChat(Chat chat)
        {
            chatDatabaseService.AddNewChat(chat.User1, chat.User2);
            Chats.Add(chat);
        }

        /// <summary>
        /// Sets the user ID for the current user.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        public void SetUserId(int id)
        {
            UserID = id;
        }

        /// <summary>
        /// Retrieves chats for a specific user ID from the database.
        /// </summary>
        /// <param name="name">The name of the chat.</param>
        /// <returns>The chats with the specific name.</returns>
        public List<Chat> GetChatsByName(string name)
        {
            List<Chat> chats = chatDatabaseService.getChatsByUserId(UserID);
            return chats.Where(chat => chat.User1.ToString().Contains(name) || chat.User2.ToString().Contains(name)).ToList();
        }

        /// <summary>
        /// Handles the back button action.
        /// </summary>
        public void BackButtonHandler()
        {
            Debug.WriteLine("Back button clicked in Chats");
        }

        /// <summary>
        /// Handles the search button action and retrieves chats by name.
        /// </summary>
        /// <param name="SearchQuery">The search query.</param>
        public void SearchButtonHandler(string SearchQuery)
        {
            Debug.WriteLine("Search button clicked in Chats");
            GetChatsByName(SearchQuery);
        }
    }
}
