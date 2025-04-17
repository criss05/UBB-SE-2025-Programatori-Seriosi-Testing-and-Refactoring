// <copyright file="ScheduleModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// ViewModel for managing schedules.
    /// </summary>
    public class ScheduleModelView : IScheduleModelView
    {
        private readonly IScheduleService scheduleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleModelView"/> class.
        /// </summary>
        /// <param name="scheduleService">The service responsible for schedule data access.</param>
        public ScheduleModelView(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
            this.Schedules = new ObservableCollection<Schedule>();
        }

        /// <summary>
        /// Gets the schedules.
        /// </summary>
        public ObservableCollection<Schedule> Schedules { get; private set; }

        /// <summary>
        /// Gets the schedules by doctor ID and date range.
        /// </summary>
        /// <param name="doctorId">The id of the doctor.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The schedule for the doctor.</returns>
        public List<Schedule> GetSchedulesByDoctorId(int doctorId, DateOnly startDate, DateOnly endDate)
        {
            return this.scheduleService.GetSchedulesByDoctorId(doctorId, startDate, endDate);
        }
    }
}
