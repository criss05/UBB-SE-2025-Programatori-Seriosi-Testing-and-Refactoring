// <copyright file="AppointmentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using Team3.Models;
    using Team3.Repository.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// This class is used to manage the appointment model view.
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentService"/> class.
        /// </summary>
        /// <param name="appointmentRepository">The appointment repository.</param>
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
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
