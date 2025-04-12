using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.ModelViews
{
    public interface IChatModelView
    {

        /// <summary>
        /// get all chats
        /// </summary>
        public void LoadChats();

        /// <summary>
        /// get chat from a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dictionary<Chat, string> GetChats(int id);

        /// <summary>
        /// add a chat between 2 users
        /// </summary>
        /// <param name="chat"></param>
        public void AddChat(Chat chat);

        /// <summary>
        /// update the user's id
        /// </summary>
        /// <param name="id"></param>
        public void setUserId(int id);

        /// <summary>
        /// get chats by user's name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Chat> GetChatsByName(string name);


        /// <summary>
        /// hadling the back action
        /// </summary>
        public void BackButtonHandler();

        /// <summary>
        /// handling the search action
        /// </summary>
        /// <param name="SearchQuery"></param>
        public void SearchButtonHandler(string SearchQuery);
    }
}
