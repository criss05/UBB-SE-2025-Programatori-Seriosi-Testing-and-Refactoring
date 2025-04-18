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
    using Team3.Repository.Implementations;
    using Team3.Repository.Interfaces;
    using Team3.Service.Implementations;
    using Team3.Service.Interfaces;
    using Team3.Services.Interfaces;

    /// <summary>
    /// Interaction logic for NotificationView.xaml.
    /// </summary>
    public sealed partial class NotificationView : Page
    {
        private readonly IAppointmentService appointmentService = new AppointmentService(new AppointmentRepository(Config.DbConnectionString));
        private readonly IPatientService patientService = new PatientService(new PatientRepository(Config.DbConnectionString));
        private readonly IUserService userService = new UserService(new UserRepository(Config.DbConnectionString));
        private readonly IMedicalRecordService medicalRecordService = new MedicalRecordService(new MedicalRecordRepository(Config.DbConnectionString));
        private readonly IDrugService drugService = new DrugService(new DrugRepository(Config.DbConnectionString));
        private readonly ITreatmentDrugService treatmentDrugService = new TreatmentDrugService(new TreatmentDrugRepository(Config.DbConnectionString));
        private readonly ITreatmentService treatmentService = new TreatmentService(new TreatmentRepository(Config.DbConnectionString));
        private readonly IReviewService reviewService = new ReviewService(new ReviewRepository(Config.DbConnectionString));
        private readonly IDoctorService doctorService = new DoctorService(
            new DoctorRepository(Config.DbConnectionString),
            new MedicalRecordService(new MedicalRecordRepository(Config.DbConnectionString)),
            new ScheduleService(new ScheduleRepository(Config.DbConnectionString)),
            new UserService(new UserRepository(Config.DbConnectionString))
        );

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationView"/> class.
        /// </summary>
        public NotificationView()
        {
            this.InitializeComponent();
            this.NotificationModelView = new NotificationModelView(new NotificationService(
                new NotificationRepository(Config.DbConnectionString),
                this.appointmentService,
                this.doctorService,
                this.userService,
                this.patientService,
                this.medicalRecordService,
                this.drugService,
                this.treatmentDrugService,
                this.treatmentService,
                this.reviewService));
            this.NotificationsListView.DataContext = this.NotificationModelView;
        }

        /// <summary>
        /// Gets or sets the user ID for which notifications are loaded.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets the notification model view.
        /// </summary>
        public INotificationModelView NotificationModelView { get; }

        /// <summary>
        /// Handles the navigation to this page.
        /// </summary>
        /// <param name="error">The event.</param>
        protected override void OnNavigatedTo(NavigationEventArgs error)
        {
            base.OnNavigatedTo(error);
            if (error.Parameter is int userId)
            {
                this.UserId = userId;
                this.NotificationModelView.LoadNotifications(userId);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs error)
        {
            this.Frame.Navigate(typeof(OptionsPage), this.UserId);
        }

        private void NotificationsListView_ItemClick(object sender, ItemClickEventArgs error)
        {
            if (error.ClickedItem is Notification selectedNotification)
            {
                this.Frame.Navigate(typeof(NotificationDetailView), selectedNotification);
            }
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs error)
        {
        }

        private void AddTreatmentButton_Click(object sender, RoutedEventArgs error)
        {
        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs error)
        {
        }

        private void DeleteAppointmentButton_Click(object sender, RoutedEventArgs error)
        {
        }
    }
}