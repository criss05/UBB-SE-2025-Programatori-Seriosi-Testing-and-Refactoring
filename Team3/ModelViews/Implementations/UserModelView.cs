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
            Users = this.userService.Users;
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
    }
}
