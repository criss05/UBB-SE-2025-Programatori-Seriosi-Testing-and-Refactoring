namespace Team3.Service.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for managing appointment services.
    /// </summary>
    public interface IAppointmentService
    {
        /// <summary>
        /// Adds a new appointment.
        /// </summary>
        /// <param name="appointment">The appointment to add.</param>
        void AddNewAppointment(Appointment appointment);

        /// <summary>
        /// Retrieves an appointment by its ID.
        /// </summary>
        /// <param name="id">The ID of the appointment.</param>
        /// <returns>The appointment with the specified ID.</returns>
        Appointment GetAppointmentById(int id);
    }
}
