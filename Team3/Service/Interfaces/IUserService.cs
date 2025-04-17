// <copyright file="IUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for the user model view.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>A list with all users.</returns>
        public List<User> GetAllUsers();

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user for the specific id.</returns>
        public User GetUserById(int id);
    }
}
