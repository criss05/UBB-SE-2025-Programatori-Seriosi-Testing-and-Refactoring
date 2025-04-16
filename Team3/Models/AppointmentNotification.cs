// <copyright file="AppointmentNotification.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents a notification for an appointment.
/// </summary>
public class AppointmentNotification
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppointmentNotification"/> class.
    /// </summary>
    /// <param name="id">The id of the relation between appoinment and notification.</param>
    /// <param name="notificationId">The id of the notification.</param>
    /// <param name="appointmentId">The id of the appointment.</param>
    public AppointmentNotification(int notificationId, int appointmentId)
    {
        this.NotificationId = notificationId;
        this.AppointmentId = appointmentId;
    }

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
        return $"AppointmentNotification(Notification ID: {this.NotificationId}, Appointment ID: {this.AppointmentId}";
    }
}
