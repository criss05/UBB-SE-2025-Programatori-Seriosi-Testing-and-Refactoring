using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DBServices
{
    public interface IUserDBService
    {
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers();

        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id);
    }
}
