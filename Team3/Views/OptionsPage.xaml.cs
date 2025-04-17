// <copyright file="OptionsPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Navigation;

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
        /// <param name="error">The event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs error)
        {
            base.OnNavigatedTo(error);

            if (error.Parameter is int user)
            {
                this.SelectedUserId = user;

                // Now you can use the selected user in this page
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs error)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.Navigate(typeof(UserView));
            }
        }

        private void ChatButton_Click(object sender, RoutedEventArgs error)
        {
            // Navigate to ChatPage and pass the selected user
            // Frame.Navigate(typeof(ChatView), SelectedUser);
        }

        private void NotificationsButton_Click(object sender, RoutedEventArgs error)
        {
            // Navigate to NotificationsPage and pass the selected user
            this.Frame.Navigate(typeof(NotificationView),  this.SelectedUserId);
        }
    }
}
