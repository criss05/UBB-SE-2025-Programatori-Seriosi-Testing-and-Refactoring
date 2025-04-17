namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Model view for Treatment.
    /// </summary>
    public class TreatmentModelView : ITreatmentModelView
    {
        private readonly ITreatmentService treatmentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentModelView"/> class.
        /// </summary>
        /// <param name="_treatmentDatabaseService">The database service for treatment operations.</param>
        public TreatmentModelView(ITreatmentService _treatmentService)
        {
            treatmentService = _treatmentService;
        }

        /// <summary>
        /// Get the treatment by medical record id.
        /// </summary>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int treatmentId)
        {
            return treatmentService.GetTreatmentByMedicalRecordId(treatmentId);
        }
    }
}
