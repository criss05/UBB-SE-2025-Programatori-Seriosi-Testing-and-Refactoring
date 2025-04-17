// <copyright file="Schedule.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;

    /// <summary>
    /// Represents a schedule for a doctor.
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule"/> class.
        /// </summary>
        /// <param name="id">The schedule ID.</param>
        /// <param name="scheduleWorkDay">The schedule work day.</param>
        /// <param name="doctorId">The doctor ID.</param>
        /// <param name="shiftTypeId">The shift type ID.</param>
        public Schedule(int id, DateOnly scheduleWorkDay, int doctorId, int shiftTypeId)
        {
            this.Id = id;
            this.ScheduleWorkDay = scheduleWorkDay;
            this.DoctorId = doctorId;
            this.ShiftTypeId = shiftTypeId;
        }

        /// <summary>
        /// Gets or sets the unique ID of the schedule.
        /// </summary>
        public int Id { get; set; }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Schedule(Id: {this.Id}, ScheduleWorkDay: {this.ScheduleWorkDay}, DoctorId: {this.DoctorId}, ShiftTypeId: {this.ShiftTypeId})";
        }
    }
}