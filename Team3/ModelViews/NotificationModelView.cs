// <copyright file="NotificationModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Insterface for the NotificationModelView.
    /// </summary>
    public class NotificationModelView : INotificationModelView
    { 
        private static readonly string UPCOMING_APPOINTMENT_NOTIFICATION_TEMPLATE = "Tomorrow @datetime, you have an appointment with Dr. @doctor at location @location";
        private static readonly string APPOINTMENT_CANCEL_NOTIFICATION_TEMPLATE = "Patient: @patient has canceled their upcoming appointment, scheduled for @datetime at @location.";
        private static readonly string REVIEW_NOTIFICATION_TEMPLATE = "A review for doctor @doctor was added: @message; number of starts: @nrStarts";
        private static readonly string MEDICATION_REMINDER_NOTIFICATION_TEMPLATE = "It's time to take @drug, Quantity: @quantity, @administration";
        private static readonly string REVIEW_REMINDER_NOTIFICATION_TEMPLATE = "Reminder: Please leave a review for your last appointment.";
        private static readonly int HARDCODED_DOCTOR_ID = 1;
        private static readonly int HARDCODED_PATIENT_ID = 1;
        private static readonly int HARDCODED_APPOINTMENT_ID = 4;
        private static readonly int HARDCODED_MEDICALRECORD_ID = 1;
        private static readonly int HARDCODED_REVIEW_ID = 1;

        private readonly INotificationDatabaseService notificationModel;
        private readonly IAppointmentModelView appointmentModelView;
        private readonly IDoctorModelView doctorModelView;
        private readonly IUserModelView userModelView;
        private readonly IPatientModelView patientModelView;
        private readonly IMedicalRecordModelView medicalRecordModelView;
        private readonly ITreatmentModelView treatmentModelView;
        private readonly ITreatmentDrugModelView treatmentDrugModelView;
        private readonly IDrugModelView drugModelView;
        private readonly IReviewModelView reviewModelView;

       

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationModelView"/> class.
        /// </summary>
        public NotificationModelView()
        {
            this.notificationModel = NotificationDatabaseService.Instance;
            this.appointmentModelView = new AppointmentModelView();
            this.doctorModelView = new DoctorModelView();
            this.patientModelView = new PatientModelView();
            this.userModelView = new UserModelView();
            this.Notifications = new List<Notification>();
            this.medicalRecordModelView = new MedicalRecordModelView();
            this.treatmentModelView = new TreatmentModelView();
            this.treatmentDrugModelView = new TreatmentDrugModelView();
            this.drugModelView = new DrugModelView();
            this.reviewModelView = new ReviewModelView();
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
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);
            List<Notification> notifications = this.notificationModel.GetUserNotifications(userId);
            Debug.WriteLine(notifications.ToString());
            notifications = notifications
                .Where(n => n.DeliveryDateTime < currentDateTime)
                .OrderByDescending(n => n.DeliveryDateTime)
                .ToList();
            foreach (Notification notification in notifications)
            {
                this.Notifications.Add(notification);
                Debug.WriteLine(notification.ToString());
            }
        }

        /// <summary>
        /// / Gets the notification by id.
        /// </summary>
        /// <param name="userId">the id of the user.</param>
        public void DeleteNotification(int userId)
        {
            this.notificationModel.deleteNotification(userId);
        }

        /// <summary>
        /// / Adds a new appointment.
        /// </summary>
        public void AddNewAppointment()
        {
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);
            Appointment appointment = new Appointment(HARDCODED_APPOINTMENT_ID, HARDCODED_DOCTOR_ID, HARDCODED_PATIENT_ID, currentDateTime.AddDays(1), "FSEGA");
            this.appointmentModelView.AddNewAppointment(appointment);
            this.AddUpcomingAppointmentNotification(HARDCODED_APPOINTMENT_ID);
        }

        /// <summary>
        /// / Adds an upcoming appointment notification.
        /// </summary>
        /// <param name="appointmentId">the id of the appointment.</param>
        public void AddUpcomingAppointmentNotification(int appointmentId)
        {
            Appointment appointment = this.appointmentModelView.GetAppointmentById(appointmentId);
            Doctor doctor = this.doctorModelView.GetDoctorById(appointment.DoctorId);
            User user = this.userModelView.GetUserById(doctor.UserId);

            Patient patient = this.patientModelView.GetPatientById(appointment.PatientId);

            Debug.WriteLine(appointment.ToString());
            Debug.WriteLine(doctor.ToString());
            Debug.WriteLine(user.ToString());

            string upcomingAppointmentNotificationMessage = this.GetUpcomingAppointmentNotificationMessage(appointment.AppointmentDateTime.ToString(), user.Name, appointment.Location);
            int notificationId = this.notificationModel.AddNotification(new Notification(patient.UserId, appointment.AppointmentDateTime.AddDays(-1), upcomingAppointmentNotificationMessage));

            Debug.WriteLine(appointment.ToString());
            Debug.WriteLine(doctor.ToString());
            Debug.WriteLine(user.ToString());
            Debug.WriteLine(notificationId.ToString());

            this.notificationModel.AddAppointmentNotification(notificationId, appointmentId);
        }

        /// <summary>
        /// / Adds a cancel appointment notification.
        /// </summary>
        /// <param name="appointmentId">the id of the appointment.</param>
        public void AddCancelAppointmentNotification(int appointmentId)
        {
            Appointment appointment = this.appointmentModelView.GetAppointmentById(appointmentId);
            Debug.WriteLine(appointment.ToString());
            Doctor doctor = this.doctorModelView.GetDoctorById(appointment.DoctorId);

            Patient patient = this.patientModelView.GetPatientById(appointment.PatientId);
            User user = this.userModelView.GetUserById(patient.UserId);

            Debug.WriteLine(appointment.ToString());
            Debug.WriteLine(doctor.ToString());
            Debug.WriteLine(user.ToString());

            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);

            string appointmentCalcelNotificationMessage = this.GetAppointmentCancelNotificationMessage(user.Name, appointment.AppointmentDateTime.ToString(), appointment.Location);
            int notificationId = this.notificationModel.AddNotification(new Notification(doctor.UserId, currentDateTime, appointmentCalcelNotificationMessage));
        }

        /// <summary>
        /// / Deletes the upcoming appointment notification.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        public void DeleteUpcomingAppointmentNotification(int appointmentId)
        {
            Appointment appointment = this.appointmentModelView.GetAppointmentById(appointmentId);

            AppointmentNotification appointmentNotification = this.notificationModel.GetNotificationAppointmentByAppointmentId(appointmentId);
            this.notificationModel.deleteNotification(appointmentNotification.NotificationId);
        }

        /// <summary>
        /// `Adds medication reminder notifications for a specific medical record.
        /// </summary>
        /// <param name="medicalRecordId">the id of the medical report.</param>
        public void AddMedicationReminderNotifications(int medicalRecordId)
        {
            MedicalRecord medicalRecord = this.medicalRecordModelView.GetMedicalRecordById(medicalRecordId);

            Debug.WriteLine(medicalRecord.ToString());

            Patient patient = this.patientModelView.GetPatientById(medicalRecord.PatientId);

            Treatment treatment = this.treatmentModelView.GetTreatmentByMedicalRecordId(medicalRecordId);
            List<TreatmentDrug> treatmentDrugs = this.treatmentDrugModelView.GetTreatmentDrugsById(treatment.Id);

            foreach (TreatmentDrug treatmentDrug in treatmentDrugs)
            {
                Drug drug = this.drugModelView.GetDrugById(treatmentDrug.DrugId);
                TimeSpan interval;
                if (treatmentDrug.Quantity == 1)
                {
                    interval = TimeSpan.Zero; // If only 1 dose, no need for intervals
                }
                else
                {
                    interval = (treatmentDrug.EndTime - treatmentDrug.StartTime) / (treatmentDrug.Quantity - 1);
                }

                Console.WriteLine($"Take the drug at the following times:");

                for (int i = 0; i < treatmentDrug.Quantity; i++)
                {
                    TimeSpan doseTime = treatmentDrug.StartTime.ToTimeSpan() + (interval * i);
                    string notificationMessage = this.GetMedicationReminderNotificationMessage(drug.Name, treatmentDrug.Quantity, drug.Administration);
                    DateOnly medicalRecordDate = DateOnly.FromDateTime(medicalRecord.MedicalRecordDateTime);
                    for (int j = 1; j <= treatmentDrug.NrDays; j++)
                    {
                        DateOnly newDate = medicalRecordDate.AddDays(j);
                        DateTime dateTimeOfMedication = newDate.ToDateTime(TimeOnly.FromTimeSpan(doseTime));
                        Notification notification = new Notification(patient.UserId, dateTimeOfMedication, notificationMessage);
                        this.notificationModel.AddNotification(notification);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the appointment.
        /// </summary>
        public void DeleteAppointment()
        {
            this.AddCancelAppointmentNotification(HARDCODED_APPOINTMENT_ID);
            this.DeleteUpcomingAppointmentNotification(HARDCODED_APPOINTMENT_ID);
        }

        /// <summary>
        /// Adds a new treatment.
        /// </summary>
        public void AddNewTreatment()
        {
            this.AddMedicationReminderNotifications(HARDCODED_MEDICALRECORD_ID);
        }

        /// <summary>
        /// / Adds a new review.
        /// </summary>
        /// <param name="reviewId">The review Id.</param>
        public void AddReviewResultsNotification(int reviewId)
        {
            Review review = this.reviewModelView.GetReviewByMedicalRecordId(reviewId);
            MedicalRecord medicalRecord = this.medicalRecordModelView.GetMedicalRecordById(review.MedicalRecordId);
            Doctor doctor = this.doctorModelView.GetDoctorById(medicalRecord.DoctorId);
            User user = this.userModelView.GetUserById(doctor.UserId);

            List<User> users = this.userModelView.GetAllUsers();

            Debug.WriteLine("Am reusit sa ajung aici");
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);

            string notificationMessage = this.GetReviewNotificationMessage(user.Name, review.Message, review.NrStars);
            foreach (User searchedUser in users)
            {
                if (searchedUser.Role.Equals("admin"))
                {
                    Notification notification = new Notification(searchedUser.Id, currentDateTime, notificationMessage);
                    Debug.WriteLine(notification.ToString());
                    this.notificationModel.AddNotification(notification);
                }
            }
        }

        /// <summary>
        /// / Adds a new review.
        /// </summary>
        public void AddNewReview()
        {
            this.AddReviewResultsNotification(HARDCODED_REVIEW_ID);
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

        private string GetReviewReminderNotificationMessage(string drugName, double quantity, string administration)
        {
            string notificationMessage = REVIEW_REMINDER_NOTIFICATION_TEMPLATE;
            return notificationMessage;
        }
    }
}