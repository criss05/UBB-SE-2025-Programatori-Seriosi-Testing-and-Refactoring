// <copyright file="IMedicalRecordDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Interfaces
{
    /// <summary>
    /// Interface for the medical record database service.
    /// </summary>
    public interface IMedicalRecordDatabaseService
    {
        /// <summary>
        /// Gets the medical record by ID.
        /// </s
        /// <param name="medicalRecordId">ummary>the id of the medical record.</param>
        /// <returns>The medical record.</returns>
        public MedicalRecord GetMedicalRecordById(int medicalRecordId);
    }
}
