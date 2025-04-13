// <copyright file="PatientModelView.cs" company="PlaceholderCompany">
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
    /// Model view for the Patient.
    /// </summary>
    public class PatientModelView : IPatientModelView
    {
        private readonly IPatientDatabaseService patientModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientModelView"/> class.
        /// </summary>
        public PatientModelView()
        {
            this.patientModel = PatientDatabaseService.Instance;
        }

        /// <summary>
        /// Get a patient by id.
        /// </summary>
        /// <param name="id">Th id of the patient.</param>
        /// <returns>The patient with the speficied id.</returns>
        public Patient GetPatientById(int id)
        {
            return this.patientModel.GetPatientById(id);
        }
    }
}
