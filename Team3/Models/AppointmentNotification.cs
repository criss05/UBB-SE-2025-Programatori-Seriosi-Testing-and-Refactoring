// <copyright file="AppointmentNotification.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    /// <summary>
    /// Represents a notification for an appointment.
    /// </summary>
    public class AppointmentNotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentNotification"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the appointment notification.</param>
        /// <param name="notificationId">The id of the notification.</param>
        /// <param name="appointmentId">The id of the appointment.</param>
        public AppointmentNotification(int id, int notificationId, int appointmentId)
        {
            this.Id = id;
            this.NotificationId = notificationId;
            this.AppointmentId = appointmentId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the appointment notification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the notification.
        /// </summary>
        public int NotificationId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the appointment.
        /// </summary>
        public int AppointmentId { get; set; }

        /// <summary>
        /// Returns a string representation of the appointment notification.
        /// </summary>
        /// <returns>String representation of the appointment notification.</returns>
        public override string ToString()
        {
            return $"AppointmentNotification(Id: {this.Id}, NotificationId: {this.NotificationId}, AppointmentId: {this.AppointmentId})";
        }
    }
}