// <copyright file="IChatModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for the chat model view.
    /// </summary>
    public interface IChatModelView
    {
        /// <summary>
        /// get all chats.
        /// </summary>
        public void LoadAllChats();

        /// <summary>
        /// get chat from a user by id.
        /// </summary>
        /// <param name="id">The id of the chat.</param>
        /// <returns>The chats with the given id.</returns>
        public Dictionary<Chat, string> GetChatsByUserId(int id);

        /// <summary>
        /// add a new chat between two user's.
        /// </summary>
        /// <param name="chat">The chat.</param>
        public void AddNewChat(Chat chat);

        /// <summary>
        /// update the user's id.
        /// </summary>
        /// <param name="id">The user id.</param>
        public void SetUserId(int id);

        /// <summary>
        /// get chats by user's name.
        /// </summary>
        /// <param name="name">The name of the chat.</param>
        /// <returns>The chats with the given name.</returns>
        public List<Chat> GetChatsByName(string name);

        /// <summary>
        /// hadling the back action.
        /// </summary>
        public void BackButtonHandler();

        /// <summary>
        /// handling the search action.
        /// </summary>
        /// <param name="searchQuery">The search query.</param>
        public void SearchButtonHandler(string searchQuery);
    }
}
