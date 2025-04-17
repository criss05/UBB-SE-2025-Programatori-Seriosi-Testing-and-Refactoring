// <copyright file="ReviewModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System.Diagnostics;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Class representing the ReviewModelView.
    /// </summary>
    public class ReviewModelView : IReviewModelView
    {
        private static readonly int DefaultUserId = 0;

        private readonly IReviewService reviewService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewModelView"/> class.
        /// </summary>
        /// <param name="reviewService">The review database service.</param>
        public ReviewModelView(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        /// <summary>
        /// Adds a review.
        /// </summary>
        /// <param name="review">The review to be added.</param>
        public void AddNewReview(Review review)
        {
            this.reviewService.AddNewReview(review);
        }

        /// <summary>
        /// Gets a review by medical record ID.
        /// </summary>
        /// <param name="reviewId">the id of the review.</param>
        /// <returns>The review.</returns>
        public Review GetReviewByMedicalRecordId(int reviewId)
        {
            return this.reviewService.GetReviewByMedicalRecordId(reviewId);
        }

        /// <summary>
        /// Handles the add review button click event.
        /// </summary>
        /// <param name="medicalrecordId">The medical record id.</param>
        /// <param name="message">The message.</param>
        /// <param name="stars">The number of stars.</param>
        public void AddReviewButtonHandler(int medicalrecordId, string message, int stars)
        {
            Debug.WriteLine("Add button clicked");

            Review newReview = new Review(DefaultUserId, medicalrecordId, message, stars);

            this.reviewService.AddNewReview(newReview);

            Debug.WriteLine("Review added successfully!");
        }
    }
}
