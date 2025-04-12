using System;

namespace Team3.ModelViews
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.Models;
    using Team3.DBServices;

    public class UserModelView : IUserModelView
    {
        private readonly IUserDBService _userModel;
        public ObservableCollection<User> Users { get; private set; }


        public UserModelView()
        {
            _userModel = UserDBService.Instance;
            Users = new ObservableCollection<User>();
            LoadUsers();
        }


        private void LoadUsers()
        {
            try
            {
                var userList = _userModel.GetUsers();
                if (userList != null && userList.Any())
                {
                    foreach (var user in userList)
                    {
                        Debug.WriteLine(user.ToString());

                        Users.Add(user);
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


        public List<User> GetUsers()
        {
            return this._userModel.GetUsers();
        }


        public User GetUser(int id)
        {
            return _userModel.GetUser(id);
        }
    }

}
