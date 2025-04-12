using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.ModelViews
{
    public interface IMedicalRecordModelView
    {

        /// <summary>
        /// Get medical record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MedicalRecord GetMedicalRecordById(int id);
    }
}
