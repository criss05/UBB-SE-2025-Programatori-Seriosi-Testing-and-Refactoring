using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Team3.ModelViews;
using Team3.Models;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Team3.Views
{
    public partial class ReviewView : Page
    {
        private readonly IReviewModelView _reviewModelView;

        public ReviewView()
        {
            InitializeComponent();
            _reviewModelView = new ReviewModelView();
        }

        private async void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {   
                int id = int.Parse(txtId.Text);
                int medicarecordId = int.Parse(txtMedicalrecordId.Text);
                string message = txtMessage.Text;
                int stars = int.Parse(((ComboBoxItem)cmbStars.SelectedItem).Content.ToString());

                _reviewModelView.addReviewButtonHandler(id,medicarecordId, message, stars);

                await ShowDialog("Review added successfully!", "Success");
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

