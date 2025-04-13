// <copyright file="Treatment.cs" company="PlaceholderCompany">
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
    /// Represents a treatment record.
    /// </summary>
    public class Treatment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Treatment"/> class.
        /// </summary>
        /// <param name="id">The treatment id.</param>
        /// <param name="medicalRecordId">The medical record id.</param>
        public Treatment(int id, int medicalRecordId)
        {
            this.Id = id;
            this.MedicalRecordId = medicalRecordId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the treatment.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the medical record associated with the treatment.
        /// </summary>
        public int MedicalRecordId { get; set; }

        /// <summary>
        /// Returns a string representation of the treatment.
        /// </summary>
        /// <returns>string representation of the treatment.</returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, MedicalRecordId: {this.MedicalRecordId}";
        }
    }
}
