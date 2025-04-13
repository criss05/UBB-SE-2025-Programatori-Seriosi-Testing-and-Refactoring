// <copyright file="NotificationView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using System;
    using System.Diagnostics;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Navigation;
    using Team3.DatabaseServices;
    using Team3.Models;
    using Team3.ModelViews;

    /// <summary>
    /// Interaction logic for NotificationView.xaml.
    /// </summary>
    public sealed partial class NotificationView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationView"/> class.
        /// </summary>
        public NotificationView()
        {
            this.InitializeComponent();
            this.NotificationsListView.DataContext = this.ModelView;
        }

        /// <summary>
        /// Gets or sets the user ID for which notifications are loaded.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets the view model for the notification view.
        /// </summary>
        public INotificationModelView ModelView { get; } = new NotificationModelView(new AppointmentModelView(new AppointmentDatabaseService(Config.DbConnectionString)));

        /// <summary>
        /// Handles the navigation to this page.
        /// </summary>
        /// <param name="e">The event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is int userId)
            {
                this.UserId = userId;
                this.ModelView.LoadNotifications(userId);

                // In a real app, you might filter notifications by user
                Debug.WriteLine($"Loading notifications for user: ID={userId}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OptionsPage), this.UserId);
        }

        private void NotificationsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Notification selectedNotification)
            {
                Debug.WriteLine($"Selected Notification: ID={selectedNotification.Id}, Date={selectedNotification.DeliveryDateTime}");

                // Navigate to the notification detail page passing the notification
                this.Frame.Navigate(typeof(NotificationDetailView), selectedNotification);
            }
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.ModelView.AddNewAppointment();
        }

        private void DeleteAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.ModelView.DeleteAppointment();
        }

        private void AddTreatmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.ModelView.AddNewTreatment();
        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            this.ModelView.AddNewReview();
        }
    }
}