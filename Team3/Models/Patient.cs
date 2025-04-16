// <copyright file="Patient.cs" company="PlaceholderCompany">
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
    /// Represents a patient in the system.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class.
        /// </summary>
        /// <param name="userId">The is of the user.</param>
        public Patient(int userId)
        {
            this.UserId = userId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with the patient.
        /// </summary>
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"Patient(UserId: {this.UserId})";
        }
    }
}
