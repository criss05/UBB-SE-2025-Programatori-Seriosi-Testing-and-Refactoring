using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IReviewModelView
    {
        /// <summary>
        /// add a review
        /// </summary>
        /// <param name="review"></param>
        public void addReview(Review review);

        /// <summary>
        /// get a review by id
        /// </summary>
        /// <param name="mrId"></param>
        /// <returns></returns>
        public Review getReview(int mrId);

        /// <summary>
        /// handle the add review button click event
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medicalrecordId"></param>
        /// <param name="message"></param>
        /// <param name="stars"></param>
        public void addReviewButtonHandler(int id, int medicalrecordId, string message, int stars);
    }
}
