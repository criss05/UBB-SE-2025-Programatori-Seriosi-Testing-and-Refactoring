using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DBServices
{
    public interface IDoctorDBService
    {
        /// <summary>
        /// get the doctor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Doctor GetDoctor(int id);


    }
}
