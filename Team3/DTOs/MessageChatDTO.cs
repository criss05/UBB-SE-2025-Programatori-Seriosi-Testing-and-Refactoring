// <copyright file="MessageChatDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Data Transfer Object for MessageChat.
    /// </summary>
    public class MessageChatDTO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageChatDTO"/> class.
        /// </summary>
        /// <param name="message">The content of the message.</param>
        /// <param name="userId">The ID of the user who sent the message.</param>
        /// <param name="chatId">The ID of the chat to which the message belongs.</param>
        /// <param name="sentDateTime">The date and time when the message was sent.</param>
        /// <param name="userName">The name of the user who sent the message.</param>
        public MessageChatDTO(string message, int userId, int chatId, DateTime sentDateTime, string userName)
        {
            this.Message = message;
            this.UserId = userId;
            this.ChatId = chatId;
            this.SentDateTime = sentDateTime;
            this.UserName = userName;
        }

        /// <summary>
        /// Gets or sets the message content.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the Id of the user who sent the message.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the chat to which the message belongs.
        /// </summary>
        public int ChatId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was sent.
        /// </summary>
        public DateTime SentDateTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the user who sent the message.
        /// </summary>
        public string UserName { get; set; }
    }
}
