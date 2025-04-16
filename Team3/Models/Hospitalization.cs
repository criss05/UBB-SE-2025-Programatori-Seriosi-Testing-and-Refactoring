namespace Team3.Models
{
    using System;

    /// <summary>
    /// Represents a hospitalization record for a patient.
    /// </summary>
    public class Hospitalization
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hospitalization"/> class.
        /// </summary>
        /// <param name="id">The hospitalization ID.</param>
        /// <param name="roomId">The room id.</param>
        /// <param name="patientId">The patient id.</param>
        /// <param name="startDateTime">The start date.</param>
        /// <param name="endDateTime">The end date.</param>
        public Hospitalization(int id, int roomId, int patientId, DateTime startDateTime, DateTime endDateTime)
        {
            this.Id = id;
            this.RoomId = roomId;
            this.PatientId = patientId;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the hospitalization record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the room where the patient is hospitalized.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the patient being hospitalized.
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the hospitalization started.
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the hospitalization ended.
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Returns a string representation of the hospitalization.
        /// </summary>
        /// <returns>A string representation of the hospitalization record.</returns>
        public override string ToString()
        {
            return $"Hospitalization(Id: {this.Id}, RoomId: {this.RoomId}, PatientId: {this.PatientId}, StartDateTime: {this.StartDateTime}, EndDateTime: {this.EndDateTime})";
        }
    }
}
