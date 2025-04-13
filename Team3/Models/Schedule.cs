// <copyright file="Schedule.cs" company="PlaceholderCompany">
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
    /// Represents a schedule for a doctor.
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule"/> class.
        /// </summary>
        /// <param name="scheduleId">The id of the schedule.</param>
        /// <param name="scheduleWorkDay">The schedule work day.</param>
        /// <param name="doctorId">The doctor id.</param>
        /// <param name="shifTypeId">The shift id.</param>
        public Schedule(int scheduleId, DateOnly scheduleWorkDay, int doctorId, int shifTypeId)
        {
            this.ScheduleId = scheduleId;
            this.ScheduleWorkDay = scheduleWorkDay;
            this.DoctorId = doctorId;
            this.ShiftTypeId = shifTypeId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the schedule.
        /// </summary>
        public int ScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the date of the scheduled work day.
        /// </summary>
        public DateOnly ScheduleWorkDay { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the doctor.
        /// </summary>
        public int DoctorId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the shift type.
        /// </summary>
        public int ShiftTypeId { get; set; }
    }
}
