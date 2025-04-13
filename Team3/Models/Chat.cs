// <copyright file="Chat.cs" company="PlaceholderCompany">
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
    /// Represents a chat between two users.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Chat"/> class.
        /// </summary>
        /// <param name="chatID">Id of the chat.</param>
        /// <param name="u1">Id of the forst useer.</param>
        /// <param name="u2">Id of the second user.</param>
        public Chat(int chatID, int u1, int u2)
        {
            this.ChatID = chatID;
            this.User1 = u1;
            this.User2 = u2;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the chat.
        /// </summary>
        public int ChatID { get; set; }

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
            return $"ID: {this.ChatID}, User 1: {this.User1}, User 2: {this.User2}";
        }
    }
}
