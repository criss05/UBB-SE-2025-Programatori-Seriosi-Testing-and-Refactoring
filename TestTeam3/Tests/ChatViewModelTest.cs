using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using Team3.Models;
using Team3.DatabaseServices.Interfaces;
using Team3.ModelViews.Implementations;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class ChatViewModelTests
    {
        private readonly Mock<IChatDatabaseService> mockDbService;
        private readonly ChatViewModel viewModel;

        public ChatViewModelTests()
        {
            mockDbService = new Mock<IChatDatabaseService>();
            viewModel = new ChatViewModel(mockDbService.Object);
        }

        [Fact]
        public void LoadAllChats_ShouldLoadChats_WhenChatsExist()
        {
            // Arrange
            int userId = 1;
            var expectedChats = new List<Chat>
        {
            new Chat(1, userId, 2),
            new Chat(2, userId, 3)
        };
            mockDbService.Setup(s => s.GetChatsByUserId(userId)).Returns(expectedChats);
            viewModel.SetUserId(userId);

            // Act
            viewModel.LoadAllChats();

            // Assert
            Assert.Equal(expectedChats.Count, viewModel.Chats.Count);
        }

        [Fact]
        public void AddNewChat_ShouldCallDatabaseAndAddToList()
        {
            // Arrange
            var chat = new Chat(1, 1, 2);

            // Act
            viewModel.AddNewChat(chat);

            // Assert
            mockDbService.Verify(s => s.AddNewChat(chat.User1, chat.User2), Times.Once);
            Assert.Contains(chat, viewModel.Chats);
        }

        [Fact]
        public void GetChatsByUserId_ShouldReturnDictionary()
        {
            // Arrange
            int userId = 1;
            var chats = new List<Chat>
        {
            new Chat(1, userId, 2),
            new Chat(2, userId, 3)
        };

            mockDbService.Setup(s => s.GetChatsByUserId(userId)).Returns(chats);

            // Act
            var result = viewModel.GetChatsByUserId(userId);

            // Assert
            Assert.Equal(chats.Count, result.Count);
            Assert.Contains(chats[0], result.Keys);
        }

        [Fact]
        public void GetChatsByName_ShouldReturnMatchingChats()
        {
            // Arrange
            int userId = 1;
            viewModel.SetUserId(userId);
            var chats = new List<Chat>
        {
            new Chat(1, userId, 2024),
            new Chat(2, userId, 3033)
        };

            mockDbService.Setup(s => s.GetChatsByUserId(userId)).Returns(chats);

            // Act
            var result = viewModel.GetChatsByName("2024");

            // Assert
            Assert.Single(result);
        }
    }
}