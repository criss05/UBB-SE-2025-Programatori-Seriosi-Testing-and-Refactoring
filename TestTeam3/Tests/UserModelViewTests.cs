using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.Service.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class UserModelViewTests
    {
        private readonly Mock<IUserService> mockUserService;
        private readonly UserModelView userModelView;

        public UserModelViewTests()
        {
            mockUserService = new Mock<IUserService>();
            mockUserService.Setup(s => s.GetAllUsers()).Returns(new List<User>());
            userModelView = new UserModelView(mockUserService.Object);
        }

        [Fact]
        public void GetAllUsers_ReturnsAllUsersFromDatabase()
        {
            var users = new List<User>
    {
        new User(1, "Alice", "Admin"),
        new User(2, "Bob", "Doctor")
    };

            var mock = new Mock<IUserService>();
            mock.Setup(s => s.GetAllUsers()).Returns(users);

            var modelView = new UserModelView(mock.Object);

            var result = modelView.GetAllUsers();

            Assert.Equal(2, result.Count);
            mock.Verify(s => s.GetAllUsers(), Times.Exactly(2)); 
        }






        [Fact]
        public void GetUserById_ExistingId_ReturnsUser()
        {
            var user = new User(1, "Alice", "Admin");
            mockUserService.Setup(s => s.GetUserById(1)).Returns(user);

            var result = userModelView.GetUserById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Alice", result.Name);
            Assert.Equal("Admin", result.Role);
            mockUserService.Verify(s => s.GetUserById(1), Times.Once);
        }

        [Fact]
        public void GetUserById_NonExistingId_ReturnsNull()
        {
            mockUserService.Setup(s => s.GetUserById(99)).Returns((User)null);

            var result = userModelView.GetUserById(99);

            Assert.Null(result);
            mockUserService.Verify(s => s.GetUserById(99), Times.Once);
        }

        [Fact]
        public void Constructor_LoadsAllUsersIntoObservableCollection()
        {
            var users = new List<User>
            {
                new User(1, "Alice", "Admin"),
                new User(2, "Bob", "Doctor")
            };
            mockUserService.Setup(s => s.GetAllUsers()).Returns(users);

            var modelView = new UserModelView(mockUserService.Object);

            Assert.Equal(2, modelView.Users.Count);
            Assert.Contains(modelView.Users, u => u.Name == "Alice");
            Assert.Contains(modelView.Users, u => u.Name == "Bob");
        }

        [Fact]
        public void Constructor_WhenDatabaseThrows_ExceptionIsHandledAndNoUsersAdded()
        {
            mockUserService.Setup(s => s.GetAllUsers()).Throws(new Exception("Database error"));

            var modelView = new UserModelView(mockUserService.Object);

            Assert.Empty(modelView.Users);
        }
    }
}
