// <copyright file="MedicalRecord.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;

/// <summary>
/// This class represents a medical record.
/// </summary>
public class MedicalRecord
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MedicalRecord"/> class.
    /// </summary>
    /// <param name="id">The Id of the record.</param>
    /// <param name="doctorId">The doctor Id.</param>
    /// <param name="patientId">The patient Id.</param>
    /// <param name="medicalRecordDateTime">The record date and time.</param>
    public MedicalRecord(int id, int doctorId, int patientId, DateTime medicalRecordDateTime)
    {
        this.Id = id;
        this.DoctorId = doctorId;
        this.PatientId = patientId;
        this.MedicalRecordDateTime = medicalRecordDateTime;
    }

    /// <summary>
    /// Gets or sets the ID of the medical record.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the doctor associated with the medical record.
    /// </summary>
    public int DoctorId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the patient associated with the medical record.
    /// </summary>
    public int PatientId { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the medical record.
    /// </summary>
    public DateTime MedicalRecordDateTime { get; set; }

    /// <summary>
    /// Returns a string representation of the medical record.
    /// </summary>
    /// <returns>A string representation of the medical record.</returns>
    public override string ToString()
    {
        return $"[MedicalRecord] ID: {this.Id},Doctor ID : {this.DoctorId}, Patient ID: {this.PatientId}, ";
    }
}
