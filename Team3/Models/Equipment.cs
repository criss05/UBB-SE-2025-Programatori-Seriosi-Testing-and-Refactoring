using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.Entities
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public Equipment(int equipmentId)
        {
            this.EquipmentId = equipmentId;
        }
    }
}
