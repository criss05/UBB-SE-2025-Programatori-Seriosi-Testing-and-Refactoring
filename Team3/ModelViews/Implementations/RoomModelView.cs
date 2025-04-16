namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// RoomModelView class that implements IRoomModelView.
    /// </summary>
    public class RoomModelView : IRoomModelView
    {
        private readonly IRoomService roomService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomModelView"/> class.
        /// </summary>
        /// <param name="roomDatabaseService">The database service for rooms.</param>
        public RoomModelView(IRoomRepository roomDatabaseService)
        {
            this.roomService = roomService;
            Rooms = new ObservableCollection<Room>();
            RoomsInfo = new ObservableCollection<Room>();
        }

        /// <summary>
        /// Gets the attribute for Rooms.
        /// </summary>
        public ObservableCollection<Room> Rooms { get; private set; }

        /// <summary>
        /// Gets attributes for the rooms info.
        /// </summary>
        public ObservableCollection<Room> RoomsInfo { get; private set; }

        /// <summary>
        /// Filter rooms by department ID.
        /// </summary>
        /// <param name="departmentId">The id of the department.</param>
        /// <returns>A list with all the rooms.</returns>
        public ObservableCollection<Room> GetRoomsByDepartmentId(int departmentId)
        {
            return new ObservableCollection<Room>(this.roomService.GetRoomsByDepartmentId(departmentId));
        }

        /// <summary>
        /// Add a room.
        /// </summary>
        /// <param name="room">The room to be added.</param>
        public void AddRoom(Room room)
        {
            this.roomService.AddRoom(room);
        }

        /// <summary>
        /// Gets a room by their department ID.
        /// </summary>
        /// <param name="departmentId">The id of the department.</param>
        /// <returns>The room from the department.</returns>
        public Room GetRoom(int departmentId)
        {
            return this.roomService.GetRoom(departmentId);
        }

        /// <summary>
        /// Load all the rooms.
        /// </summary>
        private void LoadAllRooms()
        {
            this.Rooms = new ObservableCollection<Room>(this.roomService.LoadAllRooms());
            this.RoomsInfo = new ObservableCollection<Room>(this.roomService.LoadAllRooms());
        }
    }
}
