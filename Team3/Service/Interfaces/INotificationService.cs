// <copyright file="INotificationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for the Notification Service.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Gets the list of notifications.
        /// </summary>
        List<Notification> Notifications { get; }

        /// <summary>
        /// Loads the notifications for a specific user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        void LoadNotifications(int userId);

        /// <summary>
        /// Adds a notification to the list of notifications.
        /// </summary>
        /// <param name="notification">the notification to be added.</param>
        /// <returns>The status code if succed.</returns>
        int AddNotification(Notification notification);

        /// <summary>
        /// Gets the list of notifications by its id.
        /// </summary>
        /// <param name="notificationId">The id of the notification.</param>
        /// <returns>The notification with the given id.</returns>
        Notification GetNotificationById(int notificationId);

        /// <summary>
        /// Deletes a notification from the list of notifications.
        /// </summary>
        /// <param name="notificationId">The nofitication id.</param>
        void DeleteNotification(int notificationId);

        /// <summary>
        /// Adds a notification for an upcoming appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment id.</param>
        void AddUpcomingAppointmentNotification(int appointmentId);

        /// <summary>
        /// Adds a notification for a canceled appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment id.</param>
        void AddCancelAppointmentNotification(int appointmentId);

        /// <summary>
        /// Deletes a notification for an upcoming appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment id.</param>
        void DeleteUpcomingAppointmentNotification(int appointmentId);

        /// <summary>
        /// Adds a notification for a review result.
        /// </summary>
        /// <param name="medicalRecordId">The medical record id.</param>
        void AddMedicationReminderNotifications(int medicalRecordId);

        /// <summary>
        /// Adds a notification for a review result.
        /// </summary>
        /// <param name="reviewId">the review id.</param>
        void AddReviewResultsNotification(int reviewId);

        /// <summary>
        /// Gets the message for an upcoming appointment notification.
        /// </summary>
        /// <param name="datetime">The date of the appointment.</param>
        /// <param name="doctorName">The doctor's name.</param>
        /// <param name="location">The location.</param>
        /// <returns>The string with the notification.</returns>
        string GetUpcomingAppointmentNotificationMessage(string datetime, string doctorName, string location);

        /// <summary>
        /// Gets the message for a canceled appointment notification.
        /// </summary>
        /// <param name="patientName">Patient name.</param>
        /// <param name="datetime">The date of the appointment.</param>
        /// <param name="location">The location.</param>
        /// <returns>The string with the notification.</returns>
        string GetAppointmentCancelNotificationMessage(string patientName, string datetime, string location);

        /// <summary>
        /// Gets the message for a review result notification.
        /// </summary>
        /// <param name="doctorName">The doctor's name.</param>
        /// <param name="message">The message.</param>
        /// <param name="numberStarts">The number of stars.</param>
        /// <returns>The string with the review notification.</returns>
        string GetReviewNotificationMessage(string doctorName, string message, int numberStarts);

        /// <summary>
        /// Gets the message for a medication reminder notification.
        /// </summary>
        /// <param name="drugName">The name of the drug.</param>
        /// <param name="quantity">The quantity of the drug.</param>
        /// <param name="administration">The administration.</param>
        /// <returns>The string with the reminder.</returns>
        string GetMedicationReminderNotificationMessage(string drugName, double quantity, string administration);
    }
}
