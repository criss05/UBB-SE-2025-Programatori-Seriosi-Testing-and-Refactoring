// <copyright file="IChatService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Interfaces
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Team3.Models;

    /// <summary>
    /// Interface for chat service.
    /// </summary>
    public interface IChatService
    {
        /// <summary>
        /// Gets all chats.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The chats for the given user.</returns>
        List<Chat> GetChatsByUserId(int userId);

        /// <summary>
        /// Add a new chat.
        /// </summary>
        /// <param name="chat">The chat to be added.</param>
        void AddNewChat(Chat chat);

        /// <summary>
        ///  Gets chats by name.
        /// </summary>
        /// <param name="name">The name of the chat.</param>
        /// <returns>The chats with the given name.</returns>
        List<Chat> GetChatsByName(string name);
    }
}
