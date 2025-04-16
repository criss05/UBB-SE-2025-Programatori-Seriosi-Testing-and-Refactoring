using System;
using System.Collections.Generic;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class ScheduleModelViewTests
    {
        private readonly Mock<IScheduleDatabaseService> mockScheduleDatabaseService;
        private readonly IScheduleModelView scheduleModelView;

        public ScheduleModelViewTests()
        {
            this.mockScheduleDatabaseService = new Mock<IScheduleDatabaseService>();
            this.scheduleModelView = new ScheduleModelView(this.mockScheduleDatabaseService.Object);
        }

        [Fact]
        public void GetSchedulesByDoctorId_WhenCalledWithValidDoctorIdAndDateRange_ShouldReturnFilteredSchedules()
        {
            var schedules = new List<Schedule>
            {
                new Schedule(1, new DateOnly(2025, 4, 15), 10, 1),
                new Schedule(2, new DateOnly(2025, 4, 16), 10, 2),
                new Schedule(3, new DateOnly(2025, 4, 18), 11, 1), 
                new Schedule(4, new DateOnly(2025, 4, 17), 10, 1)
            };

            this.mockScheduleDatabaseService
                .Setup(s => s.GetAllSchedules())
                .Returns(schedules);

            int doctorId = 10;
            var startDate = new DateOnly(2025, 4, 15);
            var endDate = new DateOnly(2025, 4, 17);

            var result = this.scheduleModelView.GetSchedulesByDoctorId(doctorId, startDate, endDate);

            Assert.Equal(3, result.Count);
            Assert.All(result, s => Assert.Equal(doctorId, s.DoctorId));
            Assert.Contains(result, s => s.Id == 1);
            Assert.Contains(result, s => s.Id == 2);
            Assert.Contains(result, s => s.Id == 4);
        }

        [Fact]
        public void GetSchedulesByDoctorId_WhenNoSchedulesFound_ShouldReturnEmptyList()
        {
            var schedules = new List<Schedule>
            {
                new Schedule(1, new DateOnly(2025, 4, 15), 11, 1), 
                new Schedule(2, new DateOnly(2025, 4, 16), 12, 2)  
            };

            this.mockScheduleDatabaseService
                .Setup(s => s.GetAllSchedules())
                .Returns(schedules);

            int doctorId = 10;
            var startDate = new DateOnly(2025, 4, 15);
            var endDate = new DateOnly(2025, 4, 17);

            var result = this.scheduleModelView.GetSchedulesByDoctorId(doctorId, startDate, endDate);

            Assert.Empty(result);
        }
    }
}
