// <copyright file="ITreatmentRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for the treatment repository.
    /// </summary>
    public interface ITreatmentRepository
    {
        /// <summary>
        /// add a treatment.
        /// </summary>
        /// <param name="treatment">The treatment to be added.</param>
        public void AddNewTreatment(Treatment treatment);

        /// <summary>
        /// get a treatment by medical record.
        /// </summary>
        /// <param name="medicalRecordId">The medical record id.</param>
        /// <returns>The treatment with the medical record.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int medicalRecordId);
    }
}
