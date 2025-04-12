using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.Entities;
using System.Diagnostics;


namespace Team3.ModelViews
{
    public class TreatmentDrugModelView
    {
        private readonly TreatmentDrugDBService _treatmentdrugModel;

        public TreatmentDrugModelView()
        {
            _treatmentdrugModel = TreatmentDrugDBService.Instance;
        }

        public List<TreatmentDrug> getTreatmentDrugsByTreatmentId(int treatmentId)
        {
            return _treatmentdrugModel.getTreatmentDrugs(treatmentId);
        }
    }
}

