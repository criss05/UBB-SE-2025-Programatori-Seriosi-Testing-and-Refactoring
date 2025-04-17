// <copyright file="UserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using Team3.Models;

    /// <summary>
    /// Service for user operations.
    /// </summary>
    public class UserService : Interfaces.IUserService
    {
        private readonly Repository.Interfaces.IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user database service.</param>
        public UserService(Repository.Interfaces.IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Gets all users from the database.
        /// </summary>
        /// <returns>A list with all users.</returns>
        public List<User> GetAllUsers()
        {
            return this.userRepository.GetAllUsers();
        }

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user with the specified id.</returns>
        public User GetUserById(int id)
        {
            return this.userRepository.GetUserById(id);
        }
    }
}
