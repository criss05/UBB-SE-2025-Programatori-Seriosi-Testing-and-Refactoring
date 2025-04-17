// <copyright file="IChatModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for the ChatModelView class.
    /// </summary>
    public interface IChatModelView
    {
        /// <summary>
        /// Loads all chats from the database.
        /// </summary>
        void LoadAllChats();

        /// <summary>
        /// Gets the list of all chats.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The chats for the given user.</returns>
        List<Chat> GetChatsByUserId(int id);

        /// <summary>
        /// Adds a new chat to the list of chats.
        /// </summary>
        /// <param name="chat">The chat to be added.</param>
        void AddNewChat(Chat chat);

        /// <summary>
        /// Sets the user id for the current session.
        /// </summary>
        /// <param name="id">The id to be set.</param>
        void SetUserId(int id);

        /// <summary>
        /// Gets the user id for the current session.
        /// </summary>
        /// <param name="name">The name of.</param>
        /// <returns>The list of chats with the given name.</returns>
        List<Chat> GetChatsByName(string name);

        /// <summary>
        /// Handles the event when the back button is clicked.
        /// </summary>
        void BackButtonHandler();

        /// <summary>
        /// Handles the event when the search button is clicked.
        /// </summary>
        /// <param name="searchQuery">The query to search for.</param>
        void SearchButtonHandler(string searchQuery);
    }
}
