using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Team3.Entities;
using Team3.Models;

namespace Team3.ModelViews
{
    public class ScheduleViewModel
    {
        private readonly ScheduleDBService _scheduleModel;
        public ObservableCollection<Schedule> Schedules { get; private set; }

        public ScheduleViewModel()
        {
            _scheduleModel = ScheduleDBService.Instance;
            Schedules = new ObservableCollection<Schedule>();
        }

        public List<Schedule> GetSchedulesByDoctorId(int doctorId, DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var schedules = _scheduleModel.GetSchedules();
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
