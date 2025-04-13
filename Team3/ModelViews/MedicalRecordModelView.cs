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
        public MedicalRecordModelView()
        {
            this.medicalRecordModel = MedicalRecordDatabaseService.Instance;
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

        // Metodă pentru obținerea fișelor medicale pe baza doctorului și intervalului de timp
        // public List<MedicalRecord> GetMedicalRecordsByDoctorID(int doctorId, DateOnly startDate, DateOnly endDate)
        // {
        //    try
        //    {
        //        Get all medical records from the database
        //        var allRecords = _medicalRecordModel.GetMedicalRecords();
        //        Filter records by doctorId and date range
        //        var filteredRecords = allRecords.FindAll(record =>
        //            record.DoctorId == doctorId &&
        //            record.recordDate >= startDate &&
        //            record.recordDate <= endDate
        //        );
        //        if (filteredRecords.Count == 0)
        //        {
        //            Debug.WriteLine($"No medical records found for Doctor ID: {doctorId} between {startDate} and {endDate}.");
        //        }
        //        return filteredRecords;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Error filtering medical records by Doctor ID: {ex.Message}");
        //        throw;
        //    }
        // }
    }
}
