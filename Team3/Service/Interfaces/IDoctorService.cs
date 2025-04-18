namespace Team3.ModelViews.Interfaces
{
    using Team3.Models;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Provides methods and properties for managing doctor-related operations.
    /// </summary>
    public interface IDoctorService
    {
        /// <summary>
        /// Gets or sets the medical record service.
        /// </summary>
        IMedicalRecordService MedicalRecordService { get; set; }

        /// <summary>
        /// Gets or sets the schedule service.
        /// </summary>
        IScheduleModelView ScheduleService { get; set; }

        /// <summary>
        /// Gets or sets the user service.
        /// </summary>
        IUserModelView UserService { get; set; }

        /// <summary>
        /// Loads detailed doctor information from the database.
        /// </summary>
        /// <param name="doctorId">The doctor ID.</param>
        /// <returns>The doctor associated with the given ID.</returns>
        Doctor GetDoctorById(int doctorId);
    }
}
