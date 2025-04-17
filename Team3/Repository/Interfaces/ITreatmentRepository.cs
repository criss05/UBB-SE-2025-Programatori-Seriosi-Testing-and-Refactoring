using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices.Interfaces
{
    public interface ITreatmentRepository
    {
        /// <summary>
        /// add a treatment 
        /// </summary>
        /// <param name="treatment"></param>
        public void AddNewTreatment(Treatment treatment);

        /// <summary>
        /// get a treatment by medical record
        /// </summary>
        /// <param name="mrId"></param>
        /// <returns></returns>
        public Treatment GetTreatmentByMedicalRecordId(int mrId);
    }
}
