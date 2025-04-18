using System;
using System.Collections.Generic;
using Moq;
using Xunit;
using Team3.Models;
using Team3.Repository.Interfaces;
using Team3.Services.Implementations;
using Team3.Services.Interfaces;

namespace Team3.Tests
{
    public class MessageServiceTests
    {
        private readonly Mock<IMessageRepository> mockMessageRepository;
        private readonly IMessageService messageService;

        public MessageServiceTests()
        {
            this.mockMessageRepository = new Mock<IMessageRepository>();
            this.messageService = new MessageService(this.mockMessageRepository.Object);
        }

        [Fact]
        public void AddMessage_WhenCalled_ShouldInvokeRepositoryWithMessage()
        {
            // Arrange
            var message = new Message(
                id: 1,
                content: "Hello, World!",
                userId: 1,
                chatId: 2,
                sentDateTime: new DateTime(2025, 5, 1, 14, 30, 0)
            );

            this.mockMessageRepository
                .Setup(repo => repo.AddMessage(message))
                .Returns(1);

            // Act
            var result = this.messageService.AddMessage(message);

            // Assert
            Assert.Equal(1, result);
            this.mockMessageRepository.Verify(repo => repo.AddMessage(message), Times.Once);
        }

        [Fact]
        public void GetMessageById_WithValidId_ShouldReturnMessage()
        {
            // Arrange
            var expectedMessage = new Message(
                id: 1,
                content: "Test message",
                userId: 1,
                chatId: 2,
                sentDateTime: DateTime.Now
            );

            this.mockMessageRepository
                .Setup(repo => repo.GetMessageById(1))
                .Returns(expectedMessage);

            // Act
            var result = this.messageService.GetMessageById(1);

            // Assert
            Assert.Equal(expectedMessage, result);
            this.mockMessageRepository.Verify(repo => repo.GetMessageById(1), Times.Once);
        }

        [Fact]
        public void GetMessagesByChatId_WithUnsortedMessages_ShouldReturnSortedMessages()
        {
            // Arrange
            var unsortedMessages = new List<Message>
            {
                new Message(3, "Third", 1, 1, new DateTime(2025, 5, 1, 14, 40, 0)),
                new Message(1, "First", 1, 1, new DateTime(2025, 5, 1, 14, 20, 0)),
                new Message(2, "Second", 1, 1, new DateTime(2025, 5, 1, 14, 30, 0))
            };

            this.mockMessageRepository
                .Setup(repo => repo.GetMessagesByChatId(1))
                .Returns(unsortedMessages);

            // Act
            var result = this.messageService.GetMessagesByChatId(1);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("First", result[0].Content);
            Assert.Equal("Second", result[1].Content);
            Assert.Equal("Third", result[2].Content);

            this.mockMessageRepository.Verify(repo => repo.GetMessagesByChatId(1), Times.Once);
        }
    }
}
