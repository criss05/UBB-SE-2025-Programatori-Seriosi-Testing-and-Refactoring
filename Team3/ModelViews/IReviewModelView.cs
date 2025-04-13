// <copyright file="IReviewModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using Team3.Models;

    /// <summary>
    /// Interface for the ReviewModelView.
    /// </summary>
    public interface IReviewModelView
    {
        /// <summary>
        /// add a review.
        /// </summary>
        /// <param name="review">The review to be added.</param>
        public void AddReview(Review review);

        /// <summary>
        /// get a review by id.
        /// </summary>
        /// <param name="reviewId">The review to be found.</param>
        /// <returns>The review.</returns>
        public Review GetReviewByMedicalRecordId(int reviewId);

        /// <summary>
        /// handle the add review button click event.
        /// </summary>
        /// <param name="id">The id of the review.</param>
        /// <param name="medicalrecordId">The medical report id.</param>
        /// <param name="message">The message.</param>
        /// <param name="stars">The stars.</param>
        public void AddReviewButtonHandler(int id, int medicalrecordId, string message, int stars);
    }
}
