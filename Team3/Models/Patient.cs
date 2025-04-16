/// <summary>
/// Represents a patient in the system.
/// </summary>
namespace Team3.Models
{
    public class Patient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class.
        /// </summary>
        /// <param name="id">The patient ID.</param>
        /// <param name="userId">The ID of the user associated with the patient.</param>
        public Patient(int id, int userId)
        {
            this.Id = id;
            this.UserId = userId;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the patient.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user associated with the patient.
        /// </summary>
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"Patient(Id: {this.Id}, UserId: {this.UserId})";
        }
    }
}