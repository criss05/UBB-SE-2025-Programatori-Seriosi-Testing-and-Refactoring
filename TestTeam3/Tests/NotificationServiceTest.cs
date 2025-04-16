using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DatabaseServices.Implementations;
using Team3.DatabaseServices.Interfaces;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Xunit;
using Team3.Models;
using Team3.Service.Implementations;
using Team3.Service.Interfaces;

namespace Team3.Tests.ModelViewsTests
{
    public class NotificationServiceTest
    {
        private readonly Mock<INotificationRepository> mockDatabaseService;
        private readonly INotificationService notificationService;

        private readonly IAppointmentModelView appointmentModelView;
        private readonly IDoctorModelView doctorModelView;
        private readonly IUserModelView userModelView;
        private readonly IPatientModelView patientModelView;
        private readonly IMedicalRecordModelView medicalRecordModelView;
        private readonly IDrugModelView drugModelView;
        private readonly ITreatmentDrugModelView treatmentDrugModelView;
        private readonly ITreatmentModelView treatmentModelView;
        private readonly IReviewModelView reviewModelView;


        public NotificationServiceTest()
        {
            this.mockDatabaseService = new Mock<INotificationRepository>();

            this.appointmentModelView = new Mock<IAppointmentModelView>().Object;
            this.doctorModelView = new Mock<IDoctorModelView>().Object;
            this.userModelView = new Mock<IUserModelView>().Object;
            this.patientModelView = new Mock<IPatientModelView>().Object;
            this.medicalRecordModelView = new Mock<IMedicalRecordModelView>().Object;
            this.drugModelView = new Mock<IDrugModelView>().Object;
            this.treatmentDrugModelView = new Mock<ITreatmentDrugModelView>().Object;
            this.treatmentModelView = new Mock<ITreatmentModelView>().Object;
            this.reviewModelView = new Mock<IReviewModelView>().Object;

            this.notificationService = new NotificationService(this.mockDatabaseService.Object, this.appointmentModelView, this.doctorModelView, this.userModelView, this.patientModelView, this.medicalRecordModelView, this.drugModelView, this.treatmentDrugModelView, this.treatmentModelView, this.reviewModelView);
        }

        [Fact]
        public void AddNewNotification_WhenCalled_ShouldCallDatabaseServiceWithSameNotification()
        {
            // Arrange
            var notification = new Notification(
                id: 1,
                userId: 1,
                deliveryDateTime: new DateTime(2025, 5, 1, 14, 30, 0),
                message: "Hello, World!"
            );

            // Act
            this.notificationService.AddNotification(notification);

            // Assert
            this.mockDatabaseService.Verify(s => s.AddNotification(notification), Times.Once);
        }

        [Fact]
        public void GetNotificationById_WhenCalledWithValidId_ShouldReturNotificationFromDatabase()
        {
            // Arrange
            var expectedNotification = new Notification(
                id: 1,
                userId: 1,
                deliveryDateTime: new DateTime(2025, 5, 1, 14, 30, 0),
                message: "Hello, World!"
            );

            this.mockDatabaseService
                .Setup(s => s.GetNotificationById(1))
                .Returns(expectedNotification);

            // Act
            var result = this.notificationService.GetNotificationById(1);

            // Assert
            Assert.Equal(expectedNotification, result);
        }

    }
}
