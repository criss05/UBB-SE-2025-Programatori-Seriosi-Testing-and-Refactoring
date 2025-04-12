using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Team3.ModelViews;
using Team3.Models;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Team3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserView : Page
    {
        public IUserModelView ViewModel { get; } = new UserModelView();

        public UserView()
        {
            this.InitializeComponent();
            this.UsersListView.DataContext = ViewModel;
        }

        private void UsersListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is User selectedUser)
            {
                Debug.WriteLine($"Selected User: ID={selectedUser.Id}, Name={selectedUser.Name}, Role={selectedUser.Role}");
                //var optionsPage = new OptionsPage();
                // Navigate to the options page
                Frame.Navigate(typeof(OptionsPage), selectedUser.Id);

            }
        }

        private void AuditButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to AuditPage and pass the selected user
            //Frame.Navigate(typeof(AuditView), SelectedUser);
        }
    }
}
