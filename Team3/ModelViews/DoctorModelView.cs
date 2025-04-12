using System;
using System.Collections.ObjectModel;
using Team3.Models;
using Team3.DBServices;

namespace Team3.ModelViews
{
    public class DoctorModelView : IDoctorModelView
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
            MedicalRecordModelView = new MedicalRecordModelView();
            ScheduleModelView = new ScheduleViewModel();
            UserModelView = new UserModelView();

            // Load doctors from database
            //LoadDoctors();
        }
        public Doctor GetDoctorById(int doctorId)
        {
            return this.doctorModel.GetDoctorById(doctorId);
        }

    }
}
