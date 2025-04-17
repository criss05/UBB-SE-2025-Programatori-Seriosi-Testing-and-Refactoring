// <copyright file="IAppointmentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for appointment repository.
    /// </summary>
    public interface IAppointmentRepository
    {
        /// <summary>
        /// Add an appointment to the database.
        /// </summary>
        /// <param name="appointment">he appointment to be added.</param>
        public void AddNewAppointment(Appointment appointment);

        /// <summary>
        /// Get an appointment from the database based to id.
        /// </summary>
        /// <param name="appointmentId">The id of the appointment.</param>
        /// <returns>The appointment.</returns>
        public Appointment GetAppointmentById(int appointmentId);
    }
}
