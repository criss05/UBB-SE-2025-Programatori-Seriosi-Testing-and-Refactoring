using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface ITreatmentDrugModelView
    {

        /// <summary>
        /// Get a list of TreatmentDrug objects by treatmentId
        /// </summary>
        /// <param name="treatmentId"></param>
        /// <returns></returns>
        public List<TreatmentDrug> getTreatmentDrugsById(int treatmentId);
    }
}
