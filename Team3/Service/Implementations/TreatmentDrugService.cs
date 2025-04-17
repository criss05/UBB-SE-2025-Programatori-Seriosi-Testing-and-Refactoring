// <copyright file="TreatmentDrugService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;
    using Team3.Repository.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Service class for managing treatment drugs.
    /// </summary>
    public class TreatmentDrugService : ITreatmentDrugService
    {
        private readonly ITreatmentDrugRepository treatmentDrugRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentDrugService"/> class.
        /// </summary>
        /// <param name="treatmentDrugRepository">An instance of ITreatmentDrugService to interact with the treatment drug data.</param>
        public TreatmentDrugService(ITreatmentDrugRepository treatmentDrugRepository)
        {
            this.treatmentDrugRepository = treatmentDrugRepository;
        }

        /// <summary>
        /// Get a list of TreatmentDrug objects by treatmentId.
        /// </summary>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <returns>A list with treatments.</returns>
        public List<TreatmentDrug> GetTreatmentDrugsById(int treatmentId)
        {
            return this.treatmentDrugRepository.GetTreatmentDrugsById(treatmentId);
        }
    }
}
