// <copyright file="DoctorModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System.Collections.ObjectModel;
    using Team3.Repository.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Repository.Interface;
    using Team3.Service.Interfaces;

    /// <summary>
    /// This class is responsible for managing the doctor information in the application.
    /// </summary>
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IScheduleService scheduleService;
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorService"/> class.
        /// </summary>
        /// <param name="_doctorRepository">The doctor database service.</param>
        /// <param name="_medicalRecordService">The medical record model view.</param>
        /// <param name="_scheduleService">The schedule model view.</param>
        /// <param name="_userService">The user model view.</param>
        public DoctorService(
            IDoctorRepository _doctorRepository,
            IMedicalRecordService _medicalRecordService,
            IScheduleService _scheduleService,
            IUserService _userService)
        {
            this.doctorRepository = _doctorRepository;
            this.medicalRecordService = _medicalRecordService;
            this.scheduleService = _scheduleService;
            this.userService = _userService;
        }

        /// <summary>
        /// Gets or sets the medical record model view.
        /// </summary>
        public IMedicalRecordService MedicalRecordService { get; set; }

        /// <summary>
        /// Gets or sets the schedule model view.
        /// </summary>
        public IScheduleModelView ScheduleService { get; set; }

        /// <summary>
        /// Gets or sets the user model view.
        /// </summary>
        public IUserModelView UserService { get; set; }

        /// <summary>
        /// Loads detailed doctor information from the database.
        /// </summary>
        /// <param name="doctorId">The doctor id.</param>
        /// <returns>The doctor for the given id.</returns>
        public Doctor GetDoctorById(int doctorId)
        {
            return this.doctorRepository.GetDoctorById(doctorId);
        }
    }
}
