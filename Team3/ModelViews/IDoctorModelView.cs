using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IDoctorModelView
    {
        /// <summary>
        /// Get the doctor information by ID
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public Doctor GetDoctorById(int doctorId);
    }
}
