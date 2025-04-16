using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DatabaseServices.Interfaces;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Xunit;
using Team3.Models;

namespace Team3.Tests.ModelViewsTests
{
    public class RoomModelViewTest
    {
        private readonly Mock<IRoomDatabaseService> mockDatabaseService;
        private readonly IRoomModelView roomModelView;

        public RoomModelViewTest()
        {
            this.mockDatabaseService = new Mock<IRoomDatabaseService>();
            this.roomModelView = new RoomModelView(this.mockDatabaseService.Object);
        }

        [Fact]
        public void AddNewRoom_WhenCalled_ShouldCallDatabaseServiceWithSameRoom()
        {
            // Arrange
            var room = new Room(
                departmentId: 1
            );

            // Act
            this.roomModelView.AddRoom(room);

            // Assert
            this.mockDatabaseService.Verify(s => s.AddRoom(room), Times.Once);
        }

        [Fact]
        public void GetRoomById_WhenCalledWithValidId_ShouldReturRoomFromDatabase()
        {
            // Arrange
            var expectedRoom = new Room(
                departmentId: 1
            );


            this.mockDatabaseService
                .Setup(s => s.GetRoom(1))
                .Returns(expectedRoom);

            // Act
            var result = this.roomModelView.GetRoom(1);

            // Assert
            Assert.Equal(expectedRoom, result);
        }
    }
}
