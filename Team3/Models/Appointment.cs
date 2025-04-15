// <copyright file="Appointment.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an appointment in the system.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Appointment"/> class.
        /// </summary>
        /// <param name="doctorId">The doctor Id.</param>
        /// <param name="patientId">The pacient Id.</param>
        /// <param name="appointmentDateTime">The appointment date and time.</param>
        /// <param name="location">The appointment location.</param>
        public Appointment(int doctorId, int patientId, DateTime appointmentDateTime, string location)
        {
            this.DoctorId = doctorId;
            this.PatientId = patientId;
            this.AppointmentDateTime = appointmentDateTime;
            this.Location = location;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the doctor associated with the appointment.
        /// </summary>
        public int DoctorId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the patient associated with the appointment.
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the appointment.
        /// </summary>
        public DateTime AppointmentDateTime { get; set; }

        /// <summary>
        /// Gets or sets the location of the appointment.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Returns a string representation of the appointment.
        /// </summary>
        /// <returns>String representation of the appointment.</returns>
        public override string ToString()
        {
            return $"Appointment(DoctorId: {this.DoctorId}, PatientId: {this.PatientId}, AppointmentDate: {this.AppointmentDateTime}, Location: {this.Location})";
        }
    }
}
