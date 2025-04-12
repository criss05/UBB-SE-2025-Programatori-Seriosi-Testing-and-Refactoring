using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Entities;
using Team3.Models;

namespace Team3.ModelViews
{

    class PatientModelView
    {

        private readonly PatientDBService patientModel;


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
