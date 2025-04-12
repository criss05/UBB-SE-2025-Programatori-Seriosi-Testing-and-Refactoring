using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;
using Team3.DatabaseServices;
using Windows.Services.Maps;
using Team3.DTOs;

namespace Team3.ModelViews
{
    public class MessageModelView : IMessageModelView
    {

        private readonly IMessageDBService messageModel;
        private readonly IUserModelView userModelView;

        public ObservableCollection<MessageChatDTO> Messages { get; set; }
        public MessageModelView()
        {
            Debug.WriteLine("MessageModelView created");
            messageModel = MessageDatabaseService.Instance;
            userModelView = new UserModelView(); 
            Messages = new ObservableCollection<MessageChatDTO>();
        }

        public void LoadAllMessages(int chatId)
        {
            List<Message> messages = messageModel.GetMessagesByChatId(chatId);
            Debug.WriteLine(messages.Count + "Messages loaded");
            Messages.Clear();
            messages.Sort((x,y) =>  x.sentDateTime.CompareTo(y.sentDateTime));
            foreach (Message message in messages)
            {
                User user = userModelView.GetUserById(message.UserId);
                Messages.Add(new MessageChatDTO(message.Id, message.Content, message.UserId, message.ChatId, message.sentDateTime, user.Name));
            }
        }
        public void SendButtonHandler(int userId,int chatId, string msg)
        {
            Debug.WriteLine("Send button clicked");
            DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Config.ROMANIA_TIMEZONE);
            //Message newMessage = new Message(message, userId, chatId, currentDateTime);
            //MessageChatDTO messageChatDTO = new MessageChatDTO(newMessage.Id ,message, userId, chatId, currentDateTime, userModelView.GetUser(userId).ToString());
            LoadAllMessages(chatId);
        }
    }
}
