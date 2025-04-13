// <copyright file="DoctorModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.ObjectModel;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// This class is responsible for managing the doctor information in the application.
    /// </summary>
    public class DoctorModelView : IDoctorModelView
    {
        private readonly IDoctorDatabaseService doctorModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorModelView"/> class.
        /// </summary>
        public DoctorModelView()
        {
            // Initialize the DoctorModel instance
            this.doctorModel = DoctorDatabaseService.Instance;

            // Initialize collections
            this.DoctorsInfo = new ObservableCollection<Doctor>();
            this.MedicalRecordModelView = new MedicalRecordModelView();
            this.ScheduleModelView = new ScheduleModelView();
            this.UserModelView = new UserModelView();

            // Load doctors from database
            // LoadDoctors();
        }

        /// <summary>
        /// Gets or sets the collection of doctors' information.
        /// </summary>
        public ObservableCollection<Doctor> DoctorsInfo { get; set; }

        /// <summary>
        /// Gets or sets the action to be executed when the back button is pressed.
        /// </summary>
        public IMedicalRecordModelView MedicalRecordModelView { get; set; }

        /// <summary>
        /// Gets or sets the action to be executed when the back button is pressed.
        /// </summary>
        public IScheduleViewModel ScheduleModelView { get; set; }

        /// <summary>
        /// Gets or sets the action to be executed when the back button is pressed.
        /// </summary>
        public IUserModelView UserModelView { get; set; }

        /// <summary>
        /// Loads detailed doctor information from the database.
        /// </summary>
        /// <param name="doctorId">The doctor id.</param>
        /// <returns>The doctor fro the given id.</returns>
        public Doctor GetDoctorById(int doctorId)
        {
            return this.doctorModel.GetDoctorById(doctorId);
        }
    }
}
