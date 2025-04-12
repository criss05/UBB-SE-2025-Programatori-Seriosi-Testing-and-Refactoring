using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public interface ITreatmentDrugDBService
    {
        /// <summary>
        /// add a treatment drug
        /// </summary>
        /// <param name="treatmentDrug"></param>
        public void addTreatmentDrug(TreatmentDrug treatmentDrug);


        /// <summary>
        /// get all drugs for a treatment
        /// </summary>
        /// <param name="treatmentId"></param>
        /// <returns></returns>
        public List<TreatmentDrug> getTreatmentDrugs(int treatmentId);
    }
}
