using AutoFixture;
using Moq;
using ReviewAPI.Controllers;
using ReviewAPI.Interfaces;

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


    }
}