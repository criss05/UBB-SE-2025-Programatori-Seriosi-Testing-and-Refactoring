using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.DBServices;

namespace Team3.ModelViews
{

    class PatientModelView : IPatientModelView
    {

        private readonly IPatientDBService patientModel;


        public PatientModelView()
        {
            this.patientModel = PatientDBService.Instance;

        }


        public Patient GetPatient(int id)
        {
            return this.patientModel.GetPatient(id);
        }
    }
}
