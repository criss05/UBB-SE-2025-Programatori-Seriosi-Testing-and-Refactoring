// <copyright file="TreatmentModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Model view for Treatment.
    /// </summary>
    public class TreatmentModelView : Interfaces.ITreatmentModelView
    {
        private readonly Service.Interfaces.ITreatmentService treatmentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentModelView"/> class.
        /// </summary>
        /// <param name="treatmentService">The database service for treatment operations.</param>
        public TreatmentModelView(Service.Interfaces.ITreatmentService treatmentService)
        {
            this.treatmentService = treatmentService;
        }

        /// <summary>
        /// Get the treatment by medical record id.
        /// </summary>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int treatmentId)
        {
            return this.treatmentService.GetTreatmentByMedicalRecordId(treatmentId);
        }
    }
}
