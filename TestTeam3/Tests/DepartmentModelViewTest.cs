using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Team3.ModelViews.Implementations;
using Team3.Repository.Interfaces;
using Team3.Models;

namespace Team3.Tests.ModelViewsTests
{
    public class DepartmentModelViewTests
    {
        private readonly Mock<IDepartmentDatabaseService> mockService;
        private readonly DepartmentModelView viewModel;

        public DepartmentModelViewTests()
        {
            mockService = new Mock<IDepartmentDatabaseService>();
            mockService.Setup(service => service.GetDepartments()).Returns(GetSampleDepartments());

            viewModel = new DepartmentModelView(mockService.Object);
        }

        private List<Department> GetSampleDepartments()
        {
            return new List<Department>
            {
                new Department(1, "Cardiology"),
                new Department(2, "Neurology"),
                new Department(3, "Pediatrics")
            };
        }

        [Fact]
        public void LoadDepartmentsInfo_ShouldLoadDepartmentsIntoCollection()
        {
            // Act
            viewModel.LoadDepartmentsInfo();

            // Assert
            Assert.Equal(3, viewModel.DepartmentsInfo.Count);
        }

        [Fact]
        public void GetDepartmentsByName_ShouldReturnMatchingDepartments()
        {
            // Act
            var result = viewModel.GetDepartmentsByName("Neuro");

            // Assert
            Assert.Single(result);
            Assert.Equal("Neurology", result[0].DepartmentName);
        }

        [Fact]
        public void GetDepartmentsByName_ShouldReturnEmptyListForNoMatches()
        {
            // Act
            var result = viewModel.GetDepartmentsByName("Orthopedics");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void BackButtonHandler_ShouldTriggerOnBackNavigation()
        {
            // Arrange
            bool triggered = false;
            viewModel.OnBackNavigation = () => triggered = true;

            // Act
            viewModel.BackButtonHandler();

            // Assert
            Assert.True(triggered);
        }

        [Fact]
        public void DateSelectedComboBoxHandler_ShouldCallLoadDepartmentsInfo()
        {
            // This test ensures no exceptions and that departments are refreshed
            viewModel.DateSelectedComboBoxHandler(DateOnly.FromDateTime(DateTime.Now));

            Assert.Equal(3, viewModel.DepartmentsInfo.Count);
        }
    }
}
