namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;

    /// <summary>
    /// Represents the user model view.
    /// </summary>
    public class UserModelView : IUserModelView
    {
        private readonly IUserDatabaseService userDatabaseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModelView"/> class.
        /// </summary>
        /// <param name="userModel">The user database service.</param>
        public UserModelView(IUserDatabaseService _userDatabaseService)
        {
            userDatabaseService = _userDatabaseService;
            Users = new ObservableCollection<User>();
            LoadAllUsers();
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
            return userDatabaseService.GetAllUsers();
        }

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user with the specified id.</returns>
        public User GetUserById(int id)
        {
            return userDatabaseService.GetUserById(id);
        }

        /// <summary>
        /// Loads all users from the database and adds them to the Users collection.
        /// </summary>
        private void LoadAllUsers()
        {
            try
            {
                var userList = userDatabaseService.GetAllUsers();
                if (userList != null && userList.Any())
                {
                    foreach (var user in userList)
                    {
                        Users.Add(user);
                    }
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }
    }
}
