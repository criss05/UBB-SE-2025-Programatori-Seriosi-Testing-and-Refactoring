// <copyright file="UserModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;

    /// <summary>
    /// Represents the user model view.
    /// </summary>
    public class UserModelView : IUserModelView
    {
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModelView"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserModelView(IUserService userService)
        {
            this.userService = userService;
            this.Users = new ObservableCollection<User>();
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        public ObservableCollection<User> Users { get; private set; }

        /// <summary>
        /// Gets the user by username and password.
        /// </summary>
        /// <returns>The list of all users.</returns>
        public List<User> GetAllUsers()
        {
            return this.userService.GetAllUsers();
        }

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user with the given id.</returns>
        public User GetUserById(int id)
        {
            return this.userService.GetUserById(id);
        }

        /// <summary>
        /// Loads all users from the database and adds them to the Users collection.
        /// </summary>
        public void LoadAllUsers()
        {
            try
            {
                var userList = this.userService.GetAllUsers();
                if (userList != null && userList.Any())
                {
                    foreach (var user in userList)
                    {
                        this.Users.Add(user);
                    }
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error loading users: " + exception.Message);
            }
        }
    }
}
