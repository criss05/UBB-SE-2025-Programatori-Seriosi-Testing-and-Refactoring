// <copyright file="MedicalRecordModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// This class represents the view model for medical records.
    /// </summary>
    public class MedicalRecordModelView : IMedicalRecordModelView
    {
        private readonly MedicalRecordDatabaseService medicalRecordModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalRecordModelView"/> class.
        /// </summary>
        public MedicalRecordModelView(string dbConnString)
        {
            // Pass dbConnString to the MedicalRecordDatabaseService constructor
            this.medicalRecordModel = new MedicalRecordDatabaseService(dbConnString);
        }

        /// <summary>
        /// Gets the medical record by ID.
        /// </summary>
        /// <param name="id">The id of the medical record.</param>
        /// <returns>The Medical record based on the given id.</returns>
        public MedicalRecord GetMedicalRecordById(int id)
        {
            return this.medicalRecordModel.GetMedicalRecordById(id);
        }
    }
}
