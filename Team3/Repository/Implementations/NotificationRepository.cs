// <copyright file="NotificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Implementations
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Team3.Models;
    using Team3.Repository.Interfaces;

    /// <summary>
    /// Repository for managing notifications in the database.
    /// </summary>
    public class NotificationRepository : INotificationRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRepository"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public NotificationRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves all notifications from the database.
        /// </summary>
        /// <returns>The list of notifications.</returns>
        /// <exception cref="Exception">Throw error if failed.</exception>
        public List<Notification> GetNotifications()
        {
            const string query = "SELECT * FROM Notifications;";
            List<Notification> notifications = new List<Notification>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notifications.Add(new Notification(
                                (int)reader[0],
                                (int)reader[1],
                                (DateTime)reader[2],
                                reader[3].ToString()));
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error retrieving notifications", error);
            }

            return notifications;
        }

        /// <summary>
        /// Retrieves notifications for a specific user by userId.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The list of notiticationes for that user.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public List<Notification> GetUserNotifications(int userId)
        {
            const string query = "SELECT * FROM Notifications WHERE user_id = @user_id;";
            List<Notification> notifications = new List<Notification>();

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notifications.Add(new Notification(
                                (int)reader[0],
                                (int)reader[1],
                                (DateTime)reader[2],
                                reader[3].ToString()));
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error retrieving notifications", error);
            }

            return notifications;
        }

        /// <summary>
        /// Retrieves a notification for a specific appointment by Id.
        /// </summary>
        /// <param name="appointmentId">The appointment id.</param>
        /// <returns>The appoinemtn notifications.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public AppointmentNotification GetNotificationAppointmentByAppointmentId(int appointmentId)
        {
            const string query = "SELECT * FROM appointment_notifications WHERE appointment_id = @appointment_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@appointment_id", appointmentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AppointmentNotification((int)reader[0], (int)reader[1], (int)reader[2]);
                            }
                        }
                    }
                }

                throw new Exception("Doctor not found");
            }
            catch (Exception error)
            {
                throw new Exception("Error retrieving notification appointment", error);
            }
        }

        /// <summary>
        /// Adds a new notification to the database.
        /// </summary>
        /// <param name="notification">The notification to be added.</param>
        /// <returns>The status code if success.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public int AddNotification(Notification notification)
        {
            const string query = "INSERT INTO notifications (user_id, delivery_datetime, message) VALUES (@user_id, @delivery_datetime, @message); SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", notification.UserId);
                    command.Parameters.AddWithValue("@delivery_datetime", notification.DeliveryDateTime);
                    command.Parameters.AddWithValue("@message", notification.Message);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error adding notification", error);
            }
        }

        /// <summary>
        /// Retrieves a notification by its ID.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        /// <returns>The notification with the given id.</returns>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public Notification GetNotificationById(int notificationId)
        {
            const string query = "SELECT id, user_id, delivery_datetime, message FROM notidications WHERE id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", notificationId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                throw new Exception("Notification not found");
                            }

                            return new Notification(
                                (int)reader[0],
                                (int)reader[1],
                                (DateTime)reader[2],
                                reader[3].ToString());
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error retrieving notification", exception);
            }
        }

        /// <summary>
        /// Adds a notification for a specific appointment.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        /// <param name="appointmentId">The appointment id.</param>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public void AddAppointmentNotification(int notificationId, int appointmentId)
        {
            const string query = "INSERT INTO appointment_notifications (notification_id, appointment_id) VALUES (@notification_id, @appointment_id);";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@notification_id", notificationId);
                    command.Parameters.AddWithValue("@appointment_id", appointmentId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error adding appointment notification", error);
            }
        }

        /// <summary>
        /// Deletes a notification using its ID.
        /// </summary>
        /// <param name="notificationId">The id of the notification.</param>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public void DeleteNotification(int notificationId)
        {
            const string query = "DELETE FROM notifications WHERE id = @id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", notificationId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error deleting notification", error);
            }
        }

        /// <summary>
        /// Deletes all notifications from the database.
        /// </summary>
        /// <exception cref="Exception">Throws error if failed.</exception>
        public void DeleteAllNotifications()
        {
            const string query = "DELETE FROM notifications";

            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error deleting all notifications", error);
            }
        }
    }
}
