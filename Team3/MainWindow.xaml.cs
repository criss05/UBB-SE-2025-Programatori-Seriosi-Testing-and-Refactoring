// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3
{
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Team3.Views;

    /// <summary>
    /// MainWindow class that serves as the main entry point for the application.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.ExtendsContentIntoTitleBar = false;

            // Navigate to MainPage on startup
            this.MainFrame.Navigate(typeof(UserView));
        }
    }
}
