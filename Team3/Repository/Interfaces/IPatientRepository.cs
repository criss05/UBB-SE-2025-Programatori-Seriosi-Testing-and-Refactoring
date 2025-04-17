using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices.Interfaces
{
    public interface IPatientRepository
    {
        /// <summary>
        /// get a patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Patient GetPatientById(int id);

        /// <summary>
        /// add a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public void AddPatient(Patient patient);
    }
}
