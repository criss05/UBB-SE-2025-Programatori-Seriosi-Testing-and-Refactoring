using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Team3.Models;
using Team3.DatabaseServices;

namespace Team3.ModelViews
{
    public class DepartmentModelView : IDepartmentModelView
    {
        // Attributes
        public ObservableCollection<Department> DepartmentsInfo { get; private set; }

        private readonly IDepartmentDBService _departmentModel;

        public Action? OnBackNavigation { get; set; } // Delegate for back navigation handling

        // Constructor
        public DepartmentModelView()
        {
            _departmentModel = DepartmentDatabaseService.Instance;
            DepartmentsInfo = new ObservableCollection<Department>();
            LoadDepartmentsInfo();
        }

        // Load detailed department information
        public void LoadDepartmentsInfo()
        {
            try
            {
                var departmentList = _departmentModel.GetDepartments();

                if (departmentList != null && departmentList.Count > 0)
                {
                    DepartmentsInfo.Clear(); // Clear old data
                    foreach (var department in departmentList)
                    {
                        DepartmentsInfo.Add(department);
                        Debug.WriteLine($"Loaded Department: ID = {department.DepartmentId}, Name = {department.DepartmentName}");
                    }
                }
                else
                {
                    Debug.WriteLine("No departments found in the database.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading department details: {ex.Message}");
            }
        }

        // Method to handle date selection in ComboBox
        public void DateSelectedComboBoxHandler(DateOnly selectedDate)
        {
            try
            {
                Debug.WriteLine($"Date selected: {selectedDate}");
                // Refresh department information based on the selected date
                LoadDepartmentsInfo();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error handling date selection: {ex.Message}");
            }
        }

        // Get departments by name
        public List<Department> GetDepartmentsByName(string name)
        {
            try
            {
                var departmentList = _departmentModel.GetDepartments();
                var filteredDepartments = departmentList.FindAll(d => d.DepartmentName.Contains(name, StringComparison.OrdinalIgnoreCase));

                if (filteredDepartments.Count == 0)
                {
                    Debug.WriteLine($"No departments found with the name '{name}'.");
                }

                return filteredDepartments;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error filtering departments: {ex.Message}");
                throw;
            }
        }
        // Handles the Back Button press
        public void BackButtonHandler()
        {
            try
            {
                Debug.WriteLine("Back button pressed. Navigating to the previous screen...");
                OnBackNavigation?.Invoke(); // Calls the delegate if assigned
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error handling back button: {ex.Message}");
            }
        }
    }
}
