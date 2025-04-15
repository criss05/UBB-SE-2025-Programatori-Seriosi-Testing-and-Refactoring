// <copyright file="Message.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a message in a chat application.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="content">The content of the message.</param>
        /// <param name="userId">The user Id.</param>
        /// <param name="chatId">The chat Id.</param>
        /// <param name="sentDateTime">The send date.</param>
        public Message(string content, int userId, int chatId, DateTime sentDateTime)
        {
            this.Content = content;
            this.UserId = userId;
            this.ChatId = chatId;
            this.SentDateTime = sentDateTime;
        }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user who sent the message.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the chat to which the message belongs.
        /// </summary>
        public int ChatId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the message was sent.
        /// </summary>
        public DateTime SentDateTime { get; set; }
    }
}
