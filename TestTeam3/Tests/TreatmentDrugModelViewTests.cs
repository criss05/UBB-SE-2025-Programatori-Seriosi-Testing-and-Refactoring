using System;
using System.Collections.Generic;
using Moq;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Team3.Service.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class TreatmentDrugModelViewTests
    {
        private readonly Mock<Service.Interfaces.I> mockTreatmentDrugService;
        private readonly ModelViews.Interfaces.ITreatmentDrugModelView treatmentDrugModelView;

        public TreatmentDrugModelViewTests()
        {
            this.mockTreatmentDrugService = new Mock<Service.Interfaces.I>();
            this.treatmentDrugModelView = new TreatmentDrugModelView(
                this.mockTreatmentDrugService.Object
            );
        }

        [Fact]
        public void GetTreatmentDrugsById_ValidTreatmentId_ReturnsCorrectDrugs()
        {
            var expectedDrugs = new List<TreatmentDrug>
            {
                new TreatmentDrug(
                    id: 1,
                    treatmentId: 100,
                    drugId: 5,
                    quantity: 2.5,
                    startTime: new TimeOnly(8, 0),
                    endTime: new TimeOnly(12, 0),
                    startDate: new DateOnly(2025, 4, 16),
                    nrDays: 7
                ),
                new TreatmentDrug(
                    id: 2,
                    treatmentId: 100,
                    drugId: 8,
                    quantity: 1.0,
                    startTime: new TimeOnly(14, 0),
                    endTime: new TimeOnly(16, 0),
                    startDate: new DateOnly(2025, 4, 16),
                    nrDays: 5
                )
            };

            this.mockTreatmentDrugService
                .Setup(s => s.GetTreatmentDrugsById(100))
                .Returns(expectedDrugs);

            var result = this.treatmentDrugModelView.GetTreatmentDrugsById(100);

            Assert.Equal(2, result.Count);
            Assert.All(result, td => Assert.Equal(100, td.TreatmentId));
            Assert.Contains(result, td => td.DrugId == 5 && td.Quantity == 2.5);
            Assert.Contains(result, td => td.DrugId == 8 && td.NrDays == 5);
            this.mockTreatmentDrugService.Verify(s => s.GetTreatmentDrugsById(100), Times.Once);
        }

        [Fact]
        public void GetTreatmentDrugsById_InvalidTreatmentId_ReturnsEmptyList()
        {
            this.mockTreatmentDrugService
                .Setup(s => s.GetTreatmentDrugsById(999))
                .Returns(new List<TreatmentDrug>());

            var result = this.treatmentDrugModelView.GetTreatmentDrugsById(999);

            Assert.Empty(result);
            this.mockTreatmentDrugService.Verify(s => s.GetTreatmentDrugsById(999), Times.Once);
        }

        [Fact]
        public void GetTreatmentDrugsById_DatabaseError_PropagatesException()
        {
            this.mockTreatmentDrugService
                .Setup(s => s.GetTreatmentDrugsById(100))
                .Throws(new Exception("Database connection failed"));

            var ex = Assert.Throws<Exception>(() =>
                this.treatmentDrugModelView.GetTreatmentDrugsById(100));
            Assert.Contains("Database connection failed", ex.Message);
        }
    }
}
