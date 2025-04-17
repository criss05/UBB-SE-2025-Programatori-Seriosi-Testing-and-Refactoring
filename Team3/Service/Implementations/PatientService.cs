// <copyright file="PatientModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Model view for the Patient.
    /// </summary>
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientService"/> class.
        /// </summary>
        /// <param name="patientDatabaseService">Injected patient database service.</param>
        public PatientService(IPatientRepository patientDatabaseService)
        {
            this.patientRepo = patientDatabaseService;
        }

        /// <summary>
        /// Get a patient by id.
        /// </summary>
        /// <param name="id">The id of the patient.</param>
        /// <returns>The patient with the specified id.</returns>
        public Patient GetPatientById(int id)
        {
            return patientRepo.GetPatientById(id);
        }

        /// <summary>
        /// Add a patient.
        /// </summary>
        /// <param name="patient">The id of the patient.</param>
        /// <returns>The patient with the specified id.</returns>
        public void AddPatient(Patient patient)
        {
            this.patientRepo.AddPatient(patient);
        }
    }
}
