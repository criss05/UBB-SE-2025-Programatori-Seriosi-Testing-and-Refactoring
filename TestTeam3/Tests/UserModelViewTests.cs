using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class UserModelViewTests
    {
        private readonly Mock<IUserDatabaseService> mockUserDbService;
        private readonly UserModelView userModelView;

        public UserModelViewTests()
        {
            mockUserDbService = new Mock<IUserDatabaseService>();
            mockUserDbService.Setup(s => s.GetAllUsers()).Returns(new List<User>());
            userModelView = new UserModelView(mockUserDbService.Object);
        }

        [Fact]
        public void GetAllUsers_ReturnsAllUsersFromDatabase()
        {
            var users = new List<User>
    {
        new User(1, "Alice", "Admin"),
        new User(2, "Bob", "Doctor")
    };

            var mock = new Mock<IUserDatabaseService>();
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
            mockUserDbService.Setup(s => s.GetUserById(1)).Returns(user);

            var result = userModelView.GetUserById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Alice", result.Name);
            Assert.Equal("Admin", result.Role);
            mockUserDbService.Verify(s => s.GetUserById(1), Times.Once);
        }

        [Fact]
        public void GetUserById_NonExistingId_ReturnsNull()
        {
            mockUserDbService.Setup(s => s.GetUserById(99)).Returns((User)null);

            var result = userModelView.GetUserById(99);

            Assert.Null(result);
            mockUserDbService.Verify(s => s.GetUserById(99), Times.Once);
        }

        [Fact]
        public void Constructor_LoadsAllUsersIntoObservableCollection()
        {
            var users = new List<User>
            {
                new User(1, "Alice", "Admin"),
                new User(2, "Bob", "Doctor")
            };
            mockUserDbService.Setup(s => s.GetAllUsers()).Returns(users);

            var modelView = new UserModelView(mockUserDbService.Object);

            Assert.Equal(2, modelView.Users.Count);
            Assert.Contains(modelView.Users, u => u.Name == "Alice");
            Assert.Contains(modelView.Users, u => u.Name == "Bob");
        }

        [Fact]
        public void Constructor_WhenDatabaseThrows_ExceptionIsHandledAndNoUsersAdded()
        {
            mockUserDbService.Setup(s => s.GetAllUsers()).Throws(new Exception("Database error"));

            var modelView = new UserModelView(mockUserDbService.Object);

            Assert.Empty(modelView.Users);
        }
    }
}
