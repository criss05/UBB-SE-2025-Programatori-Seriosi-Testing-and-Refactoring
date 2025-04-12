﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Models;

namespace Team3.DBServices
{
    public interface IChatDBService
    {
        /// <summary>
        /// Get the user's chats from the DB by user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Chat> getChats(int user);

        /// <summary>
        /// Add a chat between user 1 and user 2
        /// </summary>
        /// <param name="user1"></param>
        /// <param name="user2"></param>
        public void addChat(int user1, int user2);
    }
}
