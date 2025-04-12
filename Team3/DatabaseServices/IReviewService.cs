using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DBServices
{
    public interface IReviewService
    {
        /// <summary>
        /// add a review 
        /// </summary>
        /// <param name="review"></param>
        public void addReview(Review review);

        /// <summary>
        /// get a review for a specific medical record
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <returns></returns>
        public Review getReview(int medicalRecordId);
    }
}
