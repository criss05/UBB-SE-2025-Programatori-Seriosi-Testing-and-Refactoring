// <copyright file="IScheduleRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.DatabaseServices.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for the schedule repository.
    /// </summary>
    public interface IScheduleRepository
    {
        /// <summary>
        /// get all schedules.
        /// </summary>
        /// <returns>The list of all schedules.</returns>
        public List<Schedule> GetAllSchedules();
    }
}
