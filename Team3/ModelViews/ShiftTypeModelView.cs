// <copyright file="ShiftTypeModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Represents the view model for shift types.
    /// </summary>
    public class ShiftTypeModelView : IShiftTypeModelView
    {
        private readonly IShiftTypeDatabaseService shiftTypeModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftTypeModelView"/> class.
        /// </summary>
        public ShiftTypeModelView()
        {
            this.shiftTypeModel = (IShiftTypeDatabaseService?)ShiftTypeDatabaseService.Instance;
            this.ShiftTypes = new ObservableCollection<ShiftType>();
            this.LoadShiftTypes();
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
                var shiftTypeList = this.shiftTypeModel.GetAllShiftTypes();
                var filteredShiftTypes = new List<ShiftType>();

                foreach (var shiftType in shiftTypeList)
                {
                    if (shiftType.ShiftTypeStartTime >= startTime && shiftType.ShiftTypeEndTime <= endTime)
                    {
                        filteredShiftTypes.Add(shiftType);
                        Debug.WriteLine(shiftType.ToString());
                    }
                }

                if (filteredShiftTypes.Count == 0)
                {
                    Debug.WriteLine($"No shift types found in the time range {startTime} - {endTime}");
                }

                return filteredShiftTypes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error filtering shift types: {ex.Message}");
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
                return this.shiftTypeModel.GetShiftType(shiftTypeID);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving shift type with ID {shiftTypeID}: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Loads the shift types from the database and adds them to the collection.
        /// </summary>
        private void LoadShiftTypes()
        {
            try
            {
                var shiftTypeList = this.shiftTypeModel.GetAllShiftTypes();
                if (shiftTypeList != null && shiftTypeList.Count > 0)
                {
                    foreach (var shiftType in shiftTypeList)
                    {
                        Debug.WriteLine(shiftType.ToString());
                        this.ShiftTypes.Add(shiftType);
                    }
                }
                else
                {
                    Debug.WriteLine("No shift types available.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading shift types: {ex.Message}");
            }
        }
    }
}
