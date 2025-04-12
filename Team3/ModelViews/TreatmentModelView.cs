using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.Entities;
using System.Diagnostics;
using System.Collections;

namespace Team3.ModelViews
{
    public class TreatmentModelView
    {
        private readonly TreatmentDatabaseService _treatmentModel;

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
