// <copyright file="IChatRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Team3.DatabaseServices.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for the chat repository.
    /// </summary>
    public interface IChatRepository
    {
        /// <summary>
        /// Get the user's chats from the DB by user.
        /// </summary>
        /// <param name="userId">the user id.</param>
        /// <returns>The chats for the given user.</returns>
        public List<Chat> GetChatsByUserId(int userId);

        /// <summary>
        /// Add a chat between user 1 and user 2.
        /// </summary>
        /// <param name="user1">First user of the chat.</param>
        /// <param name="user2">Second user if the chat.</param>
        public void AddNewChat(int user1, int user2);
    }
}
