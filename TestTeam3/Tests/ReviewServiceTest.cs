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
using Team3.Service.Implementations;

namespace Team3.Tests
{
    public class ReviewServiceTest
    {
        private readonly Mock<Repository.Interfaces.IReviewRepository> mockDatabaseService;
        private readonly ModelViews.Interfaces.IReviewModelView reviewModelView;

        public ReviewServiceTest()
        {
            this.mockDatabaseService = new Mock<Repository.Interfaces.IReviewRepository>();
            this.reviewModelView = new ReviewModelView(new ReviewService(this.mockDatabaseService.Object));
        }

        [Fact]
        public void AddNewReview_WhenCalled_ShouldCallDatabaseServiceWithSameReview()
        {
            // Arrange
            var review = new Review(
                id: 1,
                medicalRecordId: 1,
                message: "Hello world!",
                nrStars: 2
            );

            // Act
            this.reviewModelView.AddNewReview(review);

            // Assert
            this.mockDatabaseService.Verify(s => s.AddNewReview(review), Times.Once);
        }

        [Fact]
        public void GetReviewById_WhenCalledWithValidId_ShouldReturReviewFromDatabase()
        {
            // Arrange
            var expectedReview = new Review(
                id: 1,
                medicalRecordId: 1,
                message: "Hello world!",
                nrStars: 2
            );

            this.mockDatabaseService
                .Setup(s => s.GetReviewByMedicalRecordId(1))
                .Returns(expectedReview);

            // Act
            var result = this.reviewModelView.GetReviewByMedicalRecordId(1);

            // Assert
            Assert.Equal(expectedReview, result);
        }
    }
}
