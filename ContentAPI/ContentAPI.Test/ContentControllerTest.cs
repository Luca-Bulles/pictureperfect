using AutoFixture;
using ContentAPI.Controllers;
using ContentAPI.Interfaces;
using ContentAPI.Models;
using ContentAPI.Repositories;
using ContentAPI.Services;
using FluentAssertions;
using Moq;

namespace ContentAPI.Test
{
    public class ContentControllerTest
    {
        private readonly IFixture _ifixture;
        private readonly Mock<IContentService> _contentServiceMock; //mocking real content sercice
        private readonly ContentController _contentTest;

        public ContentControllerTest()
        {
            _ifixture = new Fixture();
            _contentServiceMock= new Mock<IContentService>();
            _contentTest = new ContentController(_contentServiceMock.Object);
        }

        //Test Get Content By Id 

        [Fact]
        public async Task GetContentById()
        {
            //Arrange
            var contentMockData = _ifixture.Create<Content>();
            var id = _ifixture.Create<int>();

            //Act
            var result = await _contentTest.GetContentById(id).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            _contentServiceMock.Verify(x => x.GetContentById(id), Times.Once());
        }

        [Fact]
        public async Task GetAllContentTest()
        {
            //Arrange
            var result = await _contentTest.GetAllContent().ConfigureAwait(false);

            //Assert
            Assert.NotNull(result);
            _contentServiceMock.Verify(x => x.GetAllContent(), Times.Once());
        }
    }
}