// <copyright file="PatientModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// Model view for the Patient.
    /// </summary>
    public class PatientModelView : IPatientModelView
    {
        private readonly IPatientDatabaseService patientDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientModelView"/> class.
        /// </summary>
        /// <param name="patientDatabaseService">Injected patient database service.</param>
        public PatientModelView(IPatientDatabaseService patientDatabaseService)
        {
            this.patientDatabaseService = patientDatabaseService;
        }

        /// <summary>
        /// Get a patient by id.
        /// </summary>
        /// <param name="id">The id of the patient.</param>
        /// <returns>The patient with the specified id.</returns>
        public Patient GetPatientById(int id)
        {
            return patientDatabaseService.GetPatientById(id);
        }

        /// <summary>
        /// Add a patient.
        /// </summary>
        /// <param name="patient">The id of the patient.</param>
        /// <returns>The patient with the specified id.</returns>
        public void AddPatient(Patient patient)
        {
            this.patientDatabaseService.AddPatient(patient);
        }
    }
}
