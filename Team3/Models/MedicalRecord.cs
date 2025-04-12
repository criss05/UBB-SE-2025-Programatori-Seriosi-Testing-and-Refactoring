using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

public class MedicalRecord
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime MedicalRecordDateTime { get; set; }
    public MedicalRecord(int id, int doctorId, int patientId, DateTime medicalRecordDateTime)
    {
        Id = id;
        DoctorId = doctorId;
        PatientId = patientId;
        MedicalRecordDateTime = medicalRecordDateTime;
    }
    public override string ToString()
    {
        return $"[MedicalRecord] ID: {Id},Doctor ID : {DoctorId}, Patient ID: {PatientId}, ";
    }
}
