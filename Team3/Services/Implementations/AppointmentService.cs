namespace Team3.Services.Implementations
{
    using System;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Services.Interfaces;

    /// <summary>
    /// This class is used to manage the appointment model view.
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentService(IAppointmentRepository _appointmentRepository)
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
