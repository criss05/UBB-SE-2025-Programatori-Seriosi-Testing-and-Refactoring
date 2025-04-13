// <copyright file="IUserModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    /// <summary>
    /// Interface for the user model view.
    /// </summary>
    public interface IUserModelView
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
