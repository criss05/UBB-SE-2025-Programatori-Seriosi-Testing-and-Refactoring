// <copyright file="IReviewRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for the Review repository.
    /// </summary>
    public interface IReviewRepository
    {
        /// <summary>
        /// add a review.
        /// </summary>
        /// <param name="review">Add a new review.</param>
        public void AddNewReview(Review review);

        /// <summary>
        /// get a review for a specific medical record.
        /// </summary>
        /// <param name="medicalRecordId">The medical record id.</param>
        /// <returns>The review with the given id.</returns>
        public Review GetReviewByMedicalRecordId(int medicalRecordId);
    }
}
