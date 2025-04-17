// <copyright file="IMedicalRecordModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Interfaces
{
    /// <summary>
    ///     This interface defines the contract for a medical record model view.
    /// </summary>
    public interface IMedicalRecordService
    {
        /// <summary>
        /// Get medical record by ID.
        /// </summary>
        /// <param name="id">The id of the medical repot.</param>
        /// <returns>The medical report.</returns>
        public MedicalRecord GetMedicalRecordById(int id);
    }
}
