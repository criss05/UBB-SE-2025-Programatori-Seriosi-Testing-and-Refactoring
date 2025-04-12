using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Team3.ModelViews;



namespace Team3.Views
{
    public partial class TreatmentView : Page
    {
        private readonly ITreatmentModelView _treatmentModelView;
        public TreatmentView()
        {
            InitializeComponent();
            _treatmentModelView = new TreatmentModelView();
        }
        private async void AddTreatmentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                int medicarecordId = int.Parse(txtMedicalrecordId.Text);
                //_treatmentModelView.addTreatmentButtonHandler(id, medicarecordId);
                await ShowDialog("Treatment added successfully!", "Success");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding review: {ex.Message}");
                await ShowDialog("Invalid input. Please check your entries.", "Error");
            }
        }
        private async Task ShowDialog(string message, string title)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot // Required in WinUI 3
            };

            await dialog.ShowAsync();
        }

        private void NavigateToMainPage_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(MainPage)); // Navigate to ReviewView
        }
    }
}
