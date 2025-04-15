// <copyright file="AppointmentModelViewTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Team3.DatabaseServices.Interfaces;
using Team3.DatabaseServices.Implementations;
using Team3.Models;
using Xunit;
using System.Reflection;

namespace Team3.Tests.ModelViewsTests
{
    public class AppointmentModelViewTests
    {
        private readonly Mock<IAppointmentDatabaseService> mockDatabaseService;

        public AppointmentModelViewTests()
        {
            this.mockDatabaseService = new Mock<IAppointmentDatabaseService>();

            // Replace the singleton instance with our mock using reflection
            typeof(AppointmentDatabaseService)
                .GetField("instance", BindingFlags.Static | BindingFlags.NonPublic)
                ?.SetValue(null, this.mockDatabaseService.Object);
        }

        [Fact]
        public void AddNewAppointment_WhenCalled_ShouldCallDatabaseServiceWithSameAppointment()
        {
            // Arrange
            var mockDatabaseService = new Mock<IAppointmentDatabaseService>();
            var viewModel = new AppointmentModelView(mockDatabaseService.Object);

            var appointment = new Appointment(
                doctorId: 1,
                patientId: 2,
                appointmentDateTime: new DateTime(2025, 5, 1, 14, 30, 0),
                location: "Room A"
            );

            // Act
            viewModel.AddNewAppointment(appointment);

            // Assert
            mockDatabaseService.Verify(s => s.AddNewAppointment(appointment), Times.Once);
        }

        [Fact]
        public void GetAppointmentById_WhenCalledWithValidId_ShouldReturnAppointmentFromDatabase()
        {
            // Arrange
            var expectedAppointment = new Appointment(
                doctorId: 1,
                patientId: 2,
                appointmentDateTime: new DateTime(2025, 5, 1, 14, 30, 0),
                location: "Room A"
            );

            var mockDatabaseService = new Mock<IAppointmentDatabaseService>();
            mockDatabaseService
                .Setup(s => s.GetAppointmentById(1))
                .Returns(expectedAppointment);

            var viewModel = new AppointmentModelView(mockDatabaseService.Object);

            // Act
            var result = viewModel.GetAppointmentById(1);

            // Assert
            Assert.Equal(expectedAppointment, result);
        }

    }
}
