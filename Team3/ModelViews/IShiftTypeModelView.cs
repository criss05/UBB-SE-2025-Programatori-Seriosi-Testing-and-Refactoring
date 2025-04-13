namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for ShiftTypeModelView.
    /// </summary>
    public interface IShiftTypeModelView
    {
        /// <summary>
        /// Loads the shift types from a specific time range.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns>A list with shifts types from a specific range.</returns>
        public List<ShiftType> GetShiftTypesByTimeRange(TimeOnly startTime, TimeOnly endTime);

        /// <summary>
        /// Gets a specific shift type.
        /// </summary>
        /// <param name="shiftTypeID">The shift type id.</param>
        /// <returns>The shift type.</returns>
        public ShiftType? GetShiftType(int shiftTypeID);
    }
}
