// <copyright file="PatientModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Model view for the Patient.
    /// </summary>
    public class PatientModelView : Interfaces.IPatientModelView
    {
        private readonly Service.Interfaces.IPatientService patientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientModelView"/> class.
        /// </summary>
        /// <param name="patientService">Injected patient database service.</param>
        public PatientModelView(Service.Interfaces.IPatientService patientService)
        {
            this.patientService = patientService;
        }

        /// <summary>
        /// Get a patient by id.
        /// </summary>
        /// <param name="id">The id of the patient.</param>
        /// <returns>The patient with the specified id.</returns>
        public Patient GetPatientById(int id)
        {
            return this.patientService.GetPatientById(id);
        }

        /// <summary>
        /// Add a patient.
        /// </summary>
        /// <param name="patient">The id of the patient.</param>
        public void AddPatient(Patient patient)
        {
            this.patientService.AddPatient(patient);
        }
    }
}
