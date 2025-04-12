using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using Team3.Entities;
using Team3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Team3.ModelViews
{


    public class NotificationModelView
    {

        private readonly NotificationDBService _notificationModel;
        private readonly AppointmentModelView _appointmentModelView;
        private readonly DoctorModelView _doctorModelView;
        private readonly UserModelView _userModelView;
        private readonly PatientModelView _patientModelView;
        private readonly MedicalRecordModelView _medicalRecordModelView;
        private readonly TreatmentModelView _treatmentModelView;
        private readonly TreatmentDrugModelView treatmentDrugModelView;
        private readonly DrugModelView drugModelView;
        private readonly ReviewModelView reviewModelView;



        private readonly static string UPCOMING_APPOINTMENT_NOTIFICATION_TEMPLATE = "Tomorrow @datetime, you have an appointment with Dr. @doctor at location @location";
        private readonly static string APPOINTMENT_CANCEL_NOTIFICATION_TEMPLATE = "Patient: @patient has canceled their upcoming appointment, scheduled for @datetime at @location.";
        private readonly static string REVIEW_NOTIFICATION_TEMPLATE = "A review for doctor @doctor was added: @message; number of starts: @nrStarts";
        private readonly static string MEDICATION_REMINDER_NOTIFICATION_TEMPLATE = "It's time to take @drug, Quantity: @quantity, @administration";
        private readonly static string REVIEW_REMINDER_NOTIFICATION_TEMPLATE = "Reminder: Please leave a review for your last appointment.";

        private readonly static int HARDCODED_DOCTOR_ID = 1;
        private readonly static int HARDCODED_PATIENT_ID = 1;
        private readonly static int HARDCODED_APPOINTMENT_ID = 4;

        private readonly static int HARDCODED_MEDICALRECORD_ID = 1;

        private readonly static int HARDCODED_REVIEW_ID = 1;






        private string GetUpcomingAppointmentNotificationMessage(string datetime, string doctorName, string location)
        {
            string notificationMessage = UPCOMING_APPOINTMENT_NOTIFICATION_TEMPLATE;
            notificationMessage = notificationMessage.Replace("@datetime", datetime);
            notificationMessage = notificationMessage.Replace("@doctor", doctorName);
            notificationMessage = notificationMessage.Replace("@location", location);
            return notificationMessage;

        }


        private string GetAppointmentCancelNotificationMessage(string patientName, string datetime, string location)
        {
            string notificationMessage = APPOINTMENT_CANCEL_NOTIFICATION_TEMPLATE;
            notificationMessage = notificationMessage.Replace("@patient", patientName);
            notificationMessage = notificationMessage.Replace("@datetime", datetime);
            notificationMessage = notificationMessage.Replace("@location", location);
            return notificationMessage;
        }


        private string GetReviewNotificationMessage(string doctorName, string message, int @nrStarts)
        {
            string notificationMessage = REVIEW_NOTIFICATION_TEMPLATE;
            notificationMessage = notificationMessage.Replace("@doctor", doctorName);
            notificationMessage = notificationMessage.Replace("@message", message);
            notificationMessage = notificationMessage.Replace("@nrStarts", nrStarts.ToString());
            return notificationMessage;

        }



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

        public List<Notification> Notifications { get; private set; }

        public NotificationModelView()
        {
            _notificationModel = NotificationDBService.Instance;
            _appointmentModelView = new AppointmentModelView(); ;
            _doctorModelView = new DoctorModelView();
            _patientModelView = new PatientModelView();
            _userModelView = new UserModelView();
            Notifications = new List<Notification>();
            _medicalRecordModelView = new MedicalRecordModelView();
            _treatmentModelView = new TreatmentModelView();
            treatmentDrugModelView = new TreatmentDrugModelView();
            drugModelView = new DrugModelView();
            reviewModelView = new ReviewModelView();

        }

        public void LoadNotifications(int userId)
        {

            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);

            List<Notification> notifications = _notificationModel.GetUserNotifications(userId);
            Debug.WriteLine(notifications.ToString());
            notifications = notifications
                .Where(n => n.DeliveryDateTime < currentDateTime)
                .OrderByDescending(n => n.DeliveryDateTime)
                .ToList();
            foreach(Notification notification in notifications)
            {
                Notifications.Add(notification);
                Debug.WriteLine(notification.ToString());
            }
        }

        public void DeleteNotification(int userId)
        {
            _notificationModel.deleteNotification(userId);
        }

        public void AddAppointment()
        {
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);

            Appointment appointment = new Appointment(HARDCODED_APPOINTMENT_ID, HARDCODED_DOCTOR_ID, HARDCODED_PATIENT_ID, currentDateTime.AddDays(1), "FSEGA");

            _appointmentModelView.AddAppointment(appointment);
            AddUpcomingAppointmentNotification(HARDCODED_APPOINTMENT_ID);

        }


        public void AddUpcomingAppointmentNotification(int appointmentId)
        {

            Appointment appointment = _appointmentModelView.GetAppointment(appointmentId);
            Doctor doctor = _doctorModelView.GetDoctor(appointment.DoctorId);
            User user = _userModelView.GetUser(doctor.UserId);

            Patient patient = _patientModelView.GetPatient(appointment.PatientId);

            Debug.WriteLine(appointment.ToString());
            Debug.WriteLine(doctor.ToString());
            Debug.WriteLine(user.ToString());

            string upcomingAppointmentNotificationMessage = GetUpcomingAppointmentNotificationMessage(appointment.AppointmentDateTime.ToString(), user.Name, appointment.Location);
            int notificationId = _notificationModel.AddNotification(new Notification(patient.UserId,appointment.AppointmentDateTime.AddDays(-1), upcomingAppointmentNotificationMessage));

            Debug.WriteLine(appointment.ToString());
            Debug.WriteLine(doctor.ToString());
            Debug.WriteLine(user.ToString());
            Debug.WriteLine(notificationId.ToString());

            _notificationModel.AddAppointmentNotification(notificationId, appointmentId);
        }




        public void AddCancelAppointmentNotification(int appointmentId)
        {
            Appointment appointment = _appointmentModelView.GetAppointment(appointmentId);
            Debug.WriteLine(appointment.ToString());
            Doctor doctor = _doctorModelView.GetDoctor(appointment.DoctorId);

            Patient patient = _patientModelView.GetPatient(appointment.PatientId);
            User user = _userModelView.GetUser(patient.UserId);


            Debug.WriteLine(appointment.ToString());
            Debug.WriteLine(doctor.ToString());
            Debug.WriteLine(user.ToString());


            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);

            string appointmentCalcelNotificationMessage = GetAppointmentCancelNotificationMessage(user.Name, appointment.AppointmentDateTime.ToString(), appointment.Location);
            int notificationId = _notificationModel.AddNotification(new Notification(doctor.UserId, currentDateTime, appointmentCalcelNotificationMessage));


        }



        public void DeleteUpcomingAppointmentNotification(int appointmentId)
        {
            Appointment appointment = _appointmentModelView.GetAppointment(appointmentId);

            AppointmentNotification appointmentNotification = _notificationModel.GetNotificationAppointmentByAppointmentId(appointmentId);
            _notificationModel.deleteNotification(appointmentNotification.NotificationId);
        }


        public void AddMedicationReminderNotifications(int medicalRecordId)
        {
            MedicalRecord medicalRecord =this._medicalRecordModelView.GetMedicalRecord(medicalRecordId);

            Debug.WriteLine(medicalRecord.ToString());

            Patient patient = this._patientModelView.GetPatient(medicalRecord.PatientId);

            Treatment treatment = this._treatmentModelView.GetTreatmentByMedicalRecordId(medicalRecordId);
            List<TreatmentDrug> treatmentDrugs = this.treatmentDrugModelView.getTreatmentDrugsByTreatmentId(treatment.Id);


            foreach(TreatmentDrug treatmentDrug in treatmentDrugs){
                Drug drug = this.drugModelView.getDrug(treatmentDrug.DrugId);
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
                    string notificationMessage = GetMedicationReminderNotificationMessage(drug.Name, treatmentDrug.Quantity, drug.Administration);
                    DateOnly medicalRecordDate = DateOnly.FromDateTime(medicalRecord.MedicalRecordDateTime);
                    for (int j = 1; j <= treatmentDrug.NrDays; j++)
                    {
                        DateOnly newDate = medicalRecordDate.AddDays(j);
                        DateTime dateTimeOfMedication = newDate.ToDateTime(TimeOnly.FromTimeSpan(doseTime));
                        Notification notification = new Notification(patient.UserId, dateTimeOfMedication, notificationMessage);
                        this._notificationModel.AddNotification(notification);
                    }
                }
            }

        }

        //private void deleteUpcomingAppointmentNotification(int appo)

        public void DeleteAppointment()
        {
            AddCancelAppointmentNotification(HARDCODED_APPOINTMENT_ID);
            DeleteUpcomingAppointmentNotification(HARDCODED_APPOINTMENT_ID);

        }

        public void AddTreatment()
        {
            AddMedicationReminderNotifications(HARDCODED_MEDICALRECORD_ID);
        }


        public void AddReviewResultsNotification(int reviewId)
        {
            Review review = this.reviewModelView.getReview(reviewId);
            MedicalRecord medicalRecord = this._medicalRecordModelView.GetMedicalRecord(review.MedicalRecordId);
            Doctor doctor = this._doctorModelView.GetDoctor(medicalRecord.DoctorId);
            User user = this._userModelView.GetUser(doctor.UserId);

            List<User> users = this._userModelView.GetUsers();

            Debug.WriteLine("Am reusit sa ajung aici");
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);

            string notificationMessage = GetReviewNotificationMessage(user.Name, review.Message, review.NrStars);
            foreach(User searchedUser in users)
            {
                if (searchedUser.Role.Equals("admin"))
                {
                    Notification notification = new Notification(searchedUser.Id, currentDateTime, notificationMessage);
                    Debug.WriteLine(notification.ToString());
                    this._notificationModel.AddNotification(notification);
                }
            }
        }

        public void AddReview()
        {
            AddReviewResultsNotification(HARDCODED_REVIEW_ID);
        }
    }
}