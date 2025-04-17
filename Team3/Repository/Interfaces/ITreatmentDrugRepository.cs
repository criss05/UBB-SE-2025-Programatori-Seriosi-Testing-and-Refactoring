// <copyright file="ITreatmentDrugRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for the treatment drug repository.
    /// </summary>
    public interface ITreatmentDrugRepository
    {
        /// <summary>
        /// add a treatment drug.
        /// </summary>
        /// <param name="treatmentDrug">The drug treatment to be added.</param>
        public void AddNewTreatmentDrug(TreatmentDrug treatmentDrug);

        /// <summary>
        /// get all drugs for a treatment.
        /// </summary>
        /// <param name="treatmentId">The treatment id.</param>
        /// <returns>The list of treatments drug with the given treatment id.</returns>
        public List<TreatmentDrug> GetTreatmentDrugsById(int treatmentId);
    }
}
