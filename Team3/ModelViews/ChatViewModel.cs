using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.ModelViews
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using Team3.Models;
    using Team3.DBServices;
    internal class ChatViewModel: IChatModelView
    {
        public int userID { get; set; }
        private readonly ChatDBService chatModel;
        public ObservableCollection<Chat> Chats { get; private set; }

        public ChatViewModel()
        {
            Chats = new ObservableCollection<Chat>();
            LoadAllChats();
        }

        public void LoadAllChats()
        {
            try
            {
                var chatList = ChatDatabaseService.Instance.getChatsByUserId(userID);
                if (chatList != null && chatList.Any())
                {
                    foreach (var chat in chatList)
                    {
                        Debug.WriteLine(chat.ToString());
                        Chats.Add(chat);
                    }
                }
                else
                {
                    Debug.WriteLine("No chats returned.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Dictionary<Chat, string> GetChatsById(int id)
        {
            List<Chat> chats = ChatDatabaseService.Instance.getChatsByUserId(id);
            Dictionary<Chat, string> chatDict = new Dictionary<Chat, string>();
            foreach (Chat chat in chats)
            {
                chatDict.Add(chat, chat.ChatID.ToString());
            }
            return chatDict;
        }

        public void AddNewChat(Chat chat)
        {
            ChatDatabaseService.Instance.addNewChat(chat.user1, chat.user2);
            Chats.Add(chat);
        }

        public void setUserId(int id)
        {
            userID = id;
        }

        public List<Chat> GetChatsByName(string name)
        {
            List<Chat> chats = ChatDatabaseService.Instance.getChatsByUserId(userID);
            return chats.Where(chat => chat.user1.ToString().Contains(name) || chat.user2.ToString().Contains(name)).ToList();
        }

        public void BackButtonHandler()
        {
            Debug.WriteLine("Back button clicked in Chats");
        }

        public void SearchButtonHandler(string SearchQuery)
        {
            Debug.WriteLine("Search button clicked in Chats");
            GetChatsByName(SearchQuery);
        }
    }
}
