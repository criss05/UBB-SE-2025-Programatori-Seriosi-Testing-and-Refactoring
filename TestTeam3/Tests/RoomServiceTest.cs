using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Repository.Interfaces;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Xunit;
using Team3.Models;
using Team3.Service.Implementations;
using Team3.Service.Interfaces;

namespace Team3.Tests
{
    public class RoomServiceTest
    {
        private readonly Mock<IRoomRepository> mockRepository;
        private readonly IRoomService roomService;

        public RoomServiceTest()
        {
            this.mockRepository = new Mock<IRoomRepository>();
            this.roomService = new RoomService(this.mockRepository.Object);
        }

        [Fact]
        public void AddNewRoom_WhenCalled_ShouldCallDatabaseServiceWithSameRoom()
        {
            // Arrange
            var room = new Room(
                id: 1,
                departmentId: 1
            );

            // Act
            this.roomService.AddRoom(room);

            // Assert
            this.mockRepository.Verify(s => s.AddRoom(room), Times.Once);
        }

        [Fact]
        public void GetRoomById_WhenCalledWithValidId_ShouldReturRoomFromDatabase()
        {
            // Arrange
            var expectedRoom = new Room(
                id: 1,
                departmentId: 1
            );


            this.mockRepository
                .Setup(s => s.GetRoom(1))
                .Returns(expectedRoom);

            // Act
            var result = this.roomService.GetRoom(1);

            // Assert
            Assert.Equal(expectedRoom, result);
        }
    }
}
