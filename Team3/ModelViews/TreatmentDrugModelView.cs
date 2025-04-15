namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Model view for TreatmentDrug.
    /// </summary>
    public class TreatmentDrugModelView : ITreatmentDrugModelView
    {
        private readonly ITreatmentDrugDatabaseService treatmentDrugDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentDrugModelView"/> class.
        /// </summary>
        /// <param name="treatmentDrugService">An instance of ITreatmentDrugService to interact with the treatment drug data.</param>
        public TreatmentDrugModelView(ITreatmentDrugDatabaseService _treatmentDrugDatabaseService)
        {
            this.treatmentDrugDatabaseService = _treatmentDrugDatabaseService;
        }

        /// <summary>
        /// Get a list of TreatmentDrug objects by treatmentId.
        /// </summary>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <returns>A list with treatments.</returns>
        public List<TreatmentDrug> GetTreatmentDrugsById(int treatmentId)
        {
            return this.treatmentDrugDatabaseService.GetTreatmentDrugsById(treatmentId);
        }
    }
}
