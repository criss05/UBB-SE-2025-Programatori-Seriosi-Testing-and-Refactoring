using System;
using System.Collections.Generic;
using Team3.Models;

namespace Team3.Service.Interfaces
{
    /// <summary>
    /// Interface for schedule-related services.
    /// </summary>
    public interface IScheduleService
    {
        /// <summary>
        /// Gets the schedules for a specific doctor within a date range.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>List of schedules for the specified doctor and date range.</returns>
        List<Schedule> GetSchedulesByDoctorId(int doctorId, DateOnly startDate, DateOnly endDate);

    }
}
