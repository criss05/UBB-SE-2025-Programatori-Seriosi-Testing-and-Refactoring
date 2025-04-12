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
        private readonly UserDatabaseService _userModel;
        public ObservableCollection<User> Users { get; private set; }
        public UserModelView()
        {
            _userModel = UserDatabaseService.Instance;
            Users = new ObservableCollection<User>();
            LoadAllUsers();
        }
        private void LoadAllUsers()
        {
            try
            {
                var userList = _userModel.GetAllUsers();
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
        public List<User> GetAllUsers()
        {
            return this._userModel.GetAllUsers();
        }
        public User GetUserById(int id)
        {
            return _userModel.GetUserById(id);
        }
    }

}
