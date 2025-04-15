namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// ViewModel for managing schedules.
    /// </summary>
    public class ScheduleModelView : IScheduleViewModel
    {
        private readonly IScheduleDatabaseService scheduleDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleModelView"/> class.
        /// </summary>
        /// <param name="scheduleDatabaseService">The service responsible for schedule data access.</param>
        public ScheduleModelView(IScheduleDatabaseService scheduleDatabaseService)
        {
            this.scheduleDatabaseService = scheduleDatabaseService;
            Schedules = new ObservableCollection<Schedule>();
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
            try
            {
                var schedules = scheduleDatabaseService.GetAllSchedules();
                var filteredSchedules = new List<Schedule>();

                foreach (var schedule in schedules)
                {
                    if (schedule.DoctorId == doctorId &&
                        schedule.ScheduleWorkDay >= startDate &&
                        schedule.ScheduleWorkDay <= endDate)
                    {
                        filteredSchedules.Add(schedule);
                        Debug.WriteLine(schedule.ToString());
                    }
                }

                if (!filteredSchedules.Any())
                {
                    Debug.WriteLine($"No schedules found for Doctor ID {doctorId} in the specified date range.");
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
