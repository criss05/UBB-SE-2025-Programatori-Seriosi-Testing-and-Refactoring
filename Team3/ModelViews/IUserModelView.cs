using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IUserModelView
    {
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers();

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id);
    }
}
