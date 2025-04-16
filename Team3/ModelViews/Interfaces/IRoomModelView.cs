namespace Team3.ModelViews.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for Room Model View
    /// </summary>
    public interface IRoomModelView
    {
        /// <summary>
        /// Get all rooms by department ID.
        /// </summary>
        /// <param name="departmentId">The departemnt id.</param>
        /// <returns>The rooms from a specifi departemnt.</returns>
        public ObservableCollection<Room> GetRoomsByDepartmentId(int departmentId);

        /// <summary>
        /// Add a room.
        /// </summary>
        /// <param name="room">The room to be added.</param>
        public void AddRoom(Room room);

        /// <summary>
        /// Gets a room by their department ID.
        /// </summary>
        /// <param name="departmentId">The department ID.</param>
        /// <returns>A <see cref="Room"/> object.</returns>
        public Room GetRoom(int departmentId);
    }
}
