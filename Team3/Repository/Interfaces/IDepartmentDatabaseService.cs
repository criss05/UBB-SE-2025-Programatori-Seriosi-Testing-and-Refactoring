﻿// <copyright file="IDeparmentDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for department database service.
    /// </summary>
    public interface IDepartmentDatabaseService
    {
        /// <summary>
        /// Get all departements.
        /// </summary>
        /// <returns>All departments.</returns>
        public List<Department> GetDepartments();
    }
}
