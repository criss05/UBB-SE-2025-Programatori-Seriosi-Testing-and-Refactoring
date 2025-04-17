// <copyright file="Department.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    /// <summary>
    /// Represents a department in the organization.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Department"/> class.
        /// </summary>
        /// <param name="id">The unique identifier for the department.</param>
        /// <param name="departmentName">The name of the department.</param>
        public Department(int id, string departmentName)
        {
            this.Id = id;
            this.DepartmentName = departmentName;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the department.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Returns a string representation of the department.
        /// </summary>
        /// <returns>string representation of the department.</returns>
        public override string ToString()
        {
            return $"Department(Id: {this.Id}, Name: {this.DepartmentName})";
        }
    }
}