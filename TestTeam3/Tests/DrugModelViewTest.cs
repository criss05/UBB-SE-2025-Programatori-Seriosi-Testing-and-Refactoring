using Moq;
using Team3.DatabaseServices.Interfaces;
using Team3.ModelViews.Implementations;
using Team3.ModelViews.Interfaces;
using Team3.Models;
using Xunit;

namespace Team3.Tests.ModelViewsTests
{
    public class DrugModelViewTests
    {
        private readonly Mock<IDrugDatabaseService> mockDrugDatabaseService;
        private readonly IDrugModelView drugModelView;

        public DrugModelViewTests()
        {
            mockDrugDatabaseService = new Mock<IDrugDatabaseService>();
            drugModelView = new DrugModelView(mockDrugDatabaseService.Object);
        }

        [Fact]
        public void GetDrugById_WithValidId_ShouldReturnDrug()
        {
            // Arrange
            var expectedDrug = new Drug("Paracetamol", "Oral");
            mockDrugDatabaseService
                .Setup(s => s.GetDrugById(1))
                .Returns(expectedDrug);

            // Act
            var result = drugModelView.GetDrugById(1);

            // Assert
            Assert.NotNull(result);
 
            Assert.Equal(expectedDrug.Name, result.Name);
            Assert.Equal(expectedDrug.Administration, result.Administration);
        }

        [Fact]
        public void GetDrugById_ShouldCallDatabaseServiceOnce()
        {
            // Arrange
            var drugId = 5;
            var expectedDrug = new Drug("Ibuprofen", "Oral");

            mockDrugDatabaseService
                .Setup(s => s.GetDrugById(drugId))
                .Returns(expectedDrug);

            // Act
            var result = drugModelView.GetDrugById(drugId);

            // Assert
            mockDrugDatabaseService.Verify(s => s.GetDrugById(drugId), Times.Once);
        }
    }
}
