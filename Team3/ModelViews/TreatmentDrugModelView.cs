// <copyright file="TreatmentDrugModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Model view for TreatmentDrug.
    /// </summary>
    public class TreatmentDrugModelView : ITreatmentDrugModelView
    {
        private readonly ITreatmentDrugService treatmentdrugModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentDrugModelView"/> class.
        /// </summary>
        public TreatmentDrugModelView()
        {
            this.treatmentdrugModel = TreatmentDrugDatabaseService.Instance;
        }

        /// <summary>
        /// Get a list of TreatmentDrug objects by treatmentId.
        /// </summary>
        /// <param name="treatmentId">Te id of the treatment.</param>
        /// <returns>A list with treatments.</returns>
        public List<TreatmentDrug> GetTreatmentDrugsById(int treatmentId)
        {
            return this.treatmentdrugModel.getTreatmentDrugsById(treatmentId);
        }
    }
}
