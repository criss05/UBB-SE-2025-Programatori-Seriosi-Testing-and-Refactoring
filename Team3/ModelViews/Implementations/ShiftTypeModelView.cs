namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Team3.Service.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// Represents the view model for shift types.
    /// </summary>
    public class ShiftTypeModelView : IShiftTypeModelView
    {
        private readonly IShiftTypeService shiftTypeService;

        public ShiftTypeModelView(IShiftTypeService shiftTypeDatabaseService)
        {
            this.shiftTypeService = shiftTypeDatabaseService ?? throw new ArgumentNullException(nameof(shiftTypeDatabaseService));
            ShiftTypes = new ObservableCollection<ShiftType>();
            LoadShiftTypes();
        }

        public ObservableCollection<ShiftType> ShiftTypes { get; private set; }

        public List<ShiftType> GetShiftTypesByTimeRange(TimeOnly startTime, TimeOnly endTime)
        {
            return this.shiftTypeService.GetShiftTypesByTimeRange(startTime, endTime);
        }

        public ShiftType? GetShiftType(int shiftTypeID)
        {
            try
            {
                return shiftTypeService.GetShiftType(shiftTypeID);
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
                var shiftTypeList = shiftTypeService.GetAllShiftTypes();
                ShiftTypes.Clear();

                foreach (var shiftType in shiftTypeList)
                {
                    ShiftTypes.Add(shiftType);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error loading shift types: {exception.Message}");
            }
        }
    }
}
