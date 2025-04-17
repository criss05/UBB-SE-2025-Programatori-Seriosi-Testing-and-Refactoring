// <copyright file="IReviewService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for review-related operations.
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// Adds a new review.
        /// </summary>
        /// <param name="review">The review to add.</param>
        void AddNewReview(Review review);

        /// <summary>
        /// Gets a review by the associated medical record ID.
        /// </summary>
        /// <param name="reviewId">The ID of the medical record.</param>
        /// <returns>The review.</returns>
        Review GetReviewByMedicalRecordId(int reviewId);
    }
}
