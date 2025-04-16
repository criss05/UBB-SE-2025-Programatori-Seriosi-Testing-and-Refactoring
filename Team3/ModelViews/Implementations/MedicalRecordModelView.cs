// <copyright file="MedicalRecordModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// This class represents the view model for medical records.
    /// </summary>
    public class MedicalRecordModelView : IMedicalRecordModelView
    {
        private readonly IMedicalRecordDatabaseService medicalRecordDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalRecordModelView"/> class.
        /// </summary>
        public MedicalRecordModelView(IMedicalRecordDatabaseService _medicalRecordDatabaseService)
        {
            // Pass dbConnString to the MedicalRecordDatabaseService constructor
            medicalRecordDatabaseService = _medicalRecordDatabaseService;
        }

        /// <summary>
        /// Gets the medical record by ID.
        /// </summary>
        /// <param name="id">The id of the medical record.</param>
        /// <returns>The Medical record based on the given id.</returns>
        public MedicalRecord GetMedicalRecordById(int id)
        {
            return medicalRecordDatabaseService.GetMedicalRecordById(id);
        }
    }
}
