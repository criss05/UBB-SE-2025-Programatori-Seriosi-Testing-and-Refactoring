namespace Team3.ModelViews.Implementations
{
    using System;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// This class is used to manage the appointment model view.
    /// </summary>
    public class AppointmentModelView : IAppointmentModelView
    {
        private readonly IAppointmentRepository appointmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentModelView"/> class.
        /// </summary>
        /// <param name="appointmentModel">The appointment database service to use.</param>
        public AppointmentModelView(IAppointmentRepository _appointmentRepository)
        {
            this.appointmentRepository = _appointmentRepository; ;
        }

        /// <inheritdoc/>
        public void AddNewAppointment(Appointment appointment)
        {
            this.appointmentRepository.AddNewAppointment(appointment);
        }

        /// <inheritdoc/>
        public Appointment GetAppointmentById(int id)
        {
            return this.appointmentRepository.GetAppointmentById(id);
        }
    }
}
