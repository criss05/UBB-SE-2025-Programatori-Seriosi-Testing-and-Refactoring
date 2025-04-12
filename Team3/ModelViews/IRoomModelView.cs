using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IRoomModelView
    {
        /// <summary>
        /// Get all rooms by department ID
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public ObservableCollection<Room> GetRoomsByDepartmentId(int departmentId);


    }
}
