using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices.Interfaces
{
    public interface IRoomDatabaseService
    {
        /// <summary>
        /// get all rooms
        /// </summary>
        /// <returns></returns>
        public List<Room> GetRooms();

        /// <summary>
        /// Add a room.
        /// </summary>
        /// <param name="room">The room to be added.</param>
        /// <returns></returns>
        public void AddRoom(Room room);

        /// <summary>
        /// Gets a room by their department ID.
        /// </summary>
        /// <param name="departmentId">The department ID.</param>
        /// <returns>A <see cref="Room"/> object.</returns>
        public Room GetRoom(int departmentId);
    }
}
