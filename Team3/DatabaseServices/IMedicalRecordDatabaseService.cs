using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.DatabaseServices
{
    public interface IMedicalRecordDatabaseService
    {
        public MedicalRecord GetMedicalRecordById(int id);


    }
}
