// <copyright file="DepartmentModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Team3.Repository.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// This class is responsible for managing the department information in the application.
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentService"/> class.
        /// </summary>
        /// <param name="_departmentRepository">The department database service.</param>
        public DepartmentService(IDepartmentRepository _departmentRepository)
        {
            this.departmentRepository = _departmentRepository;
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
                var departmentList = this.departmentRepository.GetDepartments();
                var filteredDepartments = new List<Department>();

                foreach (var department in departmentList)
                {
                    if (department.DepartmentName != null &&
                        department.DepartmentName.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        filteredDepartments.Add(department);
                    }
                }

                if (filteredDepartments.Count == 0)
                {
                    throw new Exception($"No departments found with the name '{name}'.");
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
        /// Retrieves the complete list of departments from the repository.
        /// </summary>
        /// <returns>A list of all departments.</returns>
        public List<Department> GetDepartments()
        {
            return this.departmentRepository.GetDepartments();
        }
    }
}
