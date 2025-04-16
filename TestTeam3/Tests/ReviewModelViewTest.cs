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

namespace Team3.Tests.ModelViewsTests
{
    public class ReviewModelViewTest
    {
        private readonly Mock<IReviewDatabaseService> mockDatabaseService;
        private readonly IReviewModelView reviewModelView;

        public ReviewModelViewTest()
        {
            this.mockDatabaseService = new Mock<IReviewDatabaseService>();
            this.reviewModelView = new ReviewModelView(this.mockDatabaseService.Object);
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
