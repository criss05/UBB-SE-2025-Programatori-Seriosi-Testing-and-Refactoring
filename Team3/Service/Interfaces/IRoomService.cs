using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.Service.Interfaces
{
    interface IRoomService
    {
        public List<Room> GetRoomsByDepartmentId(int departmentId);

        public void AddRoom(Room room);

        public Room GetRoom(int departmentId);

        public List<Room> LoadAllRooms();
    }
}
