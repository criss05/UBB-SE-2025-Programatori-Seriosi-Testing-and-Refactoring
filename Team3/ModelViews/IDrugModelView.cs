using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IDrugModelView
    {
        /// <summary>
        /// Get the drug information by mrId
        /// </summary>
        /// <param name="mrId"></param>
        /// <returns></returns>
        public Drug getDrugById(int mrId);
    }
}
