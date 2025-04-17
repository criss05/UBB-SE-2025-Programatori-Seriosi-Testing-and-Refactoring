// <copyright file="ShiftTypeModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// Represents the view model for shift types.
    /// </summary>
    public class ShiftTypeModelView : IShiftTypeModelView
    {
        private readonly IShiftTypeService shiftTypeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftTypeModelView"/> class.
        /// </summary>
        /// <param name="shiftTypeService">The shift type service.</param>
        /// <exception cref="ArgumentNullException">Throw error if failed.</exception>
        public ShiftTypeModelView(IShiftTypeService shiftTypeService)
        {
            this.shiftTypeService = shiftTypeService ?? throw new ArgumentNullException(nameof(shiftTypeService));
            this.ShiftTypes = new ObservableCollection<ShiftType>();
            this.LoadShiftTypes();
        }

        /// <summary>
        /// Gets the collection of shift types.
        /// </summary>
        public ObservableCollection<ShiftType> ShiftTypes { get; private set; }

        /// <summary>
        /// Loads the shift types from a specific time range.
        /// </summary>
        /// <param name="startTime">The start time of the shift.</param>
        /// <param name="endTime">The edn time of the shift.</param>
        /// <returns>The list of shifts for the specific time.</returns>
        public List<ShiftType> GetShiftTypesByTimeRange(TimeOnly startTime, TimeOnly endTime)
        {
            return this.shiftTypeService.GetShiftTypesByTimeRange(startTime, endTime);
        }

        /// <summary>
        /// Gets a specific shift type by its ID.
        /// </summary>
        /// <param name="shiftTypeID">The id of the shift.</param>
        /// <returns>The shift type with the given Id.</returns>
        public ShiftType? GetShiftType(int shiftTypeID)
        {
            try
            {
                return this.shiftTypeService.GetShiftType(shiftTypeID);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error retrieving shift type with ID {shiftTypeID}: {exception.Message}");
                return null;
            }
        }

        private void LoadShiftTypes()
        {
            try
            {
                var shiftTypeList = this.shiftTypeService.GetAllShiftTypes();
                this.ShiftTypes.Clear();

                foreach (var shiftType in shiftTypeList)
                {
                    this.ShiftTypes.Add(shiftType);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error loading shift types: {exception.Message}");
            }
        }
    }
}
