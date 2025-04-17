// <copyright file="IUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Repository.Interfaces
{
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Interface for user service.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// get all users.
        /// </summary>
        /// <returns>The list of users.</returns>
        public List<User> GetAllUsers();

        /// <summary>
        /// get user by id.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The user with the given id.</returns>
        public User GetUserById(int userId);
    }
}
