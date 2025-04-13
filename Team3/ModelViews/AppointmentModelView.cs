// <copyright file="AppointmentModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
        public AppointmentModelView()
        {
            this.appointmentModel = (IAppointmentDatabaseService?)AppointmentDatabaseService.Instance;
        }

        /// <summary>
        /// Add a new appointment.
        /// </summary>
        /// <param name="appointment">The appoinment to be added.</param>
        public void AddNewAppointment(Appointment appointment)
        {
            this.appointmentModel.AddNewAppointment(appointment);
        }

        /// <summary>
        /// Get an appointment by id.
        /// </summary>
        /// <param name="id">The id of the appointment.</param>
        /// <returns>The Appointment.</returns>
        public Appointment GetAppointmentById(int id)
        {
            return this.appointmentModel.GetAppointmentById(id);
        }
    }
}
