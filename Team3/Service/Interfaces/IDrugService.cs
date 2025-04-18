namespace Team3.Services.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for DrugService that defines the methods related to drug operations.
    /// </summary>
    public interface IDrugService
    {
        /// <summary>
        /// Retrieves the drug information based on the provided drug ID.
        /// </summary>
        /// <param name="drugId">The ID of the drug.</param>
        /// <returns>The drug details.</returns>
        Drug GetDrugById(int drugId);
    }
}
