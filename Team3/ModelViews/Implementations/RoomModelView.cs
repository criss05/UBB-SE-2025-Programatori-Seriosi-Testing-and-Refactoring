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

    /// <summary>
    /// RoomModelView class that implements IRoomModelView.
    /// </summary>
    public class RoomModelView : IRoomModelView
    {
        private readonly IRoomDatabaseService roomDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomModelView"/> class.
        /// </summary>
        /// <param name="roomDatabaseService">The database service for rooms.</param>
        public RoomModelView(IRoomDatabaseService roomDatabaseService)
        {
            this.roomDatabaseService = roomDatabaseService;
            Rooms = new ObservableCollection<Room>();
            RoomsInfo = new ObservableCollection<Room>();
            LoadAllRooms();
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
            try
            {
                var filteredRooms = new ObservableCollection<Room>(
                    roomDatabaseService.GetRooms().Where(r => r.DepartmentId == departmentId));

                if (!filteredRooms.Any())
                {
                    throw new Exception($"No rooms found for Department ID: {departmentId}");
                }

                return filteredRooms;
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error filtering rooms by Department ID: {exception.Message}");
                throw;
            }
        }

        /// <summary>
        /// Load all the rooms.
        /// </summary>
        private void LoadAllRooms()
        {
            try
            {
                var roomList = roomDatabaseService.GetRooms();
                if (roomList != null && roomList.Count > 0)
                {
                    foreach (var room in roomList)
                    {
                        Rooms.Add(room);
                        RoomsInfo.Add(room);
                    }
                }
                else
                {
                    Debug.WriteLine("No rooms found.");
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error loading rooms: {exception.Message}");
            }
        }
    }
}
