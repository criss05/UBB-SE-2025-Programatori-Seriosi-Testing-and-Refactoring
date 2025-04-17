// <copyright file="ReviewView.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.Views
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Team3.ModelViews.Implementations;
    using Team3.ModelViews.Interfaces;
    using Team3.Repository.Implementations;
    using Team3.Service.Implementations;

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
            this.reviewModelView = new ReviewModelView(new ReviewService(new ReviewRepository(Config.DbConnectionString)));
        }

        private async void AddReviewButton_Click(object sender, RoutedEventArgs error)
        {
            try
            {
                int id = int.Parse(this.textId.Text);
                int medicarecordId = int.Parse(this.textMedicalrecordId.Text);
                string message = this.textMessage.Text;
                int stars = int.Parse(((ComboBoxItem)this.comboBoxStars.SelectedItem).Content.ToString());

                this.reviewModelView.AddReviewButtonHandler(medicarecordId, message, stars);

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

        private void NavigateToMainPage_Click(object sender, RoutedEventArgs error)
        {
            // this.Frame.Navigate(typeof(MainPage)); // Navigate to ReviewView
        }
    }
}