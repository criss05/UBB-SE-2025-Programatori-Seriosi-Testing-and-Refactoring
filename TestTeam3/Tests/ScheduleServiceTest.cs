using System;
using System.Collections.Generic;
using Moq;
using Team3.Service.Implementations;
using Team3.Repository.Interfaces;
using Team3.Models;
using Xunit;
using Team3.Service.Implementations;

namespace Team3.Tests
{
    public class ScheduleServiceTests
    {
        private readonly Mock<IScheduleRepository> mockScheduleRepository;
        private readonly ScheduleService scheduleService;

        public ScheduleServiceTests()
        {
            this.mockScheduleRepository = new Mock<IScheduleRepository>();
            this.scheduleService = new ScheduleService(this.mockScheduleRepository.Object);
        }

        [Fact]
        public void GetSchedulesByDoctorId_WhenCalledWithValidDoctorIdAndDateRange_ShouldReturnFilteredSchedules()
        {
            // Arrange
            int doctorId = 10;
            int otherDoctorId = 11;
            int year = 2025;
            int month = 4;

            var schedules = new List<Schedule>
            {
                new Schedule(1, new DateOnly(year, month, 15), doctorId, 1),
                new Schedule(2, new DateOnly(year, month, 16), doctorId, 2),
                new Schedule(3, new DateOnly(year, month, 18), otherDoctorId, 1),
                new Schedule(4, new DateOnly(year, month, 17), doctorId, 1)
            };

            this.mockScheduleRepository
                .Setup(s => s.GetAllSchedules())
                .Returns(schedules);

            var startDate = new DateOnly(year, month, 15);
            var endDate = new DateOnly(year, month, 17);

            // Act
            var result = this.scheduleService.GetSchedulesByDoctorId(doctorId, startDate, endDate);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.All(result, s => Assert.Equal(doctorId, s.DoctorId));
            Assert.Contains(result, s => s.Id == 1);
            Assert.Contains(result, s => s.Id == 2);
            Assert.Contains(result, s => s.Id == 4);
        }

        [Fact]
        public void GetSchedulesByDoctorId_WhenNoSchedulesMatch_ShouldReturnEmptyList()
        {
            // Arrange
            int doctorId = 10;
            int unrelatedDoctorId1 = 11;
            int unrelatedDoctorId2 = 12;
            int year = 2025;
            int month = 4;

            var schedules = new List<Schedule>
            {
                new Schedule(1, new DateOnly(year, month, 15), unrelatedDoctorId1, 1),
                new Schedule(2, new DateOnly(year, month, 16), unrelatedDoctorId2, 2)
            };

            this.mockScheduleRepository
                .Setup(s => s.GetAllSchedules())
                .Returns(schedules);

            var startDate = new DateOnly(year, month, 15);
            var endDate = new DateOnly(year, month, 17);

            // Act
            var result = this.scheduleService.GetSchedulesByDoctorId(doctorId, startDate, endDate);

            // Assert
            Assert.Empty(result);
        }
    }
}
