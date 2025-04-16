// <copyright file="Hospitalization.cs" company="PlaceholderCompany">
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
    /// Represents a hospitalization record for a patient.
    /// </summary>
    public class Hospitalization
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hospitalization"/> class.
        /// </summary>
        /// <param name="roomId">The room id.</param>
        /// <param name="patientId">The patient id.</param>
        /// <param name="startDateTime">The start date.</param>
        /// <param name="endDateTime">The end date.</param>
        public Hospitalization(int roomId, int patientId, DateTime startDateTime, DateTime endDateTime)
        {
            this.RoomId = roomId;
            this.PatientId = patientId;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the room where the patient is hospitalized.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the patient being hospitalized.
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the hospitalization started.
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the hospitalization ended.
        /// </summary>
        public DateTime EndDateTime { get; set; }

        public override string ToString()
        {
            return $"Hospitalization(RoomId: {this.RoomId}, PatientId: {this.PatientId}, StartDateTime: {this.StartDateTime}, EndDateTime: {this.EndDateTime})";
        }
    }
}
