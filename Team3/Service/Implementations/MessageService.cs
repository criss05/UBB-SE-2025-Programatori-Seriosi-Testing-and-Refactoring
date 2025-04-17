// <copyright file="MessageService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Services.Implementations
{
    using System.Collections.Generic;
    using Team3.Models;
    using Team3.Repository.Interfaces;
    using Team3.Services.Interfaces;

    /// <summary>
    /// Service for managing messages in a chat application.
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageService"/> class.
        /// </summary>
        /// <param name="messageRepository">The message repository.</param>
        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        /// <summary>
        /// Gets messages from a chat using the id.
        /// </summary>
        /// <param name="chatId">The id of the chat.</param>
        /// <returns>The list of messages from that chat.</returns>
        public List<Message> GetMessagesByChatId(int chatId)
        {
            var messages = this.messageRepository.GetMessagesByChatId(chatId);

            // Sort messages by SentDateTime
            messages.Sort((x, y) => x.SentDateTime.CompareTo(y.SentDateTime));

            return messages;
        }

        /// <summary>
        /// Add a message to the database.
        /// </summary>
        /// <param name="message">The message to be added.</param>
        /// <returns>the status code if succed.</returns>
        public int AddMessage(Message message)
        {
            return this.messageRepository.AddMessage(message);
        }

        /// <summary>
        /// Get message from the database based on id.
        /// </summary>
        /// <param name="messageId">The id of the message.</param>
        /// <returns>The message with the given id.</returns>
        public Message GetMessageById(int messageId)
        {
            return this.messageRepository.GetMessageById(messageId);
        }
    }
}
