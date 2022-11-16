using AutoFixture;
using FluentAssertions;
using Moq;
using ReviewAPI.Controllers;
using ReviewAPI.Interfaces;
using ReviewAPI.Models;

namespace ReviewAPI.Test.IntegrationTests
{
    public class ReviewControllerTest
    {
        private readonly IFixture _ifixture;
        private readonly Mock<IReviewService> _reviewServiceMock;
        private readonly ReviewController _reviewTest;

        public ReviewControllerTest()
        {
            _ifixture = new Fixture();
            _reviewServiceMock = new Mock<IReviewService>();
            _reviewTest = new ReviewController(_reviewServiceMock.Object);
        }

        //Test Get Review By Id
        [Fact]
        public async Task GetReviewById()
        {
            //Arrange
            var reviewMockData = _ifixture.Create<Review>();
            var id = _ifixture.Create<int>();

            //Act
            var result = await _reviewTest.GetReviewById(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            _reviewServiceMock.Verify(x => x.GetReviewById(id), Times.Once());
        }

        //Test Get all Reviews
        [Fact]
        public async Task GetAllReviews()
        {
            //Arrange
            var result = await _reviewTest.GetAllReviews().ConfigureAwait(false);

            //Assert
            Assert.NotNull(result);
            _reviewServiceMock.Verify(x => x.GetAllReview(), Times.Once());
        }


    }
}