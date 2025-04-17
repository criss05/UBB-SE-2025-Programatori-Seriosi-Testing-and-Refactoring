using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers();

        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id);
    }
}
