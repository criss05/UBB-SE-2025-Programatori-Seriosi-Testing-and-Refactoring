// <copyright file="DepartmentModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// This class is responsible for managing the department information in the application.
    /// </summary>
    public class DepartmentModelView : IDepartmentModelView
    {
        private readonly IDepartmentDatabaseService departmentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentModelView"/> class.
        /// </summary>
        /// <param name="departmentDatabaseService">The department database service.</param>
        public DepartmentModelView(IDepartmentDatabaseService departmentDatabaseService)
        {
            this.departmentService = departmentDatabaseService;
            this.DepartmentsInfo = new ObservableCollection<Department>();
            this.LoadDepartmentsInfo();
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
                var departmentList = this.departmentService.GetDepartments();

                if (departmentList != null && departmentList.Count > 0)
                {
                    this.DepartmentsInfo.Clear(); // Clear old data
                    foreach (var department in departmentList)
                    {
                        this.DepartmentsInfo.Add(department);
                    }
                }
                else
                {
                    throw new Exception("No departments found in the database.");
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
                this.LoadDepartmentsInfo();
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
        /// <returns>The list of departments with the given name.</returns>
        public List<Department> GetDepartmentsByName(string name)
        {
            try
            {
                var departmentList = this.departmentService.GetDepartments();
                var filteredDepartments = departmentList.FindAll(d =>
                    d.DepartmentName.Contains(name, StringComparison.OrdinalIgnoreCase));

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
        /// Handles the back button.
        /// </summary>
        public void BackButtonHandler()
        {
            try
            {
                this.OnBackNavigation?.Invoke();
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error handling back button: {exception.Message}");
            }
        }
    }
}
