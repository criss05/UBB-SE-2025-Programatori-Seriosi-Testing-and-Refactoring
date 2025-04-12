using System;
using System.Collections.ObjectModel;
using Team3.Entities;
using Team3.Models;

namespace Team3.ModelViews
{
    public class DoctorModelView
    {
        // Observable collections for doctors' information
        public ObservableCollection<Doctor> DoctorsInfo { get; set; }

        // Dependencies
        private readonly DoctorDatabaseService doctorModel;
        public MedicalRecordModelView MedicalRecordModelView { get; set; }
        public ScheduleViewModel ScheduleModelView { get; set; }
        public UserModelView UserModelView { get; set; }

        public DoctorModelView()
        {
            // Initialize the DoctorModel instance
            doctorModel = DoctorDatabaseService.Instance;

            // Initialize collections
            DoctorsInfo = new ObservableCollection<Doctor>();

            // Load doctors from database
            //LoadDoctors();
        }
        public Doctor GetDoctorById(int doctorId)
        {
            return this.doctorModel.GetDoctorById(doctorId);
        }

    }
}
