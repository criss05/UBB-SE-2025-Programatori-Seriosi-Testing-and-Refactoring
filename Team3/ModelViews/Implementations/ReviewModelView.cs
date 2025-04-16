﻿namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Diagnostics;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// Class representing the ReviewModelView.
    /// </summary>
    public class ReviewModelView : IReviewModelView
    {
        private readonly IReviewDatabaseService reviewDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewModelView"/> class.
        /// </summary>
        /// <param name="reviewDatabaseService">The review database service.</param>
        public ReviewModelView(IReviewDatabaseService reviewDatabaseService)
        {
            this.reviewDatabaseService = reviewDatabaseService;
        }

        /// <summary>
        /// Adds a review.
        /// </summary>
        /// <param name="review">The review to be added.</param>
        public void AddReview(Review review)
        {
            reviewDatabaseService.AddNewReview(review);
        }

        /// <summary>
        /// Gets a review by medical record ID.
        /// </summary>
        /// <param name="reviewId">the id of the review.</param>
        /// <returns>The review.</returns>
        public Review GetReviewByMedicalRecordId(int reviewId)
        {
            return reviewDatabaseService.GetReviewByMedicalRecordId(reviewId);
        }

        /// <summary>
        /// Handles the add review button click event.
        /// </summary>
        /// <param name="id">The review id.</param>
        /// <param name="medicalrecordId">The medical record id.</param>
        /// <param name="message">The message.</param>
        /// <param name="stars">The number of stars.</param>
        public void AddReviewButtonHandler(int id, int medicalrecordId, string message, int stars)
        {
            Debug.WriteLine("Add button clicked");

            Review newReview = new Review(medicalrecordId, message, stars);

            AddReview(newReview);

            Debug.WriteLine("Review added successfully!");
        }
    }
}
