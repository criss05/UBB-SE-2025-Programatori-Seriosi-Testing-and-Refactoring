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
    using Team3.DatabaseServices;
    internal class ChatViewModel: IChatModelView
    {
        public int userID { get; set; }
        private readonly ChatDBService chatModel;
        public ObservableCollection<Chat> Chats { get; private set; }

        public ChatViewModel()
        {
            Chats = new ObservableCollection<Chat>();

            LoadAllChats();
            chatModel = ChatDBService.Instance; 

        }

        public void LoadAllChats()
        {
            try
            {
<<<<<<< HEAD
                var chatList = ChatDatabaseService.Instance.getChatsByUserId(userID);
=======
                var chatList = chatModel.getChats(userID);
>>>>>>> main
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
<<<<<<< HEAD
            List<Chat> chats = ChatDatabaseService.Instance.getChatsByUserId(id);
=======
            List<Chat> chats = chatModel.getChats(id);
>>>>>>> main
            Dictionary<Chat, string> chatDict = new Dictionary<Chat, string>();
            foreach (Chat chat in chats)
            {
                chatDict.Add(chat, chat.ChatID.ToString());
            }
            return chatDict;
        }

        public void AddNewChat(Chat chat)
        {
<<<<<<< HEAD
            ChatDatabaseService.Instance.addNewChat(chat.user1, chat.user2);
=======
            chatModel.addChat(chat.user1, chat.user2);
>>>>>>> main
            Chats.Add(chat);
        }

        public void setUserId(int id)
        {
            userID = id;
        }

        public List<Chat> GetChatsByName(string name)
        {
<<<<<<< HEAD
            List<Chat> chats = ChatDatabaseService.Instance.getChatsByUserId(userID);
=======
            List<Chat> chats = chatModel.getChats(userID);
>>>>>>> main
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
