// <copyright file="RoomService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.Service.Interfaces;

    class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomService"/> class.
        /// </summary>
        /// <param name="roomRepository">The database service for rooms.</param>
        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        /// <summary>
        /// Filter rooms by department ID.
        /// </summary>
        /// <param name="departmentId">The id of the department.</param>
        /// <returns>A list with all the rooms.</returns>
        public List<Room> GetRoomsByDepartmentId(int departmentId)
        {
            try
            {
                var filteredRooms = new List<Room>(
                    this.roomRepository.GetRooms().Where(r => r.DepartmentId == departmentId));

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
        /// Add a room.
        /// </summary>
        /// <param name="room">The room to be added.</param>
        public void AddRoom(Room room)
        {
            this.roomRepository.AddRoom(room);
        }

        /// <summary>
        /// Gets a room by their department ID.
        /// </summary>
        /// <param name="departmentId">The id of the department.</param>
        /// <returns>The room.</returns>
        public Room GetRoom(int departmentId)
        {
            return this.roomRepository.GetRoom(departmentId);
        }

        /// <summary>
        /// Load all the rooms.
        /// </summary>
        public List<Room> LoadAllRooms()
        {
            try
            {
                var roomList = roomRepository.GetRooms();
                if (roomList != null && roomList.Count > 0)
                {
                    return roomList;
                }
                else
                {
                    Debug.WriteLine("No rooms found.");
                    return new List<Room>();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error loading rooms: {exception.Message}");
                return new List<Room>();
            }
        }
    }
}
