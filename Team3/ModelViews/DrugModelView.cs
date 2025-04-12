using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.DBServices;

namespace Team3.ModelViews
{
    public class DrugModelView : IDrugModelView
    {
        private readonly IDrugDBService _drugModel;

        public DrugModelView()
        {
            _drugModel = DrugDBService.Instance;
        }

        public Drug getDrug(int mrId)
        {
            return _drugModel.getDrug(mrId);
        }
    }
}
