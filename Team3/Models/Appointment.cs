using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Location { get; set; }
        public Appointment(int id, int doctorId, int patientId, DateTime appointmentDateTime, string location)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentDateTime = appointmentDateTime;
            Location = location;
        }
        override public string ToString()
        {
            return $"Appointment(Id: {Id}, DoctorId: {DoctorId}, PatientId: {PatientId}, AppointmentDate: {AppointmentDateTime}, Location: {Location})";
        }
    }
}
