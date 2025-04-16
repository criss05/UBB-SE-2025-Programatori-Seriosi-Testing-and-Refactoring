using System;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.DatabaseServices.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class TreatmentModelViewTests
    {
        private readonly Mock<ITreatmentDatabaseService> mockTreatmentDbService;
        private readonly TreatmentModelView treatmentModelView;

        public TreatmentModelViewTests()
        {
            mockTreatmentDbService = new Mock<ITreatmentDatabaseService>();
            treatmentModelView = new TreatmentModelView(mockTreatmentDbService.Object);
        }

        [Fact]
        public void GetTreatmentByMedicalRecordId_ExistingTreatment_ReturnsTreatment()
        {
            var expectedTreatment = new Treatment(1, 42);
            mockTreatmentDbService
                .Setup(s => s.GetTreatmentByMedicalRecordId(42))
                .Returns(expectedTreatment);

            var result = treatmentModelView.GetTreatmentByMedicalRecordId(42);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(42, result.MedicalRecordId);
            mockTreatmentDbService.Verify(s => s.GetTreatmentByMedicalRecordId(42), Times.Once);
        }

        [Fact]
        public void GetTreatmentByMedicalRecordId_NonExistingTreatment_ReturnsNull()
        {
            mockTreatmentDbService
                .Setup(s => s.GetTreatmentByMedicalRecordId(99))
                .Returns((Treatment)null);

            var result = treatmentModelView.GetTreatmentByMedicalRecordId(99);

            Assert.Null(result);
            mockTreatmentDbService.Verify(s => s.GetTreatmentByMedicalRecordId(99), Times.Once);
        }

        [Fact]
        public void GetTreatmentByMedicalRecordId_ServiceThrows_PropagatesException()
        {
            mockTreatmentDbService
                .Setup(s => s.GetTreatmentByMedicalRecordId(123))
                .Throws(new Exception("Database failure"));

            var ex = Assert.Throws<Exception>(() => treatmentModelView.GetTreatmentByMedicalRecordId(123));
            Assert.Contains("Database failure", ex.Message);
        }
    }
}
