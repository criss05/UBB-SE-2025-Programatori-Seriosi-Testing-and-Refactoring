using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DBServices
{
    public interface IDepartmentDBService
    {

        /// <summary>
        /// Get all departements
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments();


    }
}
