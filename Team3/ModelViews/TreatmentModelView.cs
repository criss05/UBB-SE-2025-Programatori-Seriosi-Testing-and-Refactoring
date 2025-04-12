using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DatabaseServices;
using Team3.Models;
using System.Diagnostics;
using System.Collections;

namespace Team3.ModelViews
{
    public class TreatmentModelView : ITreatmentModelView
    {

        private readonly ITreatmentDBService _treatmentModel;


        public TreatmentModelView()
        {
            _treatmentModel = TreatmentDatabaseService.Instance;
        }
        public Treatment GetTreatmentByMedicalRecordId(int mrId)
        {
            return this._treatmentModel.GetTreatmentByMedicalRecordId(mrId);
        }

    }
}
