using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DatabaseServices
{
    public interface IMessageDatabaseService
    {

        /// <summary>
        /// Get messages from a chat using the id
        /// </summary>
        /// <param name="chatId"></param>
        /// <returns></returns>
        public List<Message> GetMessagesByChatId(int chatId);

        /// <summary>
        /// add a message 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int addMessage(Message message);
    }
}
