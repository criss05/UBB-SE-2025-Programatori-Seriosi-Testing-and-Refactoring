namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// ViewModel for managing schedules.
    /// </summary>
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository scheduleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleService"/> class.
        /// </summary>
        /// <param name="scheduleRepository">The service responsible for schedule data access.</param>
        public ScheduleService(IScheduleRepository _scheduleRepository)
        {
            this.scheduleRepository = _scheduleRepository;
        }

        /// <summary>
        /// Gets the schedules by doctor ID and date range.
        /// </summary>
        /// <param name="doctorId">The id of the doctor.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The schedule for the doctor.</returns>
        public List<Schedule> GetSchedulesByDoctorId(int doctorId, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var schedules = scheduleRepository.GetAllSchedules();
                var filteredSchedules = new List<Schedule>();

                foreach (var schedule in schedules)
                {
                    if (schedule.DoctorId == doctorId &&
                        schedule.ScheduleWorkDay >= startDate &&
                        schedule.ScheduleWorkDay <= endDate)
                    {
                        filteredSchedules.Add(schedule);
                    }
                }

                return filteredSchedules;
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error while filtering schedules: {exception.Message}");
                throw;
            }
        }
    }
}
