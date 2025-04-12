using System;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Team3.Models;
using Team3.ModelViews;

namespace Team3.Views
{
    public sealed partial class NotificationDetailView : Page
    {
        public Notification SelectedNotification { get; set; }
        private INotificationModelView ViewModel { get; } = new NotificationModelView();

        public NotificationDetailView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Notification notification)
            {
                SelectedNotification = notification;
                Debug.WriteLine($"Viewing notification detail: ID={SelectedNotification.Id}, Message={SelectedNotification.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NotificationView), SelectedNotification.UserId);
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            ViewModel.DeleteNotification(SelectedNotification.Id);

            //if (deleted)
            //{
            //    Debug.WriteLine($"Deleted notification: ID={SelectedNotification.Id}");
            //    // Go back to the notifications list

            //}
            Frame.Navigate(typeof(NotificationView), SelectedNotification.UserId);

        }
    }
}