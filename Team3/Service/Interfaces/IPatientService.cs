// <copyright file="IPatientModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for the Patient Model View.
    /// </summary>
    public interface IPatientService
    {
        /// <summary>
        /// Get a patient by ID.
        /// </summary>
        /// <param name="id">the id of the patient.</param>
        /// <returns>The patient.</returns>
        public Patient GetPatientById(int id);

        /// <summary>
        /// Add a patient.
        /// </summary>
        /// <param name="patient">The id of the patient.</param>
        /// <returns>The patient with the specified id.</returns>
        public void AddPatient(Patient patient);
    }
}
