using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AppointmentNotification
{
    public int Id { get; set; }
    public int NotificationId { get; set; }
    public int AppointmentId { get; set; }
   public AppointmentNotification(int id, int notificationId, int appointmentId)
    {
        Id = id;
        NotificationId = notificationId;
        AppointmentId = appointmentId;
    }
    public override string ToString()
    {
        return $"[AppointmentNotification] ID: {Id}, Notification ID: {NotificationId}, Appointment ID: {AppointmentId}";
    }
}
