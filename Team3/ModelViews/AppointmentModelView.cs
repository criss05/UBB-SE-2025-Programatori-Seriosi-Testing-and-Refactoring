namespace Team3.ModelViews
{
    using System;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// This class is used to manage the appointment model view.
    /// </summary>
    public class AppointmentModelView : IAppointmentModelView
    {
        private readonly IAppointmentDatabaseService appointmentModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentModelView"/> class.
        /// </summary>
        /// <param name="appointmentModel">The appointment database service to use.</param>
        public AppointmentModelView(IAppointmentDatabaseService appointmentModel)
        {
            this.appointmentModel = appointmentModel ?? throw new ArgumentNullException(nameof(appointmentModel));
        }

        /// <inheritdoc/>
        public void AddNewAppointment(Appointment appointment)
        {
            this.appointmentModel.AddNewAppointment(appointment);
        }

        /// <inheritdoc/>
        public Appointment GetAppointmentById(int id)
        {
            return this.appointmentModel.GetAppointmentById(id);
        }
    }
}
