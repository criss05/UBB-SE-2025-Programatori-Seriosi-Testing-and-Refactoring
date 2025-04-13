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
        /// <param name="id">The id of the patient.</param>
        /// <param name="userId">The is of the user.</param>
        public Patient(int id, int userId)
        {
            this.Id = id;
            this.UserId = userId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the patient.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with the patient.
        /// </summary>
        public int UserId { get; set; }
    }
}
