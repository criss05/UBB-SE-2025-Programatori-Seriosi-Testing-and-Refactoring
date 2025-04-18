using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using Team3.Models;
using Team3.Service.Implementations;
using Team3.Repository.Interfaces;
using Team3.Service.Interfaces;
using Team3.Services.Interfaces;
using Team3.ModelViews.Interfaces;

namespace Team3.Tests
{
    public class NotificationServiceTests
    {
        private readonly Mock<INotificationRepository> notificationRepoMock = new();
        private readonly Mock<IAppointmentService> appointmentServiceMock = new();
        private readonly Mock<IDoctorService> doctorServiceMock = new();
        private readonly Mock<IUserService> userServiceMock = new();
        private readonly Mock<IPatientService> patientServiceMock = new();
        private readonly Mock<IMedicalRecordService> medicalRecordServiceMock = new();
        private readonly Mock<IDrugService> drugServiceMock = new();
        private readonly Mock<ITreatmentDrugService> treatmentDrugServiceMock = new();
        private readonly Mock<ITreatmentService> treatmentServiceMock = new();
        private readonly Mock<IReviewService> reviewServiceMock = new();

        private readonly NotificationService notificationService;

        public NotificationServiceTests()
        {
            notificationService = new NotificationService(
                notificationRepoMock.Object,
                appointmentServiceMock.Object,
                doctorServiceMock.Object,
                userServiceMock.Object,
                patientServiceMock.Object,
                medicalRecordServiceMock.Object,
                drugServiceMock.Object,
                treatmentDrugServiceMock.Object,
                treatmentServiceMock.Object,
                reviewServiceMock.Object
            );
        }

        [Fact]
        public void AddNotification_ShouldCallRepository()
        {
            // Arrange
            var notification = new Notification(0, 1, DateTime.Now, "Test message");
            notificationRepoMock.Setup(r => r.AddNotification(notification)).Returns(1);

            // Act
            var result = notificationService.AddNotification(notification);

            // Assert
            Assert.Equal(1, result);
            notificationRepoMock.Verify(r => r.AddNotification(notification), Times.Once);
        }

        [Fact]
        public void GetNotificationById_ShouldReturnCorrectNotification()
        {
            // Arrange
            var expected = new Notification(5, 2, DateTime.Now, "Reminder");
            notificationRepoMock.Setup(r => r.GetNotificationById(5)).Returns(expected);

            // Act
            var result = notificationService.GetNotificationById(5);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeleteNotification_ShouldCallRepository()
        {
            // Arrange
            int userId = 3;

            // Act
            notificationService.DeleteNotification(userId);

            // Assert
            notificationRepoMock.Verify(r => r.DeleteNotification(userId), Times.Once);
        }

        [Fact]
        public void GetUpcomingAppointmentNotificationMessage_ShouldFormatCorrectly()
        {
            // Arrange
            var date = "2025-04-18 10:00";
            var doctor = "Smith";
            var location = "Room 101";

            // Act
            var message = notificationService.GetUpcomingAppointmentNotificationMessage(date, doctor, location);

            // Assert
            Assert.Contains(date, message);
            Assert.Contains(doctor, message);
            Assert.Contains(location, message);
        }

        [Fact]
        public void GetReviewNotificationMessage_ShouldIncludeAllData()
        {
            // Arrange
            var doctor = "John";
            var message = "Great experience!";
            var stars = 5;

            // Act
            var result = notificationService.GetReviewNotificationMessage(doctor, message, stars);

            // Assert
            Assert.Contains(doctor, result);
            Assert.Contains(message, result);
            Assert.Contains("5", result);
        }
    }
}
