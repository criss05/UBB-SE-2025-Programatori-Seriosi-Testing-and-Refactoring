using Moq;
using Xunit;
using Team3.Models;
using Team3.Service.Implementations;
using Team3.Repository.Interfaces;
using Team3.Service.Interfaces;
using Team3.ModelViews.Interfaces;
using Team3.Repository.Interface;

namespace Team3.Tests
{
    public class DoctorServiceTests
    {
        private readonly Mock<IDoctorRepository> doctorRepositoryMock;
        private readonly Mock<IMedicalRecordService> medicalRecordServiceMock;
        private readonly Mock<IScheduleService> scheduleServiceMock;
        private readonly Mock<IUserService> userServiceMock;
        private readonly DoctorService doctorService;

        public DoctorServiceTests()
        {
            doctorRepositoryMock = new Mock<IDoctorRepository>();
            medicalRecordServiceMock = new Mock<IMedicalRecordService>();
            scheduleServiceMock = new Mock<IScheduleService>();
            userServiceMock = new Mock<IUserService>();

            doctorService = new DoctorService(
                doctorRepositoryMock.Object,
                medicalRecordServiceMock.Object,
                scheduleServiceMock.Object,
                userServiceMock.Object
            );
        }

        [Fact]
        public void GetDoctorById_ShouldReturnDoctor_WhenDoctorExists()
        {
            // Arrange
            var doctorId = 1;
            var expectedDoctor = new Doctor(userId: doctorId);
            doctorRepositoryMock
                .Setup(repo => repo.GetDoctorById(doctorId))
                .Returns(expectedDoctor);

            // Act
            var result = doctorService.GetDoctorById(doctorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDoctor.UserId, result.UserId);
        }

        [Fact]
        public void GetDoctorById_ShouldCallRepositoryOnce()
        {
            // Arrange
            var doctorId = 42;
            var expectedDoctor = new Doctor(userId: doctorId);
            doctorRepositoryMock
                .Setup(repo => repo.GetDoctorById(doctorId))
                .Returns(expectedDoctor);

            // Act
            var result = doctorService.GetDoctorById(doctorId);

            // Assert
            doctorRepositoryMock.Verify(repo => repo.GetDoctorById(doctorId), Times.Once);
        }
    }
}
