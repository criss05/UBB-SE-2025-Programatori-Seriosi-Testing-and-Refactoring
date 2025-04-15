// <copyright file="Room.cs" company="PlaceholderCompany">
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
    /// Represents a room in the hospital.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="departmentId">The id of the department.</param>
        public Room(int departmentId)
        {
            this.DepartmentId = departmentId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the department to which the room belongs.
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
