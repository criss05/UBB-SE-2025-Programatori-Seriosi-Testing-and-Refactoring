using System.Collections.Generic;
using System.Linq;
using Moq;
using Team3.Models;
using Team3.Service.Implementations;
using Team3.Repository.Interfaces;
using Xunit;

namespace Team3.Tests
{
    public class ChatServiceTests
    {
        private readonly Mock<IChatRepository> mockChatRepository;
        private readonly ChatService chatService;

        public ChatServiceTests()
        {
            mockChatRepository = new Mock<IChatRepository>();
            chatService = new ChatService(mockChatRepository.Object);
        }

        [Fact]
        public void GetChatsByUserId_ShouldReturnChats_ForGivenUserId()
        {
            // Arrange
            int userId = 1;
            var expectedChats = new List<Chat>
            {
                new Chat(1, userId, 2),
                new Chat(2, userId, 3)
            };
            mockChatRepository.Setup(repo => repo.GetChatsByUserId(userId)).Returns(expectedChats);

            // Act
            var result = chatService.GetChatsByUserId(userId);

            // Assert
            Assert.Equal(expectedChats.Count, result.Count);
            Assert.Equal(expectedChats, result);
        }

        [Fact]
        public void AddNewChat_ShouldCallRepository()
        {
            // Arrange
            var chat = new Chat(1, 1, 2);

            // Act
            chatService.AddNewChat(chat);

            // Assert
            mockChatRepository.Verify(repo => repo.AddNewChat(chat.User1, chat.User2), Times.Once);
        }

        [Fact]
        public void GetChatsByName_ShouldReturnFilteredChats()
        {
            // Arrange
            int userId = 1;
            chatService.UserID = userId;

            var chats = new List<Chat>
            {
                new Chat(1, userId, 2024),
                new Chat(2, userId, 3033),
                new Chat(3, userId, 4044)
            };

            mockChatRepository.Setup(repo => repo.GetChatsByUserId(userId)).Returns(chats);

            // Act
            var result = chatService.GetChatsByName("2024");

            // Assert
            Assert.Single(result);
            Assert.Equal(2024, result.First().User2);
        }
    }
}
