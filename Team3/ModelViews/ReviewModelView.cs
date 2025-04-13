// <copyright file="ReviewModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Class representing the ReviewModelView.
    /// </summary>
    public class ReviewModelView : IReviewModelView
    {
        private readonly IReviewService reviewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewModelView"/> class.
        /// </summary>
        public ReviewModelView()
        {
            this.reviewModel = ReviewService.Instance;
        }

        /// <summary>
        /// Adds a review.
        /// </summary>
        /// <param name="review">The review to be added.</param>
        public void AddReview(Review review)
        {
            this.reviewModel.addNewReview(review);
        }

        /// <summary>
        /// Gets a review by medical record ID.
        /// </summary>
        /// <param name="reviewId">the id of the review.</param>
        /// <returns>The review.</returns>
        public Review GetReviewByMedicalRecordId(int reviewId)
        {
            return this.reviewModel.GetReviewByMedicalRecordId(reviewId);
        }

        /// <summary>
        /// Handles the add review button click event.
        /// </summary>
        /// <param name="id">The review name.</param>
        /// <param name="medicalrecordId">The medical record id.</param>
        /// <param name="message">The message.</param>
        /// <param name="stars">The number of stars.</param>
        public void AddReviewButtonHandler(int id, int medicalrecordId, string message, int stars)
        {
            Debug.WriteLine("Add button clicked");

            Review newReview = new Review(id, medicalrecordId, message, stars);

            this.AddReview(newReview);

            Debug.WriteLine("Review added successfully!");
        }
    }
}
