using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.ModelViews
{
    public interface INotificationModelView
    {
        /// <summary>
        /// add a notification
        /// </summary>
        /// <param name="userId"></param>
        public void LoadNotifications(int userId);

        /// <summary>
        /// get all notifications
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteNotification(int userId);


        /// <summary>
        /// add an appointment
        /// </summary>
        public void AddNewAppointment();

        /// <summary>
        /// add an upcoming appointment 
        /// </summary>
        /// <param name="appointmentId"></param>
        public void AddUpcomingAppointmentNotification(int appointmentId);

        /// <summary>
        /// add a cancel appointment notification
        /// </summary>
        /// <param name="appointmentId"></param>
        public void AddCancelAppointmentNotification(int appointmentId);


        /// <summary>
        /// delete an appointment notification
        /// </summary>
        /// <param name="appointmentId"></param>
        public void DeleteUpcomingAppointmentNotification(int appointmentId);

        /// <summary>
        /// add a medication reminder notification
        /// </summary>
        /// <param name="medicalRecordId"></param>
        public void AddMedicationReminderNotifications(int medicalRecordId);

        /// <summary>
        /// delete an appointment
        /// </summary>
        public void DeleteAppointment();

        /// <summary>
        /// add a treatment
        /// </summary>
        public void AddNewTreatment();

        /// <summary>
        /// add a review results notification
        /// </summary>
        /// <param name="reviewId"></param>
        public void AddReviewResultsNotification(int reviewId);

        /// <summary>
        /// add a review
        /// </summary>
        public void AddNewReview();
    }
}
