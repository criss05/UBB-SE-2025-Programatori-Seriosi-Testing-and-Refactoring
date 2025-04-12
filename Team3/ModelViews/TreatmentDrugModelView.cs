using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DatabaseServices;
using Team3.Models;
using System.Diagnostics;


namespace Team3.ModelViews
{
    public class TreatmentDrugModelView : ITreatmentDrugModelView
    {

        private readonly ITreatmentDrugDBService _treatmentdrugModel;

        public TreatmentDrugModelView()
        {
            _treatmentdrugModel = TreatmentDrugDatabaseService.Instance;
        }
        public List<TreatmentDrug> getTreatmentDrugsByTreatmentId(int treatmentId)
        {
            return _treatmentdrugModel.getTreatmentDrugsById(treatmentId);
        }
    }
}
