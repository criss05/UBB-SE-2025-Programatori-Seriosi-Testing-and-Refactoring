// <copyright file="IDoctorModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for the Doctor Model View.
    /// </summary>
    public interface IDoctorModelView
    {
        /// <summary>
        /// Get the doctor information by ID.
        /// </summary>
        /// <param name="doctorId">The doctor id.</param>
        /// <returns>The doctor with the given Id.</returns>
        public Doctor GetDoctorById(int doctorId);
    }
}
