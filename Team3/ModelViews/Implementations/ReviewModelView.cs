namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Diagnostics;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Implementations;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Class representing the ReviewModelView.
    /// </summary>
    public class ReviewModelView : IReviewModelView
    {
        private static readonly int DUMMY_ID_BECAUSE_IT_IS_NOT_USED = 0;

        private readonly IReviewService reviewService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewModelView"/> class.
        /// </summary>
        /// <param name="reviewDatabaseService">The review database service.</param>
        public ReviewModelView(IReviewService _reviewService)
        {
            this.reviewService = _reviewService;
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
        /// <param name="id">The review id.</param>
        /// <param name="medicalrecordId">The medical record id.</param>
        /// <param name="message">The message.</param>
        /// <param name="stars">The number of stars.</param>
        public void AddReviewButtonHandler(int medicalrecordId, string message, int stars)
        {
            Debug.WriteLine("Add button clicked");

            Review newReview = new Review(DUMMY_ID_BECAUSE_IT_IS_NOT_USED, medicalrecordId, message, stars);

            this.reviewService.AddNewReview(newReview);

            Debug.WriteLine("Review added successfully!");
        }
    }
}
