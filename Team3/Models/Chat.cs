// <copyright file="Chat.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    /// <summary>
    /// Represents a chat between two users.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Chat"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the chat.</param>
        /// <param name="u1">Id of the first user.</param>
        /// <param name="u2">Id of the second user.</param>
        public Chat(int id, int u1, int u2)
        {
            this.Id = id;
            this.User1 = u1;
            this.User2 = u2;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the chat.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the first user in the chat.
        /// </summary>
        public int User1 { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the second user in the chat.
        /// </summary>
        public int User2 { get; set; }

        /// <summary>
        /// Returns a string representation of the chat.
        /// </summary>
        /// <returns>string representation of the chat.</returns>
        public override string ToString()
        {
            return $"Chat(Id: {this.Id}, User 1: {this.User1}, User 2: {this.User2})";
        }
    }
}