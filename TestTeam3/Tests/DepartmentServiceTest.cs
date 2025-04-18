using Moq;
using System;
using System.Collections.Generic;
using Team3.Models;
using Team3.Repository.Interfaces;
using Team3.Service.Implementations;
using Xunit;

namespace Team3.Tests
{
    public class DepartmentServiceTests
    {
        private readonly Mock<IDepartmentRepository> departmentRepositoryMock;
        private readonly DepartmentService departmentService;

        public DepartmentServiceTests()
        {
            this.departmentRepositoryMock = new Mock<IDepartmentRepository>();
            this.departmentService = new DepartmentService(departmentRepositoryMock.Object);
        }

        [Fact]
        public void GetDepartments_ShouldReturnAllDepartments()
        {
            // Arrange
            var expectedDepartments = new List<Department>
            {
                new Department(1, "Cardiology"),
                new Department(2, "Neurology")
            };

            departmentRepositoryMock
                .Setup(repo => repo.GetDepartments())
                .Returns(expectedDepartments);

            // Act
            var result = departmentService.GetDepartments();

            // Assert
            Assert.Equal(expectedDepartments.Count, result.Count);
            Assert.Equal(expectedDepartments, result);
        }

        [Fact]
        public void GetDepartmentsByName_WhenMatchesExist_ShouldReturnFilteredDepartments()
        {
            // Arrange
            var allDepartments = new List<Department>
            {
                new Department(1, "Cardiology"),
                new Department(2, "Neurology"),
                new Department(3, "Pediatrics")
            };

            departmentRepositoryMock
                .Setup(repo => repo.GetDepartments())
                .Returns(allDepartments);

            // Act
            var result = departmentService.GetDepartmentsByName("Neuro");

            // Assert
            Assert.Single(result);
            Assert.Equal("Neurology", result[0].DepartmentName);
        }

        [Fact]
        public void GetDepartmentsByName_WhenNoMatchFound_ShouldThrowException()
        {
            // Arrange
            var departments = new List<Department>
            {
                new Department(1, "Cardiology"),
                new Department(2, "Pediatrics")
            };

            departmentRepositoryMock
                .Setup(repo => repo.GetDepartments())
                .Returns(departments);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() =>
                departmentService.GetDepartmentsByName("Dermatology"));

            Assert.Equal("No departments found with the name 'Dermatology'.", exception.Message);
        }

        [Fact]
        public void GetDepartmentsByName_WhenDepartmentNameIsNull_ShouldNotThrow()
        {
            // Arrange
            var departments = new List<Department>
            {
                new Department(1, null),
                new Department(2, "Surgery")
            };

            departmentRepositoryMock
                .Setup(repo => repo.GetDepartments())
                .Returns(departments);

            // Act
            var result = departmentService.GetDepartmentsByName("Surgery");

            // Assert
            Assert.Single(result);
            Assert.Equal("Surgery", result[0].DepartmentName);
        }
    }
}
