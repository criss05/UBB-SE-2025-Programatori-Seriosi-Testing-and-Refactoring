using Xunit;
using Moq;
using System.Collections.Generic;
using Team3.Models;
using Team3.Service.Implementations;
using Team3.Repository.Interfaces;

namespace Team3.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> userRepositoryMock;
        private readonly UserService userService;

        public UserServiceTests()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            userService = new UserService(userRepositoryMock.Object);
        }

        [Fact]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User(1, "Alice", "patient"),
                new User(2, "Bob", "doctor")
            };

            userRepositoryMock.Setup(repo => repo.GetAllUsers()).Returns(users);

            // Act
            var result = userService.GetAllUsers();

            // Assert
            Assert.Equal(users.Count, result.Count);
            Assert.Equal("Alice", result[0].Name);
            Assert.Equal("Bob", result[1].Name);
            userRepositoryMock.Verify(repo => repo.GetAllUsers(), Times.Once);
        }

        [Fact]
        public void GetUserById_ShouldReturnCorrectUser()
        {
            // Arrange
            var user = new User(1, "Alice", "admin");
            userRepositoryMock.Setup(repo => repo.GetUserById(1)).Returns(user);

            // Act
            var result = userService.GetUserById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Alice", result.Name);
            userRepositoryMock.Verify(repo => repo.GetUserById(1), Times.Once);
        }
    }
}
