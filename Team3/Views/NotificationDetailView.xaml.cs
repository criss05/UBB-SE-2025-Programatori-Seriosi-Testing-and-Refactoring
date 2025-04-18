// <copyright file="NotificationDetailView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using System;
    using System.Diagnostics;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Navigation;
    using Team3.Models;
    using Team3.ModelViews.Implementations;
    using Team3.ModelViews.Interfaces;
    using Team3.Repository.Implementations;
    using Team3.Repository.Interfaces;
    using Team3.Service.Implementations;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Interaction logic for NotificationDetailView.xaml.
    /// </summary>
    public sealed partial class NotificationDetailView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationDetailView"/> class.
        /// </summary>
        public NotificationDetailView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the selected notification.
        /// </summary>
        public Notification SelectedNotification { get; set; }

        /// <summary>
        /// Gets the view model for the notification detail view.
        /// </summary>
        private INotificationModelView ViewModel { get; } = new NotificationModelView(new NotificationService(
        new NotificationRepository(Config.DbConnectionString),
        new AppointmentService(new AppointmentRepository(Config.DbConnectionString)),
        new DoctorService(new DoctorRepository(Config.DbConnectionString), new MedicalRecordService(new MedicalRecordRepository(Config.DbConnectionString)), new ScheduleService(new ScheduleRepository(Config.DbConnectionString)), new UserService(new UserRepository(Config.DbConnectionString))),
        new UserService(new UserRepository(Config.DbConnectionString)),
        new PatientService(new PatientRepository(Config.DbConnectionString)),
        new MedicalRecordService(new MedicalRecordRepository(Config.DbConnectionString)),
        new DrugService(new DrugRepository(Config.DbConnectionString)),
        new TreatmentDrugService(new TreatmentDrugRepository(Config.DbConnectionString)),
        new TreatmentService(new TreatmentRepository(Config.DbConnectionString)),
        new ReviewService(new ReviewRepository(Config.DbConnectionString))));

        /// <summary>
        /// Handles the navigation to this page.
        /// </summary>
        /// <param name="error">The event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs error)
        {
            base.OnNavigatedTo(error);
            if (error.Parameter is Notification notification)
            {
                this.SelectedNotification = notification;
                Debug.WriteLine($"Viewing notification detail:Message={this.SelectedNotification.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs error)
        {
            this.Frame.Navigate(typeof(NotificationView), this.SelectedNotification.UserId);
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs error)
        {
            this.ViewModel.DeleteNotification(this.SelectedNotification.UserId);

            // if (deleted)
            // {
            //    Debug.WriteLine($"Deleted notification: ID={SelectedNotification.Id}");
            //    // Go back to the notifications list

            // }
            this.Frame.Navigate(typeof(NotificationView), this.SelectedNotification.UserId);
        }
    }
}