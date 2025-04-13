// <copyright file="TreatmentDrug.cs" company="PlaceholderCompany">
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
    /// Represents a treatment drug.
    /// </summary>
    public class TreatmentDrug
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentDrug"/> class.
        /// </summary>
        /// <param name="id">The id of the treatment drug.</param>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <param name="drugId">The id of the drug.</param>
        /// <param name="quantity">The quantity of the drug.</param>
        /// <param name="startTime">The start time of administration.</param>
        /// <param name="endTime">The end time of the administration.</param>
        /// <param name="startDate">The start date of the administration.</param>
        /// <param name="nrDays">The number of days for the administration.</param>
        public TreatmentDrug(int id, int treatmentId, int drugId, double quantity, TimeOnly startTime, TimeOnly endTime, DateOnly startDate, int nrDays)
        {
            this.Id = id;
            this.TreatmentId = treatmentId;
            this.DrugId = drugId;
            this.Quantity = quantity;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.StartDate = startDate;
            this.NrDays = nrDays;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the treatment drug.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the treatment.
        /// </summary>
        public int TreatmentId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the drug.
        /// </summary>
        public int DrugId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the drug.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the start time of the treatment.
        /// </summary>
        public TimeOnly StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the treatment.
        /// </summary>
        public TimeOnly EndTime { get; set; }

        /// <summary>
        /// Gets or sets the start date of the treatment.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets the number of days for the treatment.
        /// </summary>
        public int NrDays { get; set; }

        /// <summary>
        /// Returns a string representation of the treatment drug.
        /// </summary>
        /// <returns>a string representation of the treatment drug.</returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, TreatmentId:{this.TreatmentId}, DrugId: {this.DrugId}, Quantity: {this.Quantity}, StartTime: {this.StartTime},EndTime: {this.EndTime}, StartDate: {this.StartDate}, Days: {this.NrDays}";
        }
    }
}
