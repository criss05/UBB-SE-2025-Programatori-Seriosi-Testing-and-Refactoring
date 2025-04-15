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
        private readonly IAppointmentDatabaseService appointmentDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentModelView"/> class.
        /// </summary>
        /// <param name="appointmentModel">The appointment database service to use.</param>
        public AppointmentModelView(IAppointmentDatabaseService _appointmentModelDatabaseService)
        {
            appointmentDatabaseService = _appointmentModelDatabaseService;
        }

        /// <inheritdoc/>
        public void AddNewAppointment(Appointment appointment)
        {
            appointmentDatabaseService.AddNewAppointment(appointment);
        }

        /// <inheritdoc/>
        public Appointment GetAppointmentById(int id)
        {
            return appointmentDatabaseService.GetAppointmentById(id);
        }
    }
}
