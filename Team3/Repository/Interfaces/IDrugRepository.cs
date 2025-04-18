// <copyright file="IDrugDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Interfaces
{
    using Team3.Models;

    /// <summary>
    /// Interface for drug database service.
    /// </summary>
    public interface IDrugRepository
    {
        /// <summary>
        /// Get drug by id.
        /// </summary>
        /// <param name="drugId">The drug id.</param>
        /// <returns>The drug with the given Id.</returns>
        public Drug GetDrugById(int drugId);
    }
}
