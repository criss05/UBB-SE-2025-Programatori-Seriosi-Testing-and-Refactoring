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
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Team3.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MessageView : Page
    {
        public IMessageModelView ViewModel { get; } = new MessageModelView();
        public int UserId { get; set; }
        public int ChatId { get; set; }



        public MessageView()
        {
            this.InitializeComponent();
            this.chatMessages.DataContext = ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is (int userId, int chatId))
            {
                UserId = userId;
                ChatId = chatId;
                ViewModel.LoadAllMessages(userId);
                // In a real app, you might filter notifications by user
                Debug.WriteLine($"Loading notifications for user: ID={userId}");
            }
        }

        private
        void BackClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChatView));
        }

        private void sendButtonClicked(object sender, RoutedEventArgs e)
        {
            string message = messageBar.Text;
            ViewModel.SendButtonHandler(UserId, ChatId, message);
            messageBar.PlaceholderText = "Type a message...";
        }

    }
}
