// <copyright file="IScheduleViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for Schedule ViewModel.
    /// </summary>
    public interface IScheduleViewModel
    {
        /// <summary>
        /// Get schedules by doctor ID and date range.
        /// </summary>
        /// <param name="doctorId">The doctor Id.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The chedules for a specific doctor.</returns>
        public List<Schedule> GetSchedulesByDoctorId(int doctorId, DateOnly startDate, DateOnly endDate);
    }
}
