using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DBServices
{
    public interface IRoomDBService
    {
        /// <summary>
        /// get all rooms
        /// </summary>
        /// <returns></returns>
        public List<Room> GetRooms();
    }
}
