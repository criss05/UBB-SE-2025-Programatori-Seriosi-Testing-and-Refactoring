using Moq;
using Xunit;
using Team3.Models;
using Team3.ModelViews.Implementations;
using Team3.DatabaseServices.Interfaces;

namespace Team3.Tests.ModelViewsTests
{
    public class MedicalRecordModelViewTests
    {
        private readonly Mock<IMedicalRecordDatabaseService> mockMedicalRecordDatabaseService;
        private readonly MedicalRecordModelView medicalRecordModelView;

        public MedicalRecordModelViewTests()
        {
            mockMedicalRecordDatabaseService = new Mock<IMedicalRecordDatabaseService>();
            medicalRecordModelView = new MedicalRecordModelView(mockMedicalRecordDatabaseService.Object);
        }

        [Fact]
        public void GetMedicalRecordById_WithValidId_ShouldReturnMedicalRecord()
        {
            // Arrange
            var expected = new MedicalRecord(101, 202, DateTime.Today);
            mockMedicalRecordDatabaseService
                .Setup(s => s.GetMedicalRecordById(1))
                .Returns(expected);

            // Act
            var result = medicalRecordModelView.GetMedicalRecordById(1);

            // Assert
            Assert.NotNull(result); 
            Assert.Equal(expected.DoctorId, result.DoctorId);
            Assert.Equal(expected.PatientId, result.PatientId);
            Assert.Equal(expected.MedicalRecordDateTime, result.MedicalRecordDateTime);
        }

        [Fact]
        public void GetMedicalRecordById_ShouldCallDatabaseServiceOnce()
        {
            // Arrange
            var recordId = 5;
            var dummy = new MedicalRecord(102, 203, DateTime.Today);
            mockMedicalRecordDatabaseService
                .Setup(s => s.GetMedicalRecordById(recordId))
                .Returns(dummy);

            // Act
            var result = medicalRecordModelView.GetMedicalRecordById(recordId);

            // Assert
            mockMedicalRecordDatabaseService.Verify(s => s.GetMedicalRecordById(recordId), Times.Once);
        }
    }
}
