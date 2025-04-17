// <copyright file="ShiftType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;

    /// <summary>
    /// Represents a shift type with a start and end time.
    /// </summary>
    public class ShiftType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftType"/> class.
        /// </summary>
        /// <param name="id">The ID of the shift type.</param>
        /// <param name="shiftTypeStartTime">The start time of the shift.</param>
        /// <param name="shiftTypeEndTime">The end time of the shift.</param>
        public ShiftType(int id, TimeOnly shiftTypeStartTime, TimeOnly shiftTypeEndTime)
        {
            this.Id = id;
            this.ShiftTypeStartTime = shiftTypeStartTime;
            this.ShiftTypeEndTime = shiftTypeEndTime;
        }

        /// <summary>
        /// Gets or sets the ID of the shift type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the start time of the shift type.
        /// </summary>
        public TimeOnly ShiftTypeStartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the shift type.
        /// </summary>
        public TimeOnly ShiftTypeEndTime { get; set; }

        /// <summary>
        /// Returns a string representation of the shift type.
        /// </summary>
        /// <returns>The string with the shift type information.</returns>
        public override string ToString()
        {
            return $"ShiftType(Id: {this.Id}, StartTime: {this.ShiftTypeStartTime}, EndTime: {this.ShiftTypeEndTime})";
        }
    }
}