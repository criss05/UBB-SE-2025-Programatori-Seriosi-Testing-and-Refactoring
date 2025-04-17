// <copyright file="MedicalRecordModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Team3.Repository.Implementations;
    using Team3.Repository.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// This class represents the view model for medical records.
    /// </summary>
    public class MedicalRecordModelView : IMedicalRecordService
    {
        private readonly IMedicalRecordDatabaseService medicalRecordService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalRecordModelView"/> class.
        /// </summary>
        /// <param name="medicalRecordService">The medical record database service.</param>
        public MedicalRecordModelView(IMedicalRecordDatabaseService medicalRecordService)
        {
            // Pass dbConnString to the MedicalRecordDatabaseService constructor
            this.medicalRecordService = medicalRecordService;
        }

        /// <summary>
        /// Gets the medical record by ID.
        /// </summary>
        /// <param name="id">The id of the medical record.</param>
        /// <returns>The Medical record based on the given id.</returns>
        public MedicalRecord GetMedicalRecordById(int id)
        {
            return this.medicalRecordService.GetMedicalRecordById(id);
        }
    }
}
