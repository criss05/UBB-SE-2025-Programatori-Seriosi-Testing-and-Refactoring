namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Model view for Treatment.
    /// </summary>
    public class TreatmentModelView : ITreatmentModelView
    {
        private readonly ITreatmentDatabaseService treatmentDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentModelView"/> class.
        /// </summary>
        /// <param name="_treatmentDatabaseService">The database service for treatment operations.</param>
        public TreatmentModelView(ITreatmentDatabaseService _treatmentDatabaseService)
        {
            this.treatmentDatabaseService = _treatmentDatabaseService;
        }

        /// <summary>
        /// Get the treatment by medical record id.
        /// </summary>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int treatmentId)
        {
            return this.treatmentDatabaseService.GetTreatmentByMedicalRecordId(treatmentId);
        }
    }
}
