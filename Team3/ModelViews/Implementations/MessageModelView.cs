namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Team3.DatabaseServices.Interfaces;
    using Team3.DTOs;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Services.Interfaces;

    /// <summary>
    /// Implementation of the IMessageModelView interface.
    /// </summary>
    public class MessageModelView : IMessageModelView
    {
        private readonly IMessageService messageService;
        private readonly IUserModelView userModelView;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageModelView"/> class.
        /// </summary>
        /// <param name="messageService">The message service.</param>
        /// <param name="userModelView">The user model view.</param>
        public MessageModelView(IMessageService messageService, IUserModelView userModelView)
        {
            Debug.WriteLine("MessageModelView created");
            this.messageService = messageService;
            this.userModelView = userModelView;
            Messages = new ObservableCollection<MessageChatDTO>();
        }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public ObservableCollection<MessageChatDTO> Messages { get; set; }

        /// <inheritdoc/>
        public void LoadAllMessages(int chatId)
        {
            var messages = messageService.GetMessagesByChatId(chatId);
            Debug.WriteLine(messages.Count + " Messages loaded");

            Messages.Clear();

            foreach (var message in messages)
            {
                var user = userModelView.GetUserById(message.UserId);
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

        /// <inheritdoc/>
        public void addMessage(Message message)
        {
            messageService.AddMessage(message);
        }

        /// <inheritdoc/>
        public Message GetMessageById(int id)
        {
            return messageService.GetMessageById(id);
        }
    }
}
