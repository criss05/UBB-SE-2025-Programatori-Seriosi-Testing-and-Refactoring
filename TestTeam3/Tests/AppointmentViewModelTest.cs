using System;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class AppointmentModelViewTests
    {
        private readonly Mock<IAppointmentDatabaseService> mockDatabaseService;
        private readonly IAppointmentModelView appointmentModelView;

        public AppointmentModelViewTests()
        {
            this.mockDatabaseService = new Mock<IAppointmentDatabaseService>();
            this.appointmentModelView = new AppointmentModelView(this.mockDatabaseService.Object);
        }

        [Fact]
        public void AddNewAppointment_WhenCalled_ShouldCallDatabaseServiceWithSameAppointment()
        {
            // Arrange
            var appointment = new Appointment(
                doctorId: 1,
                patientId: 2,
                appointmentDateTime: new DateTime(2025, 5, 1, 14, 30, 0),
                location: "Room A"
            );

            // Act
            this.appointmentModelView.AddNewAppointment(appointment);

            // Assert
            this.mockDatabaseService.Verify(s => s.AddNewAppointment(appointment), Times.Once);
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

            this.mockDatabaseService
                .Setup(s => s.GetAppointmentById(1))
                .Returns(expectedAppointment);

            // Act
            var result = this.appointmentModelView.GetAppointmentById(1);

            // Assert
            Assert.Equal(expectedAppointment, result);
        }
    }
}
