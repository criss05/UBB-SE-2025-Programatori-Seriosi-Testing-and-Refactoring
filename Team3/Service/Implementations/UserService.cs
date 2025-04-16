using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.DatabaseServices.Interfaces;
using Team3.Service.Interfaces;

namespace Team3.Service.Implementations
{
    public class UserService : Interfaces.IUserService
    {
        private readonly DatabaseServices.Interfaces.IUserService userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModelView"/> class.
        /// </summary>
        /// <param name="userModel">The user database service.</param>
        public UserService(DatabaseServices.Interfaces.IUserService _userRepository)
        {
            userRepository = _userRepository;
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
            return userRepository.GetAllUsers();
        }

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The user with the specified id.</returns>
        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        /// <summary>
        /// Loads all users from the database and adds them to the Users collection.
        /// </summary>
        private void LoadAllUsers()
        {
            try
            {
                var userList = userRepository.GetAllUsers();
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
