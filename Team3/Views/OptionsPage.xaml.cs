// <copyright file="OptionsPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using System;
    using System.Collections.Generic;
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
    using Team3.Models;
    using Windows.Foundation;
    using Windows.Foundation.Collections;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OptionsPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsPage"/> class.
        /// </summary>
        public OptionsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the ID of the selected user.
        /// </summary>
        public int SelectedUserId { get; set; }

        /// <summary>
        /// Handles the navigation to this page.
        /// </summary>
        /// <param name="e">The event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is int user)
            {
                this.SelectedUserId = user;

                // Now you can use the selected user in this page
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.Navigate(typeof(UserView));
            }
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to ChatPage and pass the selected user
            // Frame.Navigate(typeof(ChatView), SelectedUser);
        }

        private void NotificationsButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to NotificationsPage and pass the selected user
            this.Frame.Navigate(typeof(NotificationView),  this.SelectedUserId);
        }
    }
}
