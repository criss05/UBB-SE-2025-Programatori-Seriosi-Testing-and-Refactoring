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
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Implementations;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Implementations;

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
        new AppointmentModelView(new AppointmentService(new AppointmentRepository(Config.DbConnectionString))),
        new DoctorModelView(
            new DoctorDatabaseService(Config.DbConnectionString),
            new MedicalRecordModelView(new MedicalRecordDatabaseService(Config.DbConnectionString)),
            new ScheduleModelView(new ScheduleDatabaseService(Config.DbConnectionString)),
            new UserModelView(new UserDatabaseService(Config.DbConnectionString))
        ),
        new UserModelView(new UserDatabaseService(Config.DbConnectionString)),
        new PatientModelView(new PatientDatabaseService(Config.DbConnectionString)),
        new MedicalRecordModelView(new MedicalRecordDatabaseService(Config.DbConnectionString)),
        new DrugModelView(new DrugDatabaseService(Config.DbConnectionString)),
        new TreatmentDrugModelView(new TreatmentDrugDatabaseService(Config.DbConnectionString)),
        new TreatmentModelView(new TreatmentDatabaseService(Config.DbConnectionString)),
        new ReviewModelView(new ReviewService(new ReviewRepository(Config.DbConnectionString)))
        ));

        /// <summary>
        /// Handles the navigation to this page.
        /// </summary>
        /// <param name="e">The event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Notification notification)
            {
                this.SelectedNotification = notification;
                Debug.WriteLine($"Viewing notification detail:Message={this.SelectedNotification.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NotificationView), this.SelectedNotification.UserId);
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
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