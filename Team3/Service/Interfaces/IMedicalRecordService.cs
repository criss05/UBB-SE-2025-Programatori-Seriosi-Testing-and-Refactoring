namespace Team3.ModelViews.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for MedicalRecordService that defines methods related to medical records operations.
    /// </summary>
    public interface IMedicalRecordService
    {
        /// <summary>
        /// Retrieves the medical record based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the medical record.</param>
        /// <returns>The medical record corresponding to the given ID.</returns>
        MedicalRecord GetMedicalRecordById(int id);
    }
}
