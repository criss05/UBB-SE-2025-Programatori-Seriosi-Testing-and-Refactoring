// <copyright file="NotificationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Repository.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Insterface for the NotificationModelView.
    /// </summary>
    public class NotificationService : INotificationService
    {
        private static readonly string DefaultUpcommingAppointmentNotification = "Tomorrow @datetime, you have an appointment with Dr. @doctor at location @location";
        private static readonly string DefaultCancelAppointmentNotification = "Patient: @patient has canceled their upcoming appointment, scheduled for @datetime at @location.";
        private static readonly string DefaultReviewNotification = "A review for doctor @doctor was added: @message; number of starts: @nrStarts";
        private static readonly string DefaultMedicationNotificationReminder = "It's time to take @drug, Quantity: @quantity, @administration";
        private static readonly int DefaultId = 0;

        private readonly INotificationRepository notificationRepository;

        private readonly IAppointmentService appointmentService;
        private readonly IDoctorModelView doctorModelView;
        private readonly IUserService userService;
        private readonly Interfaces.IPatientService patientService;
        private readonly IMedicalRecordService medicalReportService;
        private readonly IDrugModelView drugModelView;
        private readonly ITreatmentDrugService treatmentDrugService;
        private readonly ITreatmentService treatmentService;
        private readonly IReviewService reviewService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationService"/> class.
        /// </summary>
        /// <param name="notificationRepository">the notification repository.</param>
        /// <param name="appointmentService">the appointment service.</param>
        /// <param name="doctorModelView">the doctor model view.</param>
        /// <param name="drugService">the drug service.</param>
        /// <param name="medicalReportService">the medical report service.</param>
        /// <param name="patientService">the patient service.</param>
        /// <param name="reviewService">the review service.</param>
        /// <param name="treatmentDrugService">the treatment drug service.</param>
        /// <param name="treatmentService">the treatment service.</param>
        /// <param name="userService">the user service.</param>
        public NotificationService(INotificationRepository notificationRepository, IAppointmentService appointmentService, IDoctorModelView doctorModelView, IUserService userService, IPatientService patientService, IMedicalRecordService medicalReportService, IDrugModelView drugService, ITreatmentDrugService treatmentDrugService, ITreatmentService treatmentService, IReviewService reviewService)
        {
            this.notificationRepository = notificationRepository;
            this.appointmentService = appointmentService;
            this.doctorModelView = doctorModelView;
            this.userService = userService;
            this.patientService = patientService;
            this.medicalReportService = medicalReportService;
            this.drugModelView = drugService;
            this.treatmentDrugService = treatmentDrugService;
            this.treatmentService = treatmentService;
            this.reviewService = reviewService;
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
            List<Notification> notifications = this.notificationRepository.GetUserNotifications(userId);
            notifications = notifications
                .Where(n => n.DeliveryDateTime < currentDateTime)
                .OrderByDescending(n => n.DeliveryDateTime)
                .ToList();
            foreach (Notification notification in notifications)
            {
                this.Notifications.Add(notification);
            }
        }

        /// <summary>
        /// add a notification.
        /// </summary>
        /// <param name="notification">The notification to be added.</param>
        /// <returns>The status code if succed.</returns>
        public int AddNotification(Notification notification)
        {
            return this.notificationRepository.AddNotification(notification);
        }

        /// <summary>
        /// get a notification.
        /// </summary>
        /// <param name="notificationId">The notification id.</param>
        /// <returns>The notification with the given id.</returns>
        public Notification GetNotificationById(int notificationId)
        {
            return this.notificationRepository.GetNotificationById(notificationId);
        }

        /// <summary>
        /// / Gets the notification by id.
        /// </summary>
        /// <param name="userId">the id of the user.</param>
        public void DeleteNotification(int userId)
        {
            this.notificationRepository.DeleteNotification(userId);
        }

        /// <summary>
        /// / Adds an upcoming appointment notification.
        /// </summary>
        /// <param name="appointmentId">the id of the appointment.</param>
        public void AddUpcomingAppointmentNotification(int appointmentId)
        {
            Appointment appointment = this.appointmentService.GetAppointmentById(appointmentId);
            Doctor doctor = this.doctorModelView.GetDoctorById(appointment.DoctorId);
            User user = this.userService.GetUserById(doctor.UserId);

            Patient patient = this.patientService.GetPatientById(appointment.PatientId);

            string upcomingAppointmentNotificationMessage = this.GetUpcomingAppointmentNotificationMessage(appointment.AppointmentDateTime.ToString(), user.Name, appointment.Location);
            int notificationId = this.notificationRepository.AddNotification(new Notification(DefaultId, patient.UserId, appointment.AppointmentDateTime.AddDays(-1), upcomingAppointmentNotificationMessage));

            this.notificationRepository.AddAppointmentNotification(notificationId, appointmentId);
        }

        /// <summary>
        /// / Adds a cancel appointment notification.
        /// </summary>
        /// <param name="appointmentId">the id of the appointment.</param>
        public void AddCancelAppointmentNotification(int appointmentId)
        {
            Appointment appointment = this.appointmentService.GetAppointmentById(appointmentId);
            Debug.WriteLine(appointment.ToString());
            Doctor doctor = this.doctorModelView.GetDoctorById(appointment.DoctorId);

            Patient patient = this.patientService.GetPatientById(appointment.PatientId);
            User user = this.userService.GetUserById(patient.UserId);

            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Utc);

            string appointmentCalcelNotificationMessage = this.GetAppointmentCancelNotificationMessage(user.Name, appointment.AppointmentDateTime.ToString(), appointment.Location);
            int notificationId = this.notificationRepository.AddNotification(new Notification(DefaultId, doctor.UserId, currentDateTime, appointmentCalcelNotificationMessage));
        }

        /// <summary>
        /// / Deletes the upcoming appointment notification.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        public void DeleteUpcomingAppointmentNotification(int appointmentId)
        {
            Appointment appointment = this.appointmentService.GetAppointmentById(appointmentId);

            AppointmentNotification appointmentNotification = this.notificationRepository.GetNotificationAppointmentByAppointmentId(appointmentId);
            this.notificationRepository.DeleteNotification(appointmentNotification.NotificationId);
        }

        /// <summary>
        /// `Adds medication reminder notifications for a specific medical record.
        /// </summary>
        /// <param name="medicalRecordId">the id of the medical report.</param>
        public void AddMedicationReminderNotifications(int medicalRecordId)
        {
            MedicalRecord medicalRecord = this.medicalReportService.GetMedicalRecordById(medicalRecordId);

            Patient patient = this.patientService.GetPatientById(medicalRecord.PatientId);

            Treatment treatment = this.treatmentService.GetTreatmentByMedicalRecordId(medicalRecordId);
            List<TreatmentDrug> treatmentDrugs = this.treatmentDrugService.GetTreatmentDrugsById(treatment.Id);

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

                for (int i = 0; i < treatmentDrug.Quantity; i++)
                {
                    TimeSpan doseTime = treatmentDrug.StartTime.ToTimeSpan() + (interval * i);
                    string notificationMessage = this.GetMedicationReminderNotificationMessage(drug.Name, treatmentDrug.Quantity, drug.Administration);
                    DateOnly medicalRecordDate = DateOnly.FromDateTime(medicalRecord.MedicalRecordDateTime);
                    for (int j = 1; j <= treatmentDrug.NrDays; j++)
                    {
                        DateOnly newDate = medicalRecordDate.AddDays(j);
                        DateTime dateTimeOfMedication = newDate.ToDateTime(TimeOnly.FromTimeSpan(doseTime));
                        Notification notification = new Notification(DefaultId, patient.UserId, dateTimeOfMedication, notificationMessage);
                        this.notificationRepository.AddNotification(notification);
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
            Review review = this.reviewService.GetReviewByMedicalRecordId(reviewId);
            MedicalRecord medicalRecord = this.medicalReportService.GetMedicalRecordById(review.MedicalRecordId);
            Doctor doctor = this.doctorModelView.GetDoctorById(medicalRecord.DoctorId);
            User user = this.userService.GetUserById(doctor.UserId);

            List<User> users = this.userService.GetAllUsers();

            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Utc);

            string notificationMessage = this.GetReviewNotificationMessage(user.Name, review.Message, review.NrStars);
            foreach (User searchedUser in users)
            {
                if (searchedUser.Role.Equals("admin"))
                {
                    Notification notification = new Notification(DefaultId, searchedUser.Id, currentDateTime, notificationMessage);
                    this.notificationRepository.AddNotification(notification);
                }
            }
        }

        /// <summary>
        /// Get the upcoming appointment notification message.
        /// </summary>
        /// <param name="datetime">The date and time of the notification.</param>
        /// <param name="doctorName">The doctor's name.</param>
        /// <param name="location">The location of the appointment.</param>
        /// <returns>The notification as a string.</returns>
        public string GetUpcomingAppointmentNotificationMessage(string datetime, string doctorName, string location)
        {
            string notificationMessage = DefaultUpcommingAppointmentNotification;
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
        public string GetAppointmentCancelNotificationMessage(string patientName, string datetime, string location)
        {
            string notificationMessage = DefaultCancelAppointmentNotification;
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
        public string GetReviewNotificationMessage(string doctorName, string message, int numberStarts)
        {
            string notificationMessage = DefaultReviewNotification;
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
        public string GetMedicationReminderNotificationMessage(string drugName, double quantity, string administration)
        {
            string notificationMessage = DefaultMedicationNotificationReminder;
            notificationMessage = notificationMessage.Replace("@drug", drugName);
            notificationMessage = notificationMessage.Replace("@quantity", quantity.ToString());
            notificationMessage = notificationMessage.Replace("@administration", administration);
            return notificationMessage;
        }
    }
}