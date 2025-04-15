// <copyright file="MessageModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
    using Team3.DatabaseServices;
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.DTOs;
    using Team3.Models;
    using Team3.ModelViews;
    using Team3.ModelViews.Interfaces;
    using Windows.Services.Maps;

    /// <summary>
    /// Interface for the message model view.
    /// </summary>
    public class MessageModelView : IMessageModelView
    {
        private readonly IMessageDatabaseService messageModel;
        private readonly IUserModelView userModelView;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageModelView"/> class.
        /// </summary>
        public MessageModelView()
        {
            Debug.WriteLine("MessageModelView created");
            messageModel = MessageDatabaseService.Instance;
            userModelView = new UserModelView(new UserDatabaseService(Config.DbConnectionString));
            Messages = new ObservableCollection<MessageChatDTO>();
        }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public ObservableCollection<MessageChatDTO> Messages { get; set; }

        /// <summary>
        /// Loads all messages for a given chat ID.
        /// </summary>
        /// <param name="chatId">The id of the chats.</param>
        public void LoadAllMessages(int chatId)
        {
            List<Message> messages = messageModel.GetMessagesByChatId(chatId);
            Debug.WriteLine(messages.Count + "Messages loaded");
            Messages.Clear();
            messages.Sort((x, y) => x.SentDateTime.CompareTo(y.SentDateTime));
            foreach (Message message in messages)
            {
                User user = userModelView.GetUserById(message.UserId);
                Messages.Add(new MessageChatDTO(message.Id, message.Content, message.UserId, message.ChatId, message.SentDateTime, user.Name));
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
            // MessageChatDTO messageChatDTO = new MessageChatDTO(newMessage.Id ,message, userId, chatId, currentDateTime, userModelView.GetUser(userId).ToString());
            LoadAllMessages(chatId);
        }
    }
}
