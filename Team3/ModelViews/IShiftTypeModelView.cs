using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IShiftTypeModelView
    {
        /// <summary>
        /// Loads the shift types from a specific time range
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<ShiftType> GetShiftTypesByTimeRange(TimeOnly startTime, TimeOnly endTime);

        /// <summary>
        /// Gets a specific shift type
        /// </summary>
        /// <param name="shiftTypeID"></param>
        /// <returns></returns>
        public ShiftType? GetShiftType(int shiftTypeID);
    }
}
