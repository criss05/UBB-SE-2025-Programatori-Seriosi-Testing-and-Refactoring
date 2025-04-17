using System;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.Service.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class TreatmentModelViewTests
    {
        private readonly Mock<ITreatmentService> mockTreatmentService;
        private readonly TreatmentModelView treatmentModelView;

        public TreatmentModelViewTests()
        {
            mockTreatmentService = new Mock<ITreatmentService>();
            treatmentModelView = new TreatmentModelView(mockTreatmentService.Object);
        }

        [Fact]
        public void GetTreatmentByMedicalRecordId_ExistingTreatment_ReturnsTreatment()
        {
            var expectedTreatment = new Treatment(1, 42);
            mockTreatmentService
                .Setup(s => s.GetTreatmentByMedicalRecordId(42))
                .Returns(expectedTreatment);

            var result = treatmentModelView.GetTreatmentByMedicalRecordId(42);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(42, result.MedicalRecordId);
            mockTreatmentService.Verify(s => s.GetTreatmentByMedicalRecordId(42), Times.Once);
        }

        [Fact]
        public void GetTreatmentByMedicalRecordId_NonExistingTreatment_ReturnsNull()
        {
            mockTreatmentService
                .Setup(s => s.GetTreatmentByMedicalRecordId(99))
                .Returns((Treatment)null);

            var result = treatmentModelView.GetTreatmentByMedicalRecordId(99);

            Assert.Null(result);
            mockTreatmentService.Verify(s => s.GetTreatmentByMedicalRecordId(99), Times.Once);
        }

        [Fact]
        public void GetTreatmentByMedicalRecordId_ServiceThrows_PropagatesException()
        {
            mockTreatmentService
                .Setup(s => s.GetTreatmentByMedicalRecordId(123))
                .Throws(new Exception("Database failure"));

            var ex = Assert.Throws<Exception>(() => treatmentModelView.GetTreatmentByMedicalRecordId(123));
            Assert.Contains("Database failure", ex.Message);
        }
    }
}
