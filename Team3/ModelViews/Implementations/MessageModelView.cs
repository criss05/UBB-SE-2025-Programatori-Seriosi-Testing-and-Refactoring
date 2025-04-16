namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Team3.DatabaseServices.Interfaces;
    using Team3.DTOs;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// Interface for the message model view.
    /// </summary>
    public class MessageModelView : IMessageModelView
    {
        private readonly IMessageDatabaseService messageDatabaseService;
        private readonly IUserModelView userModelView;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageModelView"/> class.
        /// </summary>
        /// <param name="messageDatabaseService">The message database service.</param>
        /// <param name="userModelView">The user model view.</param>
        public MessageModelView(IMessageDatabaseService messageDatabaseService, IUserModelView userModelView)
        {
            Debug.WriteLine("MessageModelView created");
            this.messageDatabaseService = messageDatabaseService;
            this.userModelView = userModelView;
            Messages = new ObservableCollection<MessageChatDTO>();
        }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public ObservableCollection<MessageChatDTO> Messages { get; set; }

        /// <summary>
        /// Loads all messages for a given chat ID.
        /// </summary>
        /// <param name="chatId">The id of the chat.</param>
        public void LoadAllMessages(int chatId)
        {
            List<Message> messages = messageDatabaseService.GetMessagesByChatId(chatId);
            Debug.WriteLine(messages.Count + " Messages loaded");

            Messages.Clear();
            messages.Sort((x, y) => x.SentDateTime.CompareTo(y.SentDateTime));

            foreach (Message message in messages)
            {
                User user = userModelView.GetUserById(message.UserId);
                Messages.Add(new MessageChatDTO(message.Content, message.UserId, message.ChatId, message.SentDateTime, user.Name));
            }
        }

        /// <summary>
        /// Handles the send button click event.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="chatId">The id of the chat.</param>
        /// <param name="message">The message.</param>
        public void SendButtonHandler(int userId, int chatId, string message)
        {
            Debug.WriteLine("Send button clicked");
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Utc);

            // Message newMessage = new Message(message, userId, chatId, currentDateTime);
            // MessageChatDTO messageChatDTO = new MessageChatDTO(newMessage.Id, message, userId, chatId, currentDateTime, userModelView.GetUser(userId).ToString());

            // Here you could add a method to actually send the message to the database.
            LoadAllMessages(chatId);
        }
    }
}
