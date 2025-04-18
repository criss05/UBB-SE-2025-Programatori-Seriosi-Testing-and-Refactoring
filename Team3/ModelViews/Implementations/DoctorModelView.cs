// <copyright file="DoctorModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System.Collections.ObjectModel;
    using Team3.Repository.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Repository.Interface;
    using Team3.Service.Interfaces;
    using Team3.Service.Implementations;

    /// <summary>
    /// This class is responsible for managing the doctor information in the application.
    /// </summary>
    public class DoctorModelView : IDoctorModelView
    {
        private readonly IDoctorService doctorService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorModelView"/> class.
        /// </summary>
        /// <param name="doctorDatabaseService">The doctor database service.</param>
        /// <param name="medicalRecordModelView">The medical record model view.</param>
        /// <param name="scheduleModelView">The schedule model view.</param>
        /// <param name="userModelView">The user model view.</param>
        public DoctorModelView(IDoctorService _doctorService)
        {
            this.doctorService = _doctorService;

            this.DoctorsInfo = new ObservableCollection<Doctor>();
        }

        /// <summary>
        /// Gets or sets the collection of doctors' information.
        /// </summary>
        public ObservableCollection<Doctor> DoctorsInfo { get; set; }

        /// <summary>
        /// Gets or sets the medical record model view.
        /// </summary>
        public MedicalRecordService MedicalRecordService { get; set; }


        /// <summary>
        /// Loads detailed doctor information from the database.
        /// </summary>
        /// <param name="doctorId">The doctor id.</param>
        /// <returns>The doctor for the given id.</returns>
        public Doctor GetDoctorById(int doctorId)
        {
            return this.doctorService.GetDoctorById(doctorId);
        }
    }
}
