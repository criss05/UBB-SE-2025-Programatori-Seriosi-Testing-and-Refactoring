// <copyright file="IDoctorDatabaseService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Interface
{
    using Team3.Models;

    /// <summary>
    /// Interface for the doctor database service.
    /// </summary>
    public interface IDoctorDatabaseService
    {
        /// <summary>
        /// get the doctor by id.
        /// </summary>
        /// <param name="doctorId">The doctor id.</param>
        /// <returns>The doctor with the given id.</returns>
        public Doctor GetDoctorById(int doctorId);
    }
}
