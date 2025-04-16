// <copyright file="Doctor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;

    /// <summary>
    /// Represents a doctor in the system.
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor"/> class.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        public Doctor(int userId)
        {
            this.UserId = userId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with the doctor.
        /// </summary>
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"Doctor(UserId: {this.UserId})";
        }
    }
}
