// <copyright file="NotificationModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// Insterface for the NotificationModelView.
    /// </summary>
    public class NotificationModelView : INotificationModelView
    { 
        private static readonly string UPCOMING_APPOINTMENT_NOTIFICATION_TEMPLATE = "Tomorrow @datetime, you have an appointment with Dr. @doctor at location @location";
        private static readonly string APPOINTMENT_CANCEL_NOTIFICATION_TEMPLATE = "Patient: @patient has canceled their upcoming appointment, scheduled for @datetime at @location.";
        private static readonly string REVIEW_NOTIFICATION_TEMPLATE = "A review for doctor @doctor was added: @message; number of starts: @nrStarts";
        private static readonly string MEDICATION_REMINDER_NOTIFICATION_TEMPLATE = "It's time to take @drug, Quantity: @quantity, @administration";

        private readonly INotificationDatabaseService notificationDatabaseService;

        private readonly IAppointmentModelView appointmentModelView;
        private readonly IDoctorModelView doctorModelView;
        private readonly IUserModelView userModelView;
        private readonly IPatientModelView patientModelView;
        private readonly IMedicalRecordModelView medicalRecordModelView;
        private readonly IDrugModelView drugModelView;
        private readonly ITreatmentDrugModelView treatmentDrugModelView;
        private readonly ITreatmentModelView treatmentModelView;
        private readonly IReviewModelView reviewModelView;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationModelView"/> class.
        /// </summary>
        public NotificationModelView(IAppointmentModelView _appointmentModelView, IDoctorModelView doctorModelView, IUserModelView userModelView, IPatientModelView patientModelView, IMedicalRecordModelView medicalRecordModelView, IDrugModelView drugModelView, ITreatmentDrugModelView treatmentDrugModelView, ITreatmentModelView treatmentModelView, IReviewModelView reviewModelView)
        {
            notificationDatabaseService = new NotificationDatabaseService(Config.DbConnectionString);
            appointmentModelView = _appointmentModelView;
            this.doctorModelView = doctorModelView;
            this.userModelView = userModelView;
            this.patientModelView = patientModelView;
            this.medicalRecordModelView = medicalRecordModelView;
            this.drugModelView = drugModelView;
            this.treatmentDrugModelView = treatmentDrugModelView;
            this.treatmentModelView = treatmentModelView;
            this.reviewModelView = reviewModelView;
        }

        /// <summary>
        ///     Gets the list of notifications.
        /// </summary>
        public List<Notification> Notifications { get; private set; }

        /// <summary>
        /// Loads the notifications for a specific user.
        /// </summary>
        /// <param name="userId">User id.</param>
        public void LoadNotifications(int userId)
        {
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Utc);
            List<Notification> notifications = notificationDatabaseService.GetUserNotifications(userId);
            notifications = notifications
                .Where(n => n.DeliveryDateTime < currentDateTime)
                .OrderByDescending(n => n.DeliveryDateTime)
                .ToList();
            foreach (Notification notification in notifications)
            {
                Notifications.Add(notification);
            }
        }

        /// <summary>
        /// / Gets the notification by id.
        /// </summary>
        /// <param name="userId">the id of the user.</param>
        public void DeleteNotification(int userId)
        {
            notificationDatabaseService.DeleteNotification(userId);
        }

        /// <summary>
        /// / Adds an upcoming appointment notification.
        /// </summary>
        /// <param name="appointmentId">the id of the appointment.</param>
        public void AddUpcomingAppointmentNotification(int appointmentId)
        {
            Appointment appointment = appointmentModelView.GetAppointmentById(appointmentId);
            Doctor doctor = doctorModelView.GetDoctorById(appointment.DoctorId);
            User user = userModelView.GetUserById(doctor.UserId);

            Patient patient = patientModelView.GetPatientById(appointment.PatientId);

            string upcomingAppointmentNotificationMessage = GetUpcomingAppointmentNotificationMessage(appointment.AppointmentDateTime.ToString(), user.Name, appointment.Location);
            int notificationId = notificationDatabaseService.AddNotification(new Notification(patient.UserId, appointment.AppointmentDateTime.AddDays(-1), upcomingAppointmentNotificationMessage));

            notificationDatabaseService.AddAppointmentNotification(notificationId, appointmentId);
        }

        /// <summary>
        /// / Adds a cancel appointment notification.
        /// </summary>
        /// <param name="appointmentId">the id of the appointment.</param>
        public void AddCancelAppointmentNotification(int appointmentId)
        {
            Appointment appointment = appointmentModelView.GetAppointmentById(appointmentId);
            Debug.WriteLine(appointment.ToString());
            Doctor doctor = doctorModelView.GetDoctorById(appointment.DoctorId);

            Patient patient = patientModelView.GetPatientById(appointment.PatientId);
            User user = userModelView.GetUserById(patient.UserId);

            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Utc);

            string appointmentCalcelNotificationMessage = GetAppointmentCancelNotificationMessage(user.Name, appointment.AppointmentDateTime.ToString(), appointment.Location);
            int notificationId = notificationDatabaseService.AddNotification(new Notification(doctor.UserId, currentDateTime, appointmentCalcelNotificationMessage));
        }

        /// <summary>
        /// / Deletes the upcoming appointment notification.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        public void DeleteUpcomingAppointmentNotification(int appointmentId)
        {
            Appointment appointment = appointmentModelView.GetAppointmentById(appointmentId);

            AppointmentNotification appointmentNotification = notificationDatabaseService.GetNotificationAppointmentByAppointmentId(appointmentId);
            notificationDatabaseService.DeleteNotification(appointmentNotification.NotificationId);
        }

        /// <summary>
        /// `Adds medication reminder notifications for a specific medical record.
        /// </summary>
        /// <param name="medicalRecordId">the id of the medical report.</param>
        public void AddMedicationReminderNotifications(int medicalRecordId)
        {
            MedicalRecord medicalRecord = medicalRecordModelView.GetMedicalRecordById(medicalRecordId);

            Patient patient = patientModelView.GetPatientById(medicalRecord.PatientId);

            Treatment treatment = treatmentModelView.GetTreatmentByMedicalRecordId(medicalRecordId);
            List<TreatmentDrug> treatmentDrugs = treatmentDrugModelView.GetTreatmentDrugsById(treatment.Id);

            foreach (TreatmentDrug treatmentDrug in treatmentDrugs)
            {
                Drug drug = drugModelView.GetDrugById(treatmentDrug.DrugId);
                TimeSpan interval;
                if (treatmentDrug.Quantity == 1)
                {
                    interval = TimeSpan.Zero; // If only 1 dose, no need for intervals
                }
                else
                {
                    interval = (treatmentDrug.EndTime - treatmentDrug.StartTime) / (treatmentDrug.Quantity - 1);
                }

                for (int i = 0; i < treatmentDrug.Quantity; i++)
                {
                    TimeSpan doseTime = treatmentDrug.StartTime.ToTimeSpan() + interval * i;
                    string notificationMessage = GetMedicationReminderNotificationMessage(drug.Name, treatmentDrug.Quantity, drug.Administration);
                    DateOnly medicalRecordDate = DateOnly.FromDateTime(medicalRecord.MedicalRecordDateTime);
                    for (int j = 1; j <= treatmentDrug.NrDays; j++)
                    {
                        DateOnly newDate = medicalRecordDate.AddDays(j);
                        DateTime dateTimeOfMedication = newDate.ToDateTime(TimeOnly.FromTimeSpan(doseTime));
                        Notification notification = new Notification(patient.UserId, dateTimeOfMedication, notificationMessage);
                        notificationDatabaseService.AddNotification(notification);
                    }
                }
            }
        }


        /// <summary>
        /// / Adds a new review.
        /// </summary>
        /// <param name="reviewId">The review Id.</param>
        public void AddReviewResultsNotification(int reviewId)
        {
            Review review = reviewModelView.GetReviewByMedicalRecordId(reviewId);
            MedicalRecord medicalRecord = medicalRecordModelView.GetMedicalRecordById(review.MedicalRecordId);
            Doctor doctor = doctorModelView.GetDoctorById(medicalRecord.DoctorId);
            User user = userModelView.GetUserById(doctor.UserId);

            List<User> users = userModelView.GetAllUsers();

            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Utc);

            string notificationMessage = GetReviewNotificationMessage(user.Name, review.Message, review.NrStars);
            foreach (User searchedUser in users)
            {
                if (searchedUser.Role.Equals("admin"))
                {
                    Notification notification = new Notification(searchedUser.Id, currentDateTime, notificationMessage);
                    notificationDatabaseService.AddNotification(notification);
                }
            }
        }

        private string GetUpcomingAppointmentNotificationMessage(string datetime, string doctorName, string location)
        {
            string notificationMessage = UPCOMING_APPOINTMENT_NOTIFICATION_TEMPLATE;
            notificationMessage = notificationMessage.Replace("@datetime", datetime);
            notificationMessage = notificationMessage.Replace("@doctor", doctorName);
            notificationMessage = notificationMessage.Replace("@location", location);
            return notificationMessage;
        }

        /// <summary>
        /// Get the appointment cancel notification message.
        /// </summary>
        /// <param name="patientName">The patient name.</param>
        /// <param name="datetime">The date and time.</param>
        /// <param name="location">The location.</param>
        /// <returns>The appointment cancel notification.</returns>
        private string GetAppointmentCancelNotificationMessage(string patientName, string datetime, string location)
        {
            string notificationMessage = APPOINTMENT_CANCEL_NOTIFICATION_TEMPLATE;
            notificationMessage = notificationMessage.Replace("@patient", patientName);
            notificationMessage = notificationMessage.Replace("@datetime", datetime);
            notificationMessage = notificationMessage.Replace("@location", location);
            return notificationMessage;
        }

        /// <summary>
        ///  Get the review notification message.
        /// </summary>
        /// <param name="doctorName">The name of the doctor.</param>
        /// <param name="message">The message.</param>
        /// <param name="numberStarts">The number of stars.</param>
        /// <returns>The review notification.</returns>
        private string GetReviewNotificationMessage(string doctorName, string message, int numberStarts)
        {
            string notificationMessage = REVIEW_NOTIFICATION_TEMPLATE;
            notificationMessage = notificationMessage.Replace("@doctor", doctorName);
            notificationMessage = notificationMessage.Replace("@message", message);
            notificationMessage = notificationMessage.Replace("@nrStarts", numberStarts.ToString());
            return notificationMessage;
        }

        /// <summary>
        /// Get the medication reminder notification message.
        /// </summary>
        /// <param name="drugName">The drug name.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="administration">The administration.</param>
        /// <returns>The The notification reminder.</returns>
        private string GetMedicationReminderNotificationMessage(string drugName, double quantity, string administration)
        {
            string notificationMessage = MEDICATION_REMINDER_NOTIFICATION_TEMPLATE;
            notificationMessage = notificationMessage.Replace("@drug", drugName);
            notificationMessage = notificationMessage.Replace("@quantity", quantity.ToString());
            notificationMessage = notificationMessage.Replace("@administration", administration);
            return notificationMessage;
        }
    }
}