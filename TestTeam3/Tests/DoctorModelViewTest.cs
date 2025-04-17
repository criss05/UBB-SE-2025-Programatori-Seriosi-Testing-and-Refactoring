using System.Collections.ObjectModel;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Team3.Repository.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class DoctorModelViewTests
    {
        private readonly Mock<IDoctorDatabaseService> mockDoctorDatabaseService;
        private readonly Mock<IMedicalRecordService> mockMedicalRecordModelView;
        private readonly Mock<IScheduleModelView> mockScheduleModelView;
        private readonly Mock<IUserModelView> mockUserModelView;
        private readonly IDoctorModelView doctorModelView;

        public DoctorModelViewTests()
        {
            mockDoctorDatabaseService = new Mock<IDoctorDatabaseService>();
            mockMedicalRecordModelView = new Mock<IMedicalRecordService>();
            mockScheduleModelView = new Mock<IScheduleModelView>();
            mockUserModelView = new Mock<IUserModelView>();

            doctorModelView = new DoctorModelView(
                mockDoctorDatabaseService.Object,
                mockMedicalRecordModelView.Object,
                mockScheduleModelView.Object,
                mockUserModelView.Object
            );
        }

        [Fact]
        public void GetDoctorById_WhenCalledWithValidId_ShouldReturnDoctor()
        {
            // Arrange
            var expectedDoctor = new Doctor(userId: 10);

            mockDoctorDatabaseService
                .Setup(s => s.GetDoctorById(1))
                .Returns(expectedDoctor);

            // Act
            var result = doctorModelView.GetDoctorById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDoctor.UserId, result.UserId);
        }

        [Fact]
        public void GetDoctorById_WhenCalled_ShouldCallDatabaseServiceOnce()
        {
            // Arrange
            var doctorId = 1;
            var expectedDoctor = new Doctor(20);

            mockDoctorDatabaseService
                .Setup(s => s.GetDoctorById(doctorId))
                .Returns(expectedDoctor);

            // Act
            var result = doctorModelView.GetDoctorById(doctorId);

            // Assert
            mockDoctorDatabaseService.Verify(s => s.GetDoctorById(doctorId), Times.Once);
        }

        [Fact]
        public void DoctorModelView_ShouldInitializeDoctorsInfoAsEmptyObservableCollection()
        {
            // Assert
            var concreteViewModel = doctorModelView as DoctorModelView;
            Assert.NotNull(concreteViewModel?.DoctorsInfo);
            Assert.Empty(concreteViewModel.DoctorsInfo);
        }
    }
}
