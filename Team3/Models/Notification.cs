// <copyright file="Notification.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a notification for a user.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="id">The id of the notification.</param>
        /// <param name="userId">The id of the user.</param>
        /// <param name="deliveryDateTime">The delivery date.</param>
        /// <param name="message">The message.</param>
        public Notification(int id, int userId, DateTime deliveryDateTime, string message)
        {
            this.Id = id;
            this.UserId = userId;
            this.DeliveryDateTime = deliveryDateTime;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="deliveryDateTime">The delivery date.</param>
        /// <param name="message">The message.</param>
        public Notification(int userId, DateTime deliveryDateTime, string message)
        {
            this.UserId = userId;
            this.DeliveryDateTime = deliveryDateTime;
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the notification.
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
            return $"[Notification] ID: {this.Id}, Delivery: {this.DeliveryDateTime}, Message: {this.Message}";
        }
    }
}