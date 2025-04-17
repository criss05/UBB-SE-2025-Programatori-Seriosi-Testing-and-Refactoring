// <copyright file="NotificationModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System.Collections.Generic;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Insterface for the NotificationModelView.
    /// </summary>
    public class NotificationModelView : INotificationModelView
    {
        private readonly INotificationService notificationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationModelView"/> class.
        /// </summary>
        /// <param name="notificationService">Notification service.</param>
        public NotificationModelView(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        /// <summary>
        ///     Gets the list of notifications.
        /// </summary>
        public List<Notification> Notifications { get; private set; }

        /// <summary>
        /// Loads the notifications for a specific user.
        /// </summary>
        /// <param name="userId">User id.</param>
        public void LoadNotifications(int userId)
        {
            this.notificationService.LoadNotifications(userId);
        }

        /// <summary>
        /// Add a notification.
        /// </summary>
        /// <param name="notification">The notification to be added.</param>
        /// <returns>The status code of success.</returns>
        public int AddNotification(Notification notification)
        {
            return this.notificationService.AddNotification(notification);
        }

        /// <summary>
        /// Get a notification.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        /// <returns>The notification with the given Id.</returns>
        public Notification GetNotificationById(int notificationId)
        {
            return this.notificationService.GetNotificationById(notificationId);
        }

        /// <summary>
        /// / Gets the notification by id.
        /// </summary>
        /// <param name="userId">the id of the user.</param>
        public void DeleteNotification(int userId)
        {
            this.notificationService.DeleteNotification(userId);
        }

        /// <summary>
        /// / Adds an upcoming appointment notification.
        /// </summary>
        /// <param name="appointmentId">the id of the appointment.</param>
        public void AddUpcomingAppointmentNotification(int appointmentId)
        {
            this.notificationService.AddUpcomingAppointmentNotification(appointmentId);
        }

        /// <summary>
        /// / Adds a cancel appointment notification.
        /// </summary>
        /// <param name="appointmentId">the id of the appointment.</param>
        public void AddCancelAppointmentNotification(int appointmentId)
        {
            this.notificationService.AddCancelAppointmentNotification(appointmentId);
        }

        /// <summary>
        /// / Deletes the upcoming appointment notification.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        public void DeleteUpcomingAppointmentNotification(int appointmentId)
        {
            this.notificationService.DeleteUpcomingAppointmentNotification(appointmentId);
        }

        /// <summary>
        /// `Adds medication reminder notifications for a specific medical record.
        /// </summary>
        /// <param name="medicalRecordId">the id of the medical report.</param>
        public void AddMedicationReminderNotifications(int medicalRecordId)
        {
            this.notificationService.AddMedicationReminderNotifications(medicalRecordId);
        }

        /// <summary>
        /// / Adds a new review.
        /// </summary>
        /// <param name="reviewId">The review Id.</param>
        public void AddReviewResultsNotification(int reviewId)
        {
            this.notificationService.AddReviewResultsNotification(reviewId);
        }

        private string GetUpcomingAppointmentNotificationMessage(string datetime, string doctorName, string location)
        {
            return this.notificationService.GetUpcomingAppointmentNotificationMessage(datetime, doctorName, location);
        }

        /// <summary>
        /// Get the appointment cancel notification message.
        /// </summary>
        /// <param name="patientName">The patient name.</param>
        /// <param name="datetime">The date and time.</param>
        /// <param name="location">The location.</param>
        /// <returns>The appointment cancel notification.</returns>
        private string GetAppointmentCancelNotificationMessage(string patientName, string datetime, string location)
        {
            return this.notificationService.GetAppointmentCancelNotificationMessage(patientName, datetime, location);
        }

        /// <summary>
        ///  Get the review notification message.
        /// </summary>
        /// <param name="doctorName">The name of the doctor.</param>
        /// <param name="message">The message.</param>
        /// <param name="numberStarts">The number of stars.</param>
        /// <returns>The review notification.</returns>
        private string GetReviewNotificationMessage(string doctorName, string message, int numberStarts)
        {
            return this.notificationService.GetReviewNotificationMessage(doctorName, message, numberStarts);
        }

        /// <summary>
        /// Get the medication reminder notification message.
        /// </summary>
        /// <param name="drugName">The drug name.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="administration">The administration.</param>
        /// <returns>The The notification reminder.</returns>
        private string GetMedicationReminderNotificationMessage(string drugName, double quantity, string administration)
        {
            return this.notificationService.GetMedicationReminderNotificationMessage(drugName, quantity, administration);
        }
    }
}