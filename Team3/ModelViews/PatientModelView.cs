using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.DatabaseServices;

namespace Team3.ModelViews
{

    class PatientModelView : IPatientModelView
    {

        private readonly IPatientDatabaseService patientModel;

        public PatientModelView()
        {
            this.patientModel = PatientDatabaseService.Instance;
        }
        public Patient GetPatientById(int id)
        {
            return this.patientModel.GetPatientById(id);
        }
    }
}
