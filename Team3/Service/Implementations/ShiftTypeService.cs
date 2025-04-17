// <copyright file="ShiftTypeModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

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
            ShiftTypes = new ObservableCollection<ShiftType>();
            LoadShiftTypes();
        }

        /// <summary>
        /// Gets the collection of shift types.
        /// </summary>
        public ObservableCollection<ShiftType> ShiftTypes { get; private set; }

        /// <summary>
        /// Gets the shift types that fall within a specific time range.
        /// </summary>
        /// <param name="startTime">The date of start.</param>
        /// <param name="endTime">The end date.</param>
        /// <returns>The list of shift type between the dates.</returns>
        public List<ShiftType> GetShiftTypesByTimeRange(TimeOnly startTime, TimeOnly endTime)
        {
            try
            {
                var shiftTypeList = shiftTypeRepo.GetAllShiftTypes();
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
        /// <param name="shiftTypeID">Shift type id.</param>
        /// <returns>The shift type.</returns>
        public ShiftType? GetShiftType(int shiftTypeID)
        {
            try
            {
                return shiftTypeRepo.GetShiftType(shiftTypeID);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error retrieving shift type with ID {shiftTypeID}: {exception.Message}");
                return null;
            }
        }

        public List<ShiftType> GetAllShiftTypes()
        {
            try
            {
                return shiftTypeRepo.GetAllShiftTypes();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error retrieving all shift types: {exception.Message}");
                return new List<ShiftType>();
            }
        }

        /// <summary>
        /// Loads the shift types from the database and adds them to the collection.
        /// </summary>
        private void LoadShiftTypes()
        {
            try
            {
                var shiftTypeList = shiftTypeRepo.GetAllShiftTypes();
                if (shiftTypeList != null && shiftTypeList.Count > 0)
                {
                    foreach (var shiftType in shiftTypeList)
                    {
                        ShiftTypes.Add(shiftType);
                    }
                }
                else
                {
                    throw new Exception("No shift types available.");
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error loading shift types: {exception.Message}");
            }
        }
    }
}
