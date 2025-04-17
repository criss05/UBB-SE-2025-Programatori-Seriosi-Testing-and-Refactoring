// <copyright file="IPatientRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for the Patient repository.
    /// </summary>
    public interface IPatientRepository
    {
        /// <summary>
        /// get a patient by id.
        /// </summary>
        /// <param name="patientId">the id of the patient.</param>
        /// <returns>The patient with the given id.</returns>
        public Patient GetPatientById(int patientId);

        /// <summary>
        /// add a patient.
        /// </summary>
        /// <param name="patient">The patient to be added.</param>
        public void AddPatient(Patient patient);
    }
}
