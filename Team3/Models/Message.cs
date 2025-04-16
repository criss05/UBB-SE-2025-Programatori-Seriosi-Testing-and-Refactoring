using System;

/// <summary>
/// Represents a message in a chat application.
/// </summary>

namespace Team3.Models
{
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>

        /// <param name="id">The message ID.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="userId">The user ID.</param>
        /// <param name="chatId">The chat ID.</param>
        /// <param name="sentDateTime">The date and time the message was sent.</param>
        public Message(int id, string content, int userId, int chatId, DateTime sentDateTime)
        {
            this.Id = id;
            this.Content = content;
            this.UserId = userId;
            this.ChatId = chatId;
            this.SentDateTime = sentDateTime;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the message.
        /// </summary>
        public int Id { get; set; }

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

        public override string ToString()
        {
            return $"Message(Id: {this.Id}, Content: \"{this.Content}\", UserId: {this.UserId}, ChatId: {this.ChatId}, SentDateTime: {this.SentDateTime})";
        }
    }
}