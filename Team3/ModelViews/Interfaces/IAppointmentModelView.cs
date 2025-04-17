// <copyright file="IAppointmentModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for the appointment model view.
    /// </summary>
    public interface IAppointmentModelView
    {
        /// <summary>
        /// add an appointment.
        /// </summary>
        /// <param name="appointment">Teh appointment.</param>
        public void AddNewAppointment(Appointment appointment);

        /// <summary>
        /// get an appointment by id.
        /// </summary>
        /// <param name="id">The id of the appointment.</param>
        /// <returns>The appointment.</returns>
        public Appointment GetAppointmentById(int id);
    }
}
