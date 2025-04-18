using Moq;
using Xunit;
using System;
using Team3.Models;
using Team3.Service.Implementations;
using Team3.Repository.Interfaces;

namespace Team3.Tests
{
    public class MedicalRecordServiceTests
    {
        private readonly Mock<IMedicalRecordRepository> mockMedicalRecordRepository;
        private readonly MedicalRecordService medicalRecordService;

        public MedicalRecordServiceTests()
        {
            mockMedicalRecordRepository = new Mock<IMedicalRecordRepository>();
            medicalRecordService = new MedicalRecordService(mockMedicalRecordRepository.Object);
        }

        [Fact]
        public void GetMedicalRecordById_WithValidId_ShouldReturnMedicalRecord()
        {
            // Arrange
            var expected = new MedicalRecord(1, 101, 202, DateTime.Today);

            mockMedicalRecordRepository
                .Setup(repo => repo.GetMedicalRecordById(1))
                .Returns(expected);

            // Act
            var result = medicalRecordService.GetMedicalRecordById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.DoctorId, result.DoctorId);
            Assert.Equal(expected.PatientId, result.PatientId);
            Assert.Equal(expected.MedicalRecordDateTime, result.MedicalRecordDateTime);
        }

        [Fact]
        public void GetMedicalRecordById_ShouldCallRepositoryOnce()
        {
            // Arrange
            int recordId = 42;
            var dummy = new MedicalRecord(42, 123, 456, DateTime.Today);

            mockMedicalRecordRepository
                .Setup(repo => repo.GetMedicalRecordById(recordId))
                .Returns(dummy);

            // Act
            var result = medicalRecordService.GetMedicalRecordById(recordId);

            // Assert
            mockMedicalRecordRepository.Verify(repo => repo.GetMedicalRecordById(recordId), Times.Once);
        }
    }
}
