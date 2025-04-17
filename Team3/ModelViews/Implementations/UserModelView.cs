namespace Team3.ModelViews.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.Service.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Interfaces;
    using Team3.Service.Interfaces;
    using Team3.DatabaseServices.Implementations;

    /// <summary>
    /// Represents the user model view.
    /// </summary>
    public class UserModelView : IUserModelView
    {
        private readonly IUserService userService;

        public UserModelView(IUserService _userService)
        {
            userService = _userService;
            Users = new ObservableCollection<User>();
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        public ObservableCollection<User> Users { get; private set; }

        public List<User> GetAllUsers()
        {
            return this.userService.GetAllUsers();
        }

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
