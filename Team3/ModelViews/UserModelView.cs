// <copyright file="UserModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices;
    using Team3.Models;

    /// <summary>
    /// Represents the user model view.
    /// </summary>
    public class UserModelView : IUserModelView
    {
        private readonly IUserDatabaseService userModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserModelView"/> class.
        /// </summary>
        public UserModelView()
        {
            this.userModel = UserDatabaseService.Instance;
            this.Users = new ObservableCollection<User>();
            this.LoadAllUsers();
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        public ObservableCollection<User> Users { get; private set; }

        /// <summary>
        /// Gets all users from the database.
        /// </summary>
        /// <returns>A list with all users.</returns>
        public List<User> GetAllUsers()
        {
            return this.userModel.GetAllUsers();
        }

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user with the specified id.</returns>
        public User GetUserById(int id)
        {
            return this.userModel.GetUserById(id);
        }

        /// <summary>
        /// Loads all users from the database and adds them to the Users collection.
        /// </summary>
        private void LoadAllUsers()
        {
            try
            {
                var userList = this.userModel.GetAllUsers();
                if (userList != null && userList.Any())
                {
                    foreach (var user in userList)
                    {
                        Debug.WriteLine(user.ToString());
                        this.Users.Add(user);
                    }
                }
                else
                {
                    Debug.WriteLine("No users returned.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
