// <copyright file="Doctor.cs" company="PlaceholderCompany">
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
    /// Represents a doctor in the system.
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor"/> class.
        /// </summary>
        /// <param name="id">The id of the doctor.</param>
        /// <param name="userId">The id of the user.</param>
        public Doctor(int id, int userId)
        {
            this.Id = id;
            this.UserId = userId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the doctor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with the doctor.
        /// </summary>
        public int UserId { get; set; }
    }
}
