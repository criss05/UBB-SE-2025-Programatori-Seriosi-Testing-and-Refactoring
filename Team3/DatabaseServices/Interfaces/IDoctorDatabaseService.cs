using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices.Interfaces
{
    public interface IDoctorDatabaseService
    {
        /// <summary>
        /// get the doctor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Doctor GetDoctorById(int id);


    }
}
