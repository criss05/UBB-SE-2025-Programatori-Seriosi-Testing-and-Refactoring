namespace Team3.ModelViews.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the Message Model View.
    /// </summary>
    public interface IMessageModelView
    {
        /// <summary>
        /// Loads the messages for a specific chat.
        /// </summary>
        /// <param name="chatId">  The id of the message.</param>
        public void LoadAllMessages(int chatId);

        /// <summary>
        /// Handles the send button click event.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="chatId">The user chat.</param>
        /// <param name="message">The message</param>
        public void SendButtonHandler(int userId, int chatId, string message);
    }
}
