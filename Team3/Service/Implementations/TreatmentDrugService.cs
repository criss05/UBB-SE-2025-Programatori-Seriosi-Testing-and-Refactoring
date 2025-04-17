using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DatabaseServices.Interfaces;
using Team3.Service.Interfaces;
using Team3.Models;

namespace Team3.Service.Implementations
{
    public class TreatmentDrugService : ITreatmentDrugService
    {
        private readonly ITreatmentDrugRepository treatmentDrugRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentDrugModelView"/> class.
        /// </summary>
        /// <param name="treatmentDrugService">An instance of ITreatmentDrugService to interact with the treatment drug data.</param>
        public TreatmentDrugService(ITreatmentDrugRepository _treatmentDrugRepository)
        {
            treatmentDrugRepository = _treatmentDrugRepository;
        }

        /// <summary>
        /// Get a list of TreatmentDrug objects by treatmentId.
        /// </summary>
        /// <param name="treatmentId">The id of the treatment.</param>
        /// <returns>A list with treatments.</returns>
        public List<TreatmentDrug> GetTreatmentDrugsById(int treatmentId)
        {
            return treatmentDrugRepository.GetTreatmentDrugsById(treatmentId);
        }
    }
}
