using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.Entities;
using System.Diagnostics;
using System.Collections;

namespace Team3.ModelViews
{
    public class ReviewModelView
    {
        private readonly ReviewService _reviewModel;

        public ReviewModelView()
        {
            _reviewModel = ReviewService.Instance;
        }
        public void addReview(Review review)
        {
            _reviewModel.addNewReview(review);
        }
        public Review getReviewByMedicalRecordId(int mrId)
        {
            return _reviewModel.GetReviewByMedicalRecordId(mrId);
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
