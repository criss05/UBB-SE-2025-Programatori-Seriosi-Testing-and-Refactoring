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
        }

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
    }
}
