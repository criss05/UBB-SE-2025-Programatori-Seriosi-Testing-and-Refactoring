// <copyright file="IMessageService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Services.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for message service.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Gets all messages by chat ID.
        /// </summary>
        /// <param name="chatId">The chat id.</param>
        /// <returns>The message for the given chat id.</returns>
        List<Message> GetMessagesByChatId(int chatId);

        /// <summary>
        /// Adds a message to the database.
        /// </summary>
        /// <param name="message">The message to be added.</param>
        /// <returns>The status code if succed.</returns>
        int AddMessage(Message message);

        /// <summary>
        /// Deletes a message from the database.
        /// </summary>
        /// <param name="messageId">The message to be deleted.</param>
        /// <returns></returns>
        Message GetMessageById(int messageId);
    }
}
