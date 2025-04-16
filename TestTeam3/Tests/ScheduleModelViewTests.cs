// Copyright (c) PlaceholderCompany. All rights reserved.

using System;
using Moq;
using Team3.ModelViews;
using Team3.Models;
using Team3.DatabaseServices;
using Xunit;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Team3.Tests.ModelViewsTests
{
    public class ScheduleModelViewTests
    {
        private readonly Mock<IScheduleDatabaseService> _mockDbService;

        public ScheduleModelViewTests()
        {
            _mockDbService = new Mock<IScheduleDatabaseService>();

            // Replace singleton instance with mock
            typeof(ScheduleDatabaseService)
                .GetField("Instance", BindingFlags.Static | BindingFlags.Public)
                ?.SetValue(null, _mockDbService.Object);
        }

        [Fact]
        public void GetSchedulesByDoctorId_ValidParameters_ReturnsFilteredSchedules()
        {
            // Arrange
            var viewModel = new ScheduleModelView();
            var testDate = new DateOnly(2025, 5, 1);
            var schedules = new List<Schedule>
            {
                new(1, testDate, 101, 1),
                new(2, testDate.AddDays(1), 101, 2),
                new(3, testDate.AddDays(-1), 102, 1)
            };

            _mockDbService.Setup(s => s.GetAllSchedules()).Returns(schedules);

            // Act
            var result = viewModel.GetSchedulesByDoctorId(101, testDate, testDate.AddDays(7));

            // Assert
            Xunit.Assert.Equal(2, result.Count);
            Xunit.Assert.All(result, s => Xunit.Assert.Equal(101, s.DoctorId));
            Xunit.Assert.All(result, s => Xunit.Assert.InRange(s.ScheduleWorkDay, testDate, testDate.AddDays(7)));
        }

        [Fact]
        public void Constructor_InitializesSchedulesCollection()
        {
            // Act
            var viewModel = new ScheduleModelView();

            // Assert
            Xunit.Assert.NotNull(viewModel.Schedules);
            Xunit.Assert.IsType<ObservableCollection<Schedule>>(viewModel.Schedules);
        }

        [Fact]
        public void GetSchedulesByDoctorId_NoMatches_ReturnsEmptyList()
        {
            // Arrange
            var viewModel = new ScheduleModelView();
            _mockDbService.Setup(s => s.GetAllSchedules()).Returns(new List<Schedule>());

            // Act
            var result = viewModel.GetSchedulesByDoctorId(999, new DateOnly(2025, 1, 1), new DateOnly(2025, 12, 31));

            // Assert
            Xunit.Assert.Empty(result);
        }
    }
}
