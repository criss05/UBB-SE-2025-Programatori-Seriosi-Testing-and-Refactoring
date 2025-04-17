// <copyright file="ITreatmentDrugModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for TreatmentDrugModelView.
    /// </summary>
    public interface ITreatmentDrugModelView
    {
        /// <summary>
        /// Get a list of TreatmentDrug objects by treatmentId.
        /// </summary>
        /// <param name="treatmentId">The treatment id.</param>
        /// <returns>The list of treatments drugs.</returns>
        public List<TreatmentDrug> GetTreatmentDrugsById(int treatmentId);
    }
}
