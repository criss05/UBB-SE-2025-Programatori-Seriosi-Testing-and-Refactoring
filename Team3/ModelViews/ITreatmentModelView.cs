using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface ITreatmentModelView
    {
        /// <summary>
        /// Get the treatment by medical record id
        /// </summary>
        /// <param name="mrId"></param>
        /// <returns></returns>
        public Treatment GetTreatmentByMedicalRecordId(int mrId);
    }
}
