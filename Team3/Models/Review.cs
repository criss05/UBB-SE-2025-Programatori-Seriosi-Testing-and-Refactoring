// <copyright file="Review.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// Class representing a review.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Review"/> class.
        /// </summary>
        /// <param name="id">The id of the review.</param>
        /// <param name="medicalRecordId">The medical record id.</param>
        /// <param name="message">The message.</param>
        /// <param name="nrStars">The number of stars.</param>
        public Review(int id, int medicalRecordId, string message, int nrStars)
        {
            this.Id = id;
            this.MedicalRecordId = medicalRecordId;
            this.Message = message;
            this.NrStars = nrStars;
        }

        /// <summary>
        /// Gets or sets the review ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the medical record ID associated with the review.
        /// </summary>
        public int MedicalRecordId { get; set; }

        /// <summary>
        /// Gets or sets the message of the review.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the number of stars given in the review.
        /// </summary>
        public int NrStars { get; set; }

        /// <summary>
        /// Returns a string representation of the review.
        /// </summary>
        /// <returns>string representation of the review.</returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, MedicalRecordId: {this.MedicalRecordId}, Message: {this.Message}, Stars: {this.NrStars}";
        }
    }
}
