// <copyright file="ITreatmentService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for TreatmentService.
    /// </summary>
    public interface ITreatmentService
    {
        /// <summary>
        /// Get the treatment by medical record id.
        /// </summary>
        /// <param name="treatmentId">The treatment id.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int treatmentId);
    }
}
