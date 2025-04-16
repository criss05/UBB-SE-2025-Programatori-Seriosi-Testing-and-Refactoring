/// <summary>
/// Class representing a review.
/// </summary>
namespace Team3.Models
{
    public class Review
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Review"/> class.
        /// </summary>
      
        /// <param name="id">The unique review ID.</param>
        /// <param name="medicalRecordId">The medical record ID.</param>
        /// <param name="message">The review message.</param>
        /// <param name="nrStars">The number of stars.</param>
        public Review(int id, int medicalRecordId, string message, int nrStars)
        {
            this.Id = id;
            this.MedicalRecordId = medicalRecordId;
            this.Message = message;
            this.NrStars = nrStars;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the review.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the medical record ID associated with the review.
        /// </summary>
        public int MedicalRecordId { get; set; }

        /// <summary>
        /// Gets or sets the message of the review.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the number of stars given in the review.
        /// </summary>
        public int NrStars { get; set; }

        /// <summary>
        /// Returns a string representation of the review.
        /// </summary>
        /// <returns>String representation of the review.</returns>
        public override string ToString()
        {
            return $"Review(Id: {this.Id}, MedicalRecordId: {this.MedicalRecordId}, Message: \"{this.Message}\", Stars: {this.NrStars})";
        }
    }
}