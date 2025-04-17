// <copyright file="ShiftTypeService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Repository.Interfaces;

    /// <summary>
    /// Represents the view model for shift types.
    /// </summary>
    public class ShiftTypeService : IShiftTypeService
    {
        private readonly IShiftTypeRepo shiftTypeRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftTypeService"/> class.
        /// </summary>
        /// <param name="shiftTypeRepo">Service used to interact with the shift type database.</param>
        public ShiftTypeService(IShiftTypeRepo shiftTypeRepo)
        {
            this.shiftTypeRepo = shiftTypeRepo ?? throw new ArgumentNullException(nameof(shiftTypeRepo));
        }

        /// <summary>
        /// Gets all shift types.
        /// </summary>
        /// <returns>A list of all shift types.</returns>
        public List<ShiftType> GetAllShiftTypes()
        {
            try
            {
                return this.shiftTypeRepo.GetAllShiftTypes();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error retrieving all shift types: {exception.Message}");
                return new List<ShiftType>();
            }
        }

        /// <summary>
        /// Gets the shift types within a specific time range.
        /// </summary>
        /// <param name="startTime">The start time of the shift.</param>
        /// <param name="endTime">The end time of the shift.</param>
        /// <returns>The list of shift types within the given interval.</returns>
        public List<ShiftType> GetShiftTypesByTimeRange(TimeOnly startTime, TimeOnly endTime)
        {
            try
            {
                var shiftTypeList = this.shiftTypeRepo.GetAllShiftTypes();
                var filteredShiftTypes = new List<ShiftType>();

                foreach (var shiftType in shiftTypeList)
                {
                    if (shiftType.ShiftTypeStartTime >= startTime && shiftType.ShiftTypeEndTime <= endTime)
                    {
                        filteredShiftTypes.Add(shiftType);
                    }
                }

                if (filteredShiftTypes.Count == 0)
                {
                    throw new Exception($"No shift types found in the time range {startTime} - {endTime}");
                }

                return filteredShiftTypes;
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error filtering shift types: {exception.Message}");
                throw;
            }
        }

        /// <summary>
        /// Gets a specific shift type by its ID.
        /// </summary>
        /// <param name="shiftTypeID">The shift type id.</param>
        /// <returns>The shift type with the given id.</returns>
        public ShiftType? GetShiftType(int shiftTypeID)
        {
            try
            {
                return this.shiftTypeRepo.GetShiftType(shiftTypeID);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error retrieving shift type with ID {shiftTypeID}: {exception.Message}");
                return null;
            }
        }
    }
}
