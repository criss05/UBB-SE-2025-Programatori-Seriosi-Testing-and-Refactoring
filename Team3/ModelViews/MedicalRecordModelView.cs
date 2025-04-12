using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Team3.Entities;
using Team3.Models;

namespace Team3.ModelViews
{
    public class MedicalRecordModelView
    {
        private readonly MedicalRecordDBService _medicalRecordModel;

        public MedicalRecordModelView()
        {
            _medicalRecordModel = MedicalRecordDBService.Instance;
        }


        public MedicalRecord GetMedicalRecord(int id)
        {
            return this._medicalRecordModel.GetMedicalRecord(id);
        }

        // Metodă pentru obținerea fișelor medicale pe baza doctorului și intervalului de timp
        //public List<MedicalRecord> GetMedicalRecordsByDoctorID(int doctorId, DateOnly startDate, DateOnly endDate)
        //{
        //    try
        //    {
        //        // Get all medical records from the database
        //        var allRecords = _medicalRecordModel.GetMedicalRecords();

        //        // Filter records by doctorId and date range
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
        //}
    }
}
