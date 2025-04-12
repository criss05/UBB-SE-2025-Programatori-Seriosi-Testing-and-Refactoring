using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public interface IScheduleDBService
    {
        /// <summary>
        /// get all schedules
        /// </summary>
        /// <returns></returns>
        public List<Schedule> GetSchedules();
    }
}
