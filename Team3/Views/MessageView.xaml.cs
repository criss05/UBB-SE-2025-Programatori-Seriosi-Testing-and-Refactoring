// <copyright file="MessageView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using System;
    using System.Diagnostics;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Navigation;
    using Team3.ModelViews.Implementations;
    using Team3.ModelViews.Interfaces;
    using Team3.Repository.Implementations;
    using Team3.Service.Implementations;
    using Team3.Services.Implementations;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MessageView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageView"/> class.
        /// </summary>
        public MessageView()
        {
            this.InitializeComponent();
            this.chatMessages.DataContext = this.ViewModel;
        }

        /// <summary>
        /// Gets the ViewModel for the message view.
        /// </summary>
        public IMessageModelView ViewModel { get; } = new MessageModelView(new MessageService(new MessageRepository(Config.DbConnectionString)), new UserModelView(new UserService(new UserRepository(Config.DbConnectionString))));

        /// <summary>
        /// Gets or Sets user ID of the current user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the chat ID of the current chat.
        /// </summary>
        public int ChatId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageView"/> class.
        /// </summary>
        /// <param name="error">The event ot the navigation.</param>
        protected override void OnNavigatedTo(NavigationEventArgs error)
        {
            base.OnNavigatedTo(error);
            if (error.Parameter is(int userId, int chatId))
            {
                this.UserId = userId;
                this.ChatId = chatId;
                this.ViewModel.LoadAllMessages(userId);
                Debug.WriteLine($"Loading notifications for user: ID={userId}");
            }
        }

        private
        void BackClicked(object sender, RoutedEventArgs error)
        {
            this.Frame.Navigate(typeof(ChatView));
        }

        private void SendButtonClicked(object sender, RoutedEventArgs error)
        {
            string message = this.messageBar.Text;
            this.ViewModel.SendButtonHandler(this.UserId, this.ChatId, message);
            this.messageBar.PlaceholderText = "Type a message...";
        }
    }
}
