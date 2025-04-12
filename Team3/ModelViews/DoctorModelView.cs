using System;
using System.Collections.ObjectModel;
using Team3.Models;
using Team3.DatabaseServices;

namespace Team3.ModelViews
{
    public class DoctorModelView : IDoctorModelView
    {
        // Observable collections for doctors' information
        public ObservableCollection<Doctor> DoctorsInfo { get; set; }

        // Dependencies

        private readonly IDoctorDatabaseService doctorModel;
        public IMedicalRecordModelView MedicalRecordModelView { get; set; }
        public IScheduleViewModel ScheduleModelView { get; set; }
        public IUserModelView UserModelView { get; set; }


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
