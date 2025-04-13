// <copyright file="UserView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using System.Diagnostics;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Team3.Models;
    using Team3.ModelViews;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserView"/> class.
        /// </summary>
        public UserView()
        {
            this.InitializeComponent();
            this.UsersListView.DataContext = this.ViewModel;
        }

        /// <summary>
        /// Gets the view model for the user view.
        /// </summary>
        public IUserModelView ViewModel { get; } = new UserModelView();

        /// <summary>
        /// Handles the item click event for the users list view.
        /// </summary>
        /// <param name="sender">The semder.</param>
        /// <param name="e">The event.</param>
        private void UsersListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is User selectedUser)
            {
                Debug.WriteLine($"Selected User: ID={selectedUser.Id}, Name={selectedUser.Name}, Role={selectedUser.Role}");

                // var optionsPage = new OptionsPage();
                // Navigate to the options page
                this.Frame.Navigate(typeof(OptionsPage), selectedUser.Id);
            }
        }

        private void AuditButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to AuditPage and pass the selected user
            // this.Frame.Navigate(typeof(AuditView), SelectedUser);
        }
    }
}
