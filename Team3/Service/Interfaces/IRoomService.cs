// <copyright file="IRoomService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for room service.
    /// </summary>
    public interface IRoomService
    {
        /// <summary>
        /// Gets the list of rooms by department ID.
        /// </summary>
        /// <param name="departmentId">The department id.</param>
        /// <returns>The rooms from the department.</returns>
        public List<Room> GetRoomsByDepartmentId(int departmentId);

        /// <summary>
        /// Adds a room to the list of rooms.
        /// </summary>
        /// <param name="room">The room to be added.</param>
        public void AddRoom(Room room);

        /// <summary>
        /// Gets the room by department ID.
        /// </summary>
        /// <param name="departmentId">The departemtn id.</param>
        /// <returns>The room from the department.</returns>
        public Room GetRoom(int departmentId);

        /// <summary>
        /// Loads all rooms from the database.
        /// </summary>
        /// <returns>The list of all rooms.</returns>
        public List<Room> LoadAllRooms();
    }
}
