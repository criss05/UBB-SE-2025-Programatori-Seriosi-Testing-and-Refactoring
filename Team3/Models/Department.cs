// <copyright file="Department.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a department in the organization.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Department"/> class.
        /// </summary>
        /// <param name="departmentName">The name of the department.</param>
        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;
        }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public string DepartmentName { get; set; }

        public override string ToString()
        {
            return $"Department(Name: {this.DepartmentName})";
        }
    }
}
