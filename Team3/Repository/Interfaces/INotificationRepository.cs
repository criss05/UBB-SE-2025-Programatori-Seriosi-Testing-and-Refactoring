// <copyright file="INotificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for Notification Repository.
    /// </summary>
    public interface INotificationRepository
    {
        /// <summary>
        /// Get all notifications.
        /// </summary>
        /// <returns>The list of notifications.</returns>
        public List<Notification> GetNotifications();

        /// <summary>
        /// get notifications from a specific user by userId.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The list of notifications for the given user.</returns>
        public List<Notification> GetUserNotifications(int userId);

        /// <summary>
        /// get notification for  specific appointment by Id.
        /// </summary>
        /// <param name="appointmentId">The appointment id.</param>
        /// <returns>The appointment notifications.</returns>
        public AppointmentNotification GetNotificationAppointmentByAppointmentId(int appointmentId);

        /// <summary>
        /// Add a notification.
        /// </summary>
        /// <param name="notification">The notification to be added.</param>
        /// <returns>the status code if succed.</returns>
        public int AddNotification(Notification notification);

        /// <summary>
        /// get a notification.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        /// <returns>The notification with the given id.</returns>
        public Notification GetNotificationById(int notificationId);

        /// <summary>
        /// add a notification for a specific appointment.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        /// <param name="appointmentId">The appointment id.</param>
        public void AddAppointmentNotification(int notificationId, int appointmentId);

        /// <summary>
        /// delete a notificatioon using it's is.
        /// </summary>
        /// <param name="notificationId">The notification id that is deleted.</param>
        public void DeleteNotification(int notificationId);

        /// <summary>
        /// detele all notifications.
        /// </summary>
        public void DeleteAllNotifications();
    }
}
