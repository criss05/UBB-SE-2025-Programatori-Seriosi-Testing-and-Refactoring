namespace Team3.ModelViews.Implementations
{
    using System;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Services.Interfaces;

    /// <summary>
    /// This class is used to manage the appointment model view.
    /// </summary>
    public class AppointmentModelView : IAppointmentModelView
    {
        private readonly IAppointmentService appointmentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentModelView"/> class.
        /// </summary>
        /// <param name="appointmentModel">The appointment database service to use.</param>
        public AppointmentModelView(IAppointmentService _appointmentService)
        {
            this.appointmentService = _appointmentService;
        }

        /// <inheritdoc/>
        public void AddNewAppointment(Appointment appointment)
        {
            this.appointmentService.AddNewAppointment(appointment);
        }

        /// <inheritdoc/>
        public Appointment GetAppointmentById(int id)
        {
            return this.appointmentService.GetAppointmentById(id);
        }
    }
}
