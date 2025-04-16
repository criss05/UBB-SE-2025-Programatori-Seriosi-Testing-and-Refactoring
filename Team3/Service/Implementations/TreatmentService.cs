using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DatabaseServices.Interfaces;
using Team3.ModelViews.Interfaces;
using Team3.Models;
using Team3.Service.Interfaces;

namespace Team3.Service.Implementations
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository treatmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentModelView"/> class.
        /// </summary>
        /// <param name="_treatmentDatabaseService">The database service for treatment operations.</param>
        public TreatmentService(ITreatmentRepository _treatmentRepository)
        {
            treatmentRepository = _treatmentRepository;
        }

        /// <summary>
        /// Get the treatment by medical record id.
        /// </summary>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <returns>The treatment.</returns>
        public Treatment GetTreatmentByMedicalRecordId(int treatmentId)
        {
            return treatmentRepository.GetTreatmentByMedicalRecordId(treatmentId);
        }
    }
}
