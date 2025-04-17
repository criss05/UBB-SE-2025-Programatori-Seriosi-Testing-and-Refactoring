// <copyright file="MessageView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Controls.Primitives;
    using Microsoft.UI.Xaml.Data;
    using Microsoft.UI.Xaml.Input;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml.Navigation;
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.ModelViews.Implementations;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Implementations;
    using Windows.Foundation;
    using Windows.Foundation.Collections;

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

        public IMessageModelView ViewModel { get; } = new MessageModelView(new MessageService(new MessageRepository(Config.DbConnectionString)), new UserModelView(new UserDatabaseService(Config.DbConnectionString)));


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
        /// <param name="e">The event ot the navigation.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is(int userId, int chatId))
            {
                this.UserId = userId;
                this.ChatId = chatId;
                this.ViewModel.LoadAllMessages(userId);
                Debug.WriteLine($"Loading notifications for user: ID={userId}");
            }
        }

        private
        void BackClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ChatView));
        }

        private void sendButtonClicked(object sender, RoutedEventArgs e)
        {
            string message = this.messageBar.Text;
            this.ViewModel.SendButtonHandler(this.UserId, this.ChatId, message);
            this.messageBar.PlaceholderText = "Type a message...";
        }
    }
}
