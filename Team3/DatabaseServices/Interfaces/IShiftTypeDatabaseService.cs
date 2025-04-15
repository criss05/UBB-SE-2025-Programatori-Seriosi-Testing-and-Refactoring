using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices.Interfaces
{
    public interface IShiftTypeDatabaseService
    {
        /// <summary>
        /// get all shift types
        /// </summary>
        /// <returns></returns>
        public List<ShiftType> GetAllShiftTypes();

        /// <summary>
        /// get the shift by it's type
        /// </summary>
        /// <param name="shiftTypeId"></param>
        /// <returns></returns>
        public ShiftType? GetShiftType(int shiftTypeId);
    }
}
