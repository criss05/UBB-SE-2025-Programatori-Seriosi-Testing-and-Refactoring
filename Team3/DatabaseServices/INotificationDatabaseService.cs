using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public interface INotificationDatabaseService
    {
        /// <summary>
        /// get all notifications
        /// </summary>
        /// <returns></returns>
        public List<Notification> GetNotifications();

        /// <summary>
        /// get notifications from a specific user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Notification> GetUserNotifications(int userId);

        /// <summary>
        /// get notification for  specific appointment by Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public AppointmentNotification GetNotificationAppointmentByAppointmentId(int appointmentId);

        /// <summary>
        /// add a notification
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public int AddNotification(Notification notification);

        /// <summary>
        /// add a notification for a specific appointment
        /// </summary>
        /// <param name="notificationId"></param>
        /// <param name="appointmentId"></param>
        public void AddAppointmentNotification(int notificationId, int appointmentId);

        /// <summary>
        /// delete a notificatioon using it's is
        /// </summary>
        /// <param name="id"></param>
        public void deleteNotification(int id);

        /// <summary>
        /// detele all notifications
        /// </summary>
        public void deleteAllNotifications();
    }
}
