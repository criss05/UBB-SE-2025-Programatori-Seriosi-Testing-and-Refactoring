using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.DatabaseServices;

namespace Team3.ModelViews
{
    public class DrugModelView : IDrugModelView
    {

        private readonly IDrugDBService _drugModel;


        public DrugModelView()
        {
            _drugModel = DrugDatabaseService.Instance;
        }

        public Drug getDrugById(int mrId)
        {
            return _drugModel.getDrugById(mrId);
        }
    }
}
