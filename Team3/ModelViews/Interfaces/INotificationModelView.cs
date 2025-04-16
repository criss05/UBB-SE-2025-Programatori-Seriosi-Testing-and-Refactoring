// <copyright file="INotificationModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for the NotificationModelView.
    /// </summary>
    public interface INotificationModelView
    {
        /// <summary>
        /// add a notification.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        public void LoadNotifications(int userId);

        /// <summary>
        /// add a notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public int AddNotification(Notification notification);

        /// <summary>
        /// get a notification
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public Notification GetNotificationById(int notificationId);

        /// <summary>
        /// get all notifications fro a speficic user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        public void DeleteNotification(int userId);

        /// <summary>
        /// add an upcoming appointment.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        public void AddUpcomingAppointmentNotification(int appointmentId);

        /// <summary>
        /// add a cancel appointment notification.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        public void AddCancelAppointmentNotification(int appointmentId);

        /// <summary>
        /// delete an appointment notification.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        public void DeleteUpcomingAppointmentNotification(int appointmentId);

        /// <summary>
        /// add a medication reminder notification.
        /// </summary>
        /// <param name="medicalRecordId">The id of the appointment.</param>
        public void AddMedicationReminderNotifications(int medicalRecordId);

        /// <summary>
        /// add a review results notification.
        /// </summary>
        /// <param name="reviewId">The id of the review.</param>
        public void AddReviewResultsNotification(int reviewId);
    }
}
