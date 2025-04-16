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
    using Team3.Models;
    using Team3.ModelViews.Implementations;
    using Team3.ModelViews.Interfaces;
    using Team3.DatabaseServices.Interfaces;
    using Team3.DatabaseServices.Implementations;
    using Team3.Service.Implementations;

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
            this.NotificationModelView = new NotificationModelView(new NotificationService(
                new NotificationRepository(Config.DbConnectionString),
                this.appointmentModelView,
                this.doctorModelView,
                this.userModelView,
                this.patientModelView,
                this.medicalRecordModelView,
                this.drugModelView,
                this.treatmentDrugModelView,
                this.treatmentModelView,
                this.reviewModelView
            ));
            this.NotificationsListView.DataContext = this.NotificationModelView;
        }

        /// <summary>
        /// Gets or sets the user ID for which notifications are loaded.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets the view model for the notification view.
        /// </summary>
        private readonly IAppointmentModelView appointmentModelView = new AppointmentModelView(new AppointmentService(new AppointmentRepository(Config.DbConnectionString)));
        private readonly IUserModelView userModelView = new UserModelView(new UserDatabaseService(Config.DbConnectionString));
        private readonly IPatientModelView patientModelView = new PatientModelView(new PatientDatabaseService(Config.DbConnectionString));
        private readonly IMedicalRecordModelView medicalRecordModelView = new MedicalRecordModelView(new MedicalRecordDatabaseService(Config.DbConnectionString));
        private readonly IDrugModelView drugModelView = new DrugModelView(new DrugDatabaseService(Config.DbConnectionString));
        private readonly ITreatmentDrugModelView treatmentDrugModelView = new TreatmentDrugModelView(new TreatmentDrugDatabaseService(Config.DbConnectionString));
        private readonly ITreatmentModelView treatmentModelView = new TreatmentModelView(new TreatmentDatabaseService(Config.DbConnectionString));
        private readonly IReviewModelView reviewModelView = new ReviewModelView(new ReviewService(new ReviewRepository(Config.DbConnectionString)));
        private readonly IDoctorModelView doctorModelView = new DoctorModelView(new DoctorDatabaseService(Config.DbConnectionString), new MedicalRecordModelView(new MedicalRecordDatabaseService(Config.DbConnectionString)), new ScheduleModelView(new ScheduleDatabaseService(Config.DbConnectionString)), new UserModelView(new UserDatabaseService(Config.DbConnectionString)));

        // Now pass all of them to the NotificationModelView
        public INotificationModelView NotificationModelView { get; }
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
                this.NotificationModelView.LoadNotifications(userId);
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
                this.Frame.Navigate(typeof(NotificationDetailView), selectedNotification);
            }
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTreatmentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAppointmentButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}