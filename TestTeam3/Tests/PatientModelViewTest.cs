using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team3.DatabaseServices.Interfaces;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Xunit;
using Team3.Models;
using Team3.Service.Interfaces;
using Team3.Service.Implementations;

namespace Team3.Tests.ModelViewsTests
{
    public class PatientModelViewTest
    {
        private readonly Mock<IPatientRepository> mockDatabaseService;
        private readonly IPatientModelView patientModelView;

        public PatientModelViewTest()
        {
            this.mockDatabaseService = new Mock<IPatientRepository>();
            this.patientModelView = new PatientModelView(new PatientService(this.mockDatabaseService.Object));
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
            this.patientModelView.AddPatient(patient);

            // Assert
            this.mockDatabaseService.Verify(s => s.AddPatient(patient), Times.Once);
        }

        [Fact]
        public void GetPatientById_WhenCalledWithValidId_ShouldReturPatientFromDatabase()
        {
            // Arrange
            var expectedPatient = new Patient(
                id: 1,
                userId: 1
            );

            this.mockDatabaseService
                .Setup(s => s.GetPatientById(1))
                .Returns(expectedPatient);

            // Act
            var result = this.patientModelView.GetPatientById(1);

            // Assert
            Assert.Equal(expectedPatient, result);
        }
    }
}
