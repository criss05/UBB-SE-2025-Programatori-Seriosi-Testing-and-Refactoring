// <copyright file="IMessageRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for the message repository.
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Get messages from a chat using the id.
        /// </summary>
        /// <param name="chatId">The id of the chat.</param>
        /// <returns>The list of the messages for the the given chat.</returns>
        public List<Message> GetMessagesByChatId(int chatId);

        /// <summary>
        /// Add a message .
        /// </summary>
        /// <param name="message">The message to be added.</param>
        /// <returns>The status code if succed.</returns>
        public int AddMessage(Message message);

        /// <summary>
        /// Get message from the database based to id.
        /// </summary>
        /// <param name="messageId">the message id.</param>
        /// <returns>The message with the given id.</returns>
        public Message GetMessageById(int messageId);
    }
}
