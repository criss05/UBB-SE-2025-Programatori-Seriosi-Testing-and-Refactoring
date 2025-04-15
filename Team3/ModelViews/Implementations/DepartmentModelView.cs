// <copyright file="DepartmentModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// This class is responsible for managing the department information in the application.
    /// </summary>
    public class DepartmentModelView : IDepartmentModelView
    {
        private readonly IDepartmentDatabaseService departmentDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentModelView"/> class.
        /// </summary>
        public DepartmentModelView()
        {
            departmentDatabaseService = DepartmentDatabaseService.Instance;
            DepartmentsInfo = new ObservableCollection<Department>();
            LoadDepartmentsInfo();
        }

        /// <summary>
        /// Gets the observable collection of departments.
        /// </summary>
        public ObservableCollection<Department> DepartmentsInfo { get; private set; }

        /// <summary>
        /// Gets or sets the action to be executed when the back button is pressed.
        /// </summary>
        public Action? OnBackNavigation { get; set; }

        /// <summary>
        /// Loads detailed department information from the database.
        /// </summary>
        public void LoadDepartmentsInfo()
        {
            try
            {
                var departmentList = departmentDatabaseService.GetDepartments();

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
            catch (Exception exception)
            {
                Debug.WriteLine($"Error loading department details: {exception.Message}");
            }
        }

        /// <summary>
        /// Handles the date selection in the ComboBox.
        /// </summary>
        /// <param name="selectedDate">The selected date.</param>
        public void DateSelectedComboBoxHandler(DateOnly selectedDate)
        {
            try
            {
                Debug.WriteLine($"Date selected: {selectedDate}");

                // Refresh department information based on the selected date
                LoadDepartmentsInfo();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error handling date selection: {exception.Message}");
            }
        }

        /// <summary>
        /// Gets a list of departments by name.
        /// </summary>
        /// <param name="name">The name of the department.</param>
        /// <returns>The list of departemts with the given name.</returns>
        public List<Department> GetDepartmentsByName(string name)
        {
            try
            {
                var departmentList = departmentDatabaseService.GetDepartments();
                var filteredDepartments = departmentList.FindAll(d => d.DepartmentName.Contains(name, StringComparison.OrdinalIgnoreCase));

                if (filteredDepartments.Count == 0)
                {
                    Debug.WriteLine($"No departments found with the name '{name}'.");
                }

                return filteredDepartments;
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error filtering departments: {exception.Message}");
                throw;
            }
        }

        /// <summary>
        /// handles the back button.
        /// </summary>
        public void BackButtonHandler()
        {
            try
            {
                Debug.WriteLine("Back button pressed. Navigating to the previous screen...");
                OnBackNavigation?.Invoke(); // Calls the delegate if assigned
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error handling back button: {exception.Message}");
            }
        }
    }
}
