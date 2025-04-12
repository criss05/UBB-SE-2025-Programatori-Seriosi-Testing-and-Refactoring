using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public interface IPatientDBService
    {
        /// <summary>
        /// get a patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Patient GetPatient(int id);
    }
}
