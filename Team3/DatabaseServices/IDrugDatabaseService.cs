using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public interface IDrugDatabaseService
    {
        /// <summary>
        /// get drug by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Drug getDrugById(int Id);
    }
}
