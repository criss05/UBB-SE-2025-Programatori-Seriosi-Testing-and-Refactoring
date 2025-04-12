using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Team3.Entities;
using Team3.Models;

namespace Team3.ModelViews
{
    public class ShiftTypeModelView
    {
        private readonly ShiftTypeDBService _shiftTypeModel;
        public ObservableCollection<ShiftType> ShiftTypes { get; private set; }

        public ShiftTypeModelView()
        {
            _shiftTypeModel = ShiftTypeDBService.Instance;
            ShiftTypes = new ObservableCollection<ShiftType>();
            LoadShiftTypes();
        }

        private void LoadShiftTypes()
        {
            try
            {
                var shiftTypeList = _shiftTypeModel.GetShiftTypes();
                if (shiftTypeList != null && shiftTypeList.Count > 0)
                {
                    foreach (var shiftType in shiftTypeList)
                    {
                        Debug.WriteLine(shiftType.ToString());
                        ShiftTypes.Add(shiftType);
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

        public List<ShiftType> GetShiftTypesByTimeRange(TimeOnly startTime, TimeOnly endTime)
        {
            try
            {
                var shiftTypeList = _shiftTypeModel.GetShiftTypes();
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

        public ShiftType? GetShiftType(int shiftTypeID)
        {
            try
            {
                return _shiftTypeModel.GetShiftType(shiftTypeID);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving shift type with ID {shiftTypeID}: {ex.Message}");
                return null;
            }
        }
    }
}
