// <copyright file="TreatmentView.xaml.cs" company="PlaceholderCompany">
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
    /// Interaction logic for TreatmentView.xaml.
    /// </summary>
    public partial class TreatmentView : Page
    {
        private readonly ITreatmentModelView treatmentModelView;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentView"/> class.
        /// Constructor for TreatmentView.
        /// </summary>
        public TreatmentView()
        {
            this.InitializeComponent();
            this.treatmentModelView = new TreatmentModelView(new TreatmentService(new TreatmentRepository(Config.DbConnectionString)));
        }

        private async void AddTreatmentButton_Click(object sender, RoutedEventArgs error)
        {
            try
            {
                int id = int.Parse(this.textId.Text);
                int medicalRecordId = int.Parse(this.textMedicalrecordId.Text);

                // treatmentModelView.addTreatmentButtonHandler(id, medicarecordId);
                await this.ShowDialog("Treatment added successfully!", "Success");
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
