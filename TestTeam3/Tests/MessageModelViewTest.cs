using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Repository.Interfaces;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Team3.Models;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Message = Team3.Models.Message;

namespace Team3.Tests.ModelViewsTests
{
    public class MessageModelViewTest
    {
        private readonly Mock<IMessageDatabaseService> mockDatabaseService;
        private readonly IMessageModelView messageModelView;
        private readonly IUserModelView userModelView;

        public MessageModelViewTest()
        {
            this.mockDatabaseService = new Mock<IMessageDatabaseService>();
            this.userModelView = new Mock<IUserModelView>().Object;
            this.messageModelView = new MessageModelView(this.mockDatabaseService.Object, this.userModelView);
        }

        [Fact]
        public void AddNewMessage_WhenCalled_ShouldCallDatabaseServiceWithSameMessage()
        {
            // Arrange
            var messagge = new Message(
                id: 1,
                content: "Hello, World!",
                userId: 1,
                chatId: 2,
                sentDateTime: new DateTime(2025, 5, 1, 14, 30, 0)
            );

            // Act
            this.messageModelView.AddMessage(messagge);

            // Assert
            this.mockDatabaseService.Verify(s => s.addMessage(messagge), Times.Once);
        }

        [Fact]
        public void GetMessageById_WhenCalledWithValidId_ShouldReturMessageFromDatabase()
        {
            // Arrange
            var expectedMessage = new Message(
                id: 1,
                content: "Hello, World!",
                userId: 1,
                chatId: 2,
                sentDateTime: new DateTime(2025, 5, 1, 14, 30, 0)
            );

            this.mockDatabaseService
                .Setup(s => s.GetMessageById(1))
                .Returns(expectedMessage);

            // Act
            var result = this.messageModelView.GetMessageById(1);

            // Assert
            Assert.Equal(expectedMessage, result);
        }
    }
}
