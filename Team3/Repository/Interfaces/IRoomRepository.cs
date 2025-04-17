// <copyright file="IRoomRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for the Room repository.
    /// </summary>
    public interface IRoomRepository
    {
        /// <summary>
        /// get all rooms.
        /// </summary>
        /// <returns>the list of all rooms.</returns>
        public List<Room> GetRooms();

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
