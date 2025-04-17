// <copyright file="Notification.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;

    /// <summary>
    /// Represents a notification for a user.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="id">The notification ID.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="deliveryDateTime">The delivery date and time.</param>
        /// <param name="message">The message content.</param>
        public Notification(int id, int userId, DateTime deliveryDateTime, string message)
        {
            this.Id = id;
            this.UserId = userId;
            this.DeliveryDateTime = deliveryDateTime;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the notification.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with the notification.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the notification is scheduled to be delivered.
        /// </summary>
        public DateTime DeliveryDateTime { get; set; }

        /// <summary>
        /// Gets or sets the message content of the notification.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Returns a string representation of the notification.
        /// </summary>
        /// <returns>String representation of the notification.</returns>
        public override string ToString()
        {
            return $"Notification(Id: {this.Id}, UserId: {this.UserId}, DeliveryDateTime: {this.DeliveryDateTime}, Message: \"{this.Message}\")";
        }
    }
}