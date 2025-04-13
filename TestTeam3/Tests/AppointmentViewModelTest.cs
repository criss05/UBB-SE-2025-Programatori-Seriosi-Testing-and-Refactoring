// <copyright file="AppointmentModelViewTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Moq;
using Team3.ModelViews;
using Team3.Models;
using Team3.DatabaseServices;
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
            var viewModel = new AppointmentModelView(new AppointmentDatabaseService(Config.DbConnectionString));
            var appointment = new Appointment(
                id: 1,
                doctorId: 101,
                patientId: 202,
                appointmentDateTime: new DateTime(2025, 5, 1, 14, 30, 0),
                location: "Room A"
            );

            // Act
            viewModel.AddNewAppointment(appointment);

            // Assert
            this.mockDatabaseService.Verify(s => s.AddNewAppointment(appointment), Times.Once);
        }

        [Fact]
        public void GetAppointmentById_WhenCalledWithValidId_ShouldReturnAppointmentFromDatabase()
        {
            // Arrange
            var viewModel = new AppointmentModelView(new AppointmentDatabaseService(Config.DbConnectionString));
            var expectedAppointment = new Appointment(
                id: 42,
                doctorId: 999,
                patientId: 888,
                appointmentDateTime: new DateTime(2025, 6, 10, 10, 0, 0),
                location: "Clinic B"
            );

            this.mockDatabaseService
                .Setup(s => s.GetAppointmentById(42))
                .Returns(expectedAppointment);

            // Act
            var result = viewModel.GetAppointmentById(42);

            // Assert
            Xunit.Assert.Equal(expectedAppointment, result);
        }
    }
}
