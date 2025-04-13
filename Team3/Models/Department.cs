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
        /// <param name="departmentId">The id of the department.</param>
        /// <param name="departmentName">The name of the department.</param>
        public Department(int departmentId, string departmentName)
        {
            this.DepartmentId = departmentId;
            this.DepartmentName = departmentName;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the department.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
