using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team3.ModelViews
{
    public interface IMessageModelView
    {
        /// <summary>
        /// Loads the messages for a specific chat.
        /// </summary>
        /// <param name="chatId"></param>
        public void LoadAllMessages(int chatId);

        /// <summary>
        /// Handles the send button click event.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="chatId"></param>
        /// <param name="msg"></param>
        public void SendButtonHandler(int userId, int chatId, string msg);
    }
}
