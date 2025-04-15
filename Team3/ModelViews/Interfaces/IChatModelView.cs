// <copyright file="IChatModelView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Team3.ModelViews.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Team3.Models;

    public interface IChatModelView
    {
        void LoadAllChats();
        Dictionary<Chat, string> GetChatsByUserId(int id);
        void AddNewChat(Chat chat);
        void SetUserId(int id);
        List<Chat> GetChatsByName(string name);
        void BackButtonHandler();
        void SearchButtonHandler(string searchQuery);
    }
}
