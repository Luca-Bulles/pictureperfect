using AutoFixture;
using ContentAPI.Controllers;
using ContentAPI.Interfaces;
using ContentAPI.Models;
using ContentAPI.Repositories;
using ContentAPI.Services;
using FluentAssertions;
using Moq;

namespace ContentAPI.Test.IntegrationTests
{
    public class ContentControllerTest
    {
        private readonly IFixture _ifixture;
        private readonly Mock<IContentService> _contentServiceMock; //mocking real content sercice
        private readonly ContentController _contentTest;

        public ContentControllerTest()
        {
            _ifixture = new Fixture();
            _contentServiceMock = new Mock<IContentService>();
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

        //Test Get All Content
        [Fact]
        public async Task GetAllContentTest()
        {
            //Arrange
            var result = await _contentTest.GetAllContent().ConfigureAwait(false);

            //Assert
            Assert.NotNull(result);
            _contentServiceMock.Verify(x => x.GetAllContent(), Times.Once());
        }
        
        //Test Delete Content
        [Fact]
        public async Task DeleteContentTest()
        {
            //Arrange
            var contentId = _ifixture.Create<int>();

            //Act 
            var result = await _contentTest.DeleteContent(contentId).ConfigureAwait(false);

            //Assert
            result.Should().NotBeNull();
            _contentServiceMock.Verify(x => x.DeleteContent(contentId), Times.Once());
        }

        //Test Update Content
        [Fact]
        public async Task UpdateContentTest()
        {
            //Arrange
            Content content = new Content(_ifixture.Create<int>(), "Movies", "After Earth",
                "Thriller", "Movie about post apocalyptic world", "Will Smith", "128 Minutes", 2015);


            //Act
            var result = await _contentTest.UpdateContent(content);

            //Assert
            result.Should().NotBeNull();
            _contentServiceMock.Verify(x => x.UpdateContent(content), Times.Once());
        }

        //Test Post Content
        [Fact]
        public async Task PostContent()
        {
            //Arrange
            Content content = new Content(_ifixture.Create<int>(), "Movies", "After Earth",
                "Thriller", "Movie about post apocalyptic world", "Will Smith", "128 Minutes", 2015);

            //Act
            var result = await _contentTest.PostContent(content);

            //Assert
            result.Should().NotBeNull();
            _contentServiceMock.Verify(x => x.AddContent(content), Times.Once());
        }
    }
}