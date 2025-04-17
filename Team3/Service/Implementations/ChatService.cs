// <copyright file="ChatService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Team3.Models;
    using Team3.Repository.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// ViewModel for managing chat data and interactions.
    /// </summary>
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatService"/> class.
        /// </summary>
        /// <param name="chatRepository">the chat repository.</param>
        public ChatService(IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        /// <summary>
        /// Gets or sets the collection of chats.
        /// </summary>
        public ObservableCollection<Chat> Chats { get; set; }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets the chats for a specific user by their ID.
        /// </summary>
        /// <param name="userId">the id of the user.</param>
        /// <returns>The chats of the user.</returns>
        public List<Chat> GetChatsByUserId(int userId)
        {
            return this.chatRepository.GetChatsByUserId(userId);
        }

        /// <summary>
        /// Adds a new chat to the repository.
        /// </summary>
        /// <param name="chat">The chat to be added.</param>
        public void AddNewChat(Chat chat)
        {
            this.chatRepository.AddNewChat(chat.User1, chat.User2);
        }

        /// <summary>
        /// Gets the chats for a specific user by their name.
        /// </summary>
        /// <param name="name">The name of the chat.</param>
        /// <returns>The chat taken by the name.</returns>
        public List<Chat> GetChatsByName(string name)
        {
            List<Chat> chats = this.chatRepository.GetChatsByUserId(this.UserID);
            return chats.Where(chat =>
                chat.User1.ToString().Contains(name) ||
                chat.User2.ToString().Contains(name)).ToList();
        }
    }
}
