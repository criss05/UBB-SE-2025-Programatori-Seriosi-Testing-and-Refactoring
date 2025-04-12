using System;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Team3.Models;
using Team3.ModelViews;

namespace Team3.Views
{
    public sealed partial class NotificationView : Page
    {
        public int UserId { get; set; }
        public INotificationModelView ModelView { get; } = new NotificationModelView();

        public NotificationView()
        {
            this.InitializeComponent();
            this.NotificationsListView.DataContext = ModelView;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is int userId)
            {
                UserId = userId;
                ModelView.LoadNotifications(userId);
                // In a real app, you might filter notifications by user
                Debug.WriteLine($"Loading notifications for user: ID={userId}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OptionsPage), UserId);
        }

        private void NotificationsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Notification selectedNotification)
            {
                Debug.WriteLine($"Selected Notification: ID={selectedNotification.Id}, Date={selectedNotification.DeliveryDateTime}");
                // Navigate to the notification detail page passing the notification
                Frame.Navigate(typeof(NotificationDetailView), selectedNotification);
            }
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            ModelView.AddAppointment();
        }


        private void DeleteAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            ModelView.DeleteAppointment();
        }


        private void AddTreatmentButton_Click(object sender, RoutedEventArgs e)
        {
            ModelView.AddTreatment();
        }


        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            ModelView.AddReview();
        }


    }
}