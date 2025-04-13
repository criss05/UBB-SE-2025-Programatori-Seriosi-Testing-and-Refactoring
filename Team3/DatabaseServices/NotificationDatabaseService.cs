using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Team3.DatabaseServices;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public class NotificationDatabaseService : INotificationDatabaseService
    {
        private static NotificationDatabaseService? instance;
        private readonly Config config;
        private static readonly object LockObject = new object();
        private NotificationDatabaseService()
        {
            config = Config.Instance;
        }
        public static NotificationDatabaseService Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = new NotificationDatabaseService();
                    }
                    return instance;
                }
            }
        }

        public List<Notification> GetNotifications()
        {
            const string query = "SELECT * FROM Notifications;";
            List<Notification> notifications = new List<Notification>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
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
                                reader[3].ToString()
                            ));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving notifications", e);
            }

            return notifications;
        }



        public List<Notification> GetUserNotifications(int userId)
        {
            const string query = "SELECT * FROM Notifications WHERE user_id = @user_id;";
            List<Notification> notifications = new List<Notification>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
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
                                reader[3].ToString()
                            ));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving notifications", e);
            }

            return notifications;
        }



        public AppointmentNotification GetNotificationAppointmentByAppointmentId(int appointmentId)
        {
            const string query = "SELECT * FROM appointment_notifications WHERE appointment_id = @appointment_id";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
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
            catch (Exception e)
            {
                throw new Exception("Error retrieving notification appointment", e);
            }
        }

        public int AddNotification(Notification notification)
        {
            const string query = "INSERT INTO notifications (user_id, delivery_datetime, message) VALUES (@user_id, @delivery_datetime, @message); SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", notification.UserId);
                    command.Parameters.AddWithValue("@delivery_datetime", notification.DeliveryDateTime);
                    command.Parameters.AddWithValue("@message", notification.Message);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding notification", e);
            }
        }


        public void AddAppointmentNotification(int notificationId, int appointmentId)
        {
            const string query = "INSERT INTO appointment_notifications (notification_id, appointment_id) VALUES (@notification_id, @appointment_id);";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@notification_id", notificationId);
                    command.Parameters.AddWithValue("@appointment_id", appointmentId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding appointment notification", e);
            }
        }



        public void deleteNotification(int id)
        {
            const string query = "DELETE FROM notifications WHERE id = @id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding appointment notification", e);
            }
        }


        public void deleteAllNotifications()
        {
            const string query = "DELETE FROM notifications";

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.DATABASE_CONNECTION_STRING))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding appointment notification", e);
            }
        }


    }
}
