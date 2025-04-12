using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DBServices;
using Team3.Models;
using System.Diagnostics;
using System.Collections;

namespace Team3.ModelViews
{
    public class ReviewModelView : IReviewModelView
    {
        private readonly IReviewService _reviewModel;

        public ReviewModelView()
        {
            _reviewModel = ReviewService.Instance;
        }

        public void addReview(Review review)
        {
            _reviewModel.addReview(review);
        }
        public Review getReview(int mrId)
        {
            return _reviewModel.getReview(mrId);
        }

        public void addReviewButtonHandler(int id,int medicalrecordId, string message, int stars)
        {
            Debug.WriteLine("Add button clicked");

            Review newReview = new Review(id, medicalrecordId, message, stars);

            addReview(newReview);

            Debug.WriteLine("Review added successfully!");
        }
    }
}
