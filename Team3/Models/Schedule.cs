using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateOnly ScheduleWorkDay { get; set; }
        public int DoctorId { get; set; }
        public int ShiftTypeId { get; set; }
        public Schedule(int scheduleId, DateOnly scheduleWorkDay, int doctorId, int shifTypeId)
        {
            ScheduleId = scheduleId;
            ScheduleWorkDay = scheduleWorkDay;
            DoctorId = doctorId;
            ShiftTypeId = shifTypeId;
        }
    }
}
