// <copyright file="DrugService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using Team3.Repository.Interfaces;
    using Team3.Models;
    using Team3.Services.Interfaces;

    /// <summary>
    /// DrugService is a class that implements the IDrugService interface.
    /// </summary>
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository drugRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrugService"/> class.
        /// Constructor for DrugService.
        /// </summary>
        /// <param name="drugDatabaseService">The database connection string.</param>
        public DrugService(IDrugRepository _drugRepository)
        {
            this.drugRepository = _drugRepository;
        }

        /// <summary>
        /// Get the drug information by DrugId.
        /// </summary>
        /// <param name="drugId">The id of the drug.</param>
        /// <returns>The drug.</returns>
        public Drug GetDrugById(int drugId)
        {
            return this.drugRepository.GetDrugById(drugId);
        }
    }
}
