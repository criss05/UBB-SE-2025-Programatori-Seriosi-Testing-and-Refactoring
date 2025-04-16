using System.Collections.Generic;
using Team3.Models;

namespace Team3.Service.Interfaces
{
    public interface INotificationService
    {
        List<Notification> Notifications { get; }

        void LoadNotifications(int userId);

        int AddNotification(Notification notification);

        Notification GetNotificationById(int notificationId);

        void DeleteNotification(int userId);

        void AddUpcomingAppointmentNotification(int appointmentId);

        void AddCancelAppointmentNotification(int appointmentId);

        void DeleteUpcomingAppointmentNotification(int appointmentId);

        void AddMedicationReminderNotifications(int medicalRecordId);

        void AddReviewResultsNotification(int reviewId);

        string GetUpcomingAppointmentNotificationMessage(string datetime, string doctorName, string location);

        string GetAppointmentCancelNotificationMessage(string patientName, string datetime, string location);

        string GetReviewNotificationMessage(string doctorName, string message, int numberStarts);

        string GetMedicationReminderNotificationMessage(string drugName, double quantity, string administration);
    }
}
