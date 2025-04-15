// <copyright file="ReviewView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.UI.Xaml.Controls.Primitives;
    using Microsoft.UI.Xaml.Data;
    using Microsoft.UI.Xaml.Input;
    using Microsoft.UI.Xaml.Media;
    using Microsoft.UI.Xaml.Navigation;
    using Team3.DatabaseServices.Implementations;
    using Team3.DatabaseServices.Interfaces;
    using Team3.Models;
    using Team3.ModelViews.Implementations;
    using Team3.ModelViews.Interfaces;
    using Windows.Foundation;
    using Windows.Foundation.Collections;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class ReviewView : Page
    {
        private readonly IReviewModelView reviewModelView;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewView"/> class.
        /// </summary>
        public ReviewView()
        {
            this.InitializeComponent();
            this.reviewModelView = new ReviewModelView(new ReviewDatabaseService(Config.DbConnectionString));
        }

        private async void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(this.textId.Text);
                int medicarecordId = int.Parse(this.textMedicalrecordId.Text);
                string message = this.textMessage.Text;
                int stars = int.Parse(((ComboBoxItem)this.comboBoxStars.SelectedItem).Content.ToString());

                this.reviewModelView.AddReviewButtonHandler(id, medicarecordId, message, stars);

                await this.ShowDialog("Review added successfully!", "Success");
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Error adding review: {exception.Message}");
                await this.ShowDialog("Invalid input. Please check your entries.", "Error");
            }
        }

        private async Task ShowDialog(string message, string title)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot, // Required in WinUI 3
            };

            await dialog.ShowAsync();
        }

        private void NavigateToMainPage_Click(object sender, RoutedEventArgs e)
        {
            // this.Frame.Navigate(typeof(MainPage)); // Navigate to ReviewView
        }
    }
}