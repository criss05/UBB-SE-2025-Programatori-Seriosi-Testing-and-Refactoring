// <copyright file="ShiftType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a shift type with a start and end time.
    /// </summary>
    public class ShiftType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftType"/> class.
        /// </summary>
        /// <param name="shiftTypeId">The id of the shift.</param>
        /// <param name="shiftTypeStartTime">The start time of the shift.</param>
        /// <param name="shiftTypeEndTime">The end time of the shift.</param>
        public ShiftType(int shiftTypeId, TimeOnly shiftTypeStartTime, TimeOnly shiftTypeEndTime)
        {
            this.ShiftTypeId = shiftTypeId;
            this.ShiftTypeStartTime = shiftTypeStartTime;
            this.ShiftTypeEndTime = shiftTypeEndTime;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the shift type.
        /// </summary>
        public int ShiftTypeId { get; set; }

        /// <summary>
        /// Gets or sets the start time of the shift type.
        /// </summary>
        public TimeOnly ShiftTypeStartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the shift type.
        /// </summary>
        public TimeOnly ShiftTypeEndTime { get; set; }
    }
}
