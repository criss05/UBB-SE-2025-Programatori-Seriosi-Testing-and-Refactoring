using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.Repository.Interfaces;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Xunit;
using Team3.Models;
using Team3.Service.Interfaces;
using Team3.Service.Implementations;

namespace Team3.Tests
{
    public class PatientServiceTest
    {
        private readonly Mock<IPatientRepository> mockRepository;
        private readonly IPatientService patientService;

        public PatientServiceTest()
        {
            this.mockRepository = new Mock<IPatientRepository>();
            this.patientService = new PatientService(this.mockRepository.Object);
        }

        [Fact]
        public void AddNewPatient_WhenCalled_ShouldCallDatabaseServiceWithSamePatient()
        {
            // Arrange
            var patient = new Patient(
                id: 1,
                userId: 1
            );

            // Act
            this.patientService.AddPatient(patient);

            // Assert
            this.mockRepository.Verify(s => s.AddPatient(patient), Times.Once);
        }

        [Fact]
        public void GetPatientById_WhenCalledWithValidId_ShouldReturPatientFromDatabase()
        {
            // Arrange
            var expectedPatient = new Patient(
                id: 1,
                userId: 1
            );

            this.mockRepository
                .Setup(s => s.GetPatientById(1))
                .Returns(expectedPatient);

            // Act
            var result = this.patientService.GetPatientById(1);

            // Assert
            Assert.Equal(expectedPatient, result);
        }
    }
}
