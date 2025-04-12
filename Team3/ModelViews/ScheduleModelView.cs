using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Team3.Models;
using Team3.DatabaseServices;

namespace Team3.ModelViews
{
    public class ScheduleViewModel : IScheduleViewModel
    {

        private readonly IScheduleDBService _scheduleModel;

        public ObservableCollection<Schedule> Schedules { get; private set; }

        public ScheduleViewModel()
        {
            _scheduleModel = ScheduleDatabaseService.Instance;
            Schedules = new ObservableCollection<Schedule>();
        }

        public List<Schedule> GetSchedulesByDoctorId(int doctorId, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var schedules = _scheduleModel.GetAllSchedules();
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
            catch (Exception ex)
            {
                Debug.WriteLine($"Error while filtering schedules: {ex.Message}");
                throw;
            }
        }
    }
}
