using Moq;
using Xunit;
using Team3.Models;
using Team3.Service.Implementations;
using Team3.Repository.Interfaces;

namespace Team3.Tests
{
    public class DrugServiceTests
    {
        private readonly Mock<IDrugRepository> mockDrugRepository;
        private readonly DrugService drugService;

        public DrugServiceTests()
        {
            mockDrugRepository = new Mock<IDrugRepository>();
            drugService = new DrugService(mockDrugRepository.Object);
        }

        [Fact]
        public void GetDrugById_WithValidId_ShouldReturnDrug()
        {
            // Arrange
            var expectedDrug = new Drug(1, "Paracetamol", "Oral");

            mockDrugRepository
                .Setup(repo => repo.GetDrugById(1))
                .Returns(expectedDrug);

            // Act
            var result = drugService.GetDrugById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDrug.Name, result.Name);
            Assert.Equal(expectedDrug.Administration, result.Administration);
        }

        [Fact]
        public void GetDrugById_ShouldCallRepositoryOnce()
        {
            // Arrange
            var drugId = 5;
            var expectedDrug = new Drug(5, "Ibuprofen", "Oral");

            mockDrugRepository
                .Setup(repo => repo.GetDrugById(drugId))
                .Returns(expectedDrug);

            // Act
            var result = drugService.GetDrugById(drugId);

            // Assert
            mockDrugRepository.Verify(repo => repo.GetDrugById(drugId), Times.Once);
        }
    }
}
