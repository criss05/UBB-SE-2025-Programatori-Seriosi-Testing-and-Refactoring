namespace Team3.ModelViews
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


    }
}
