using AutoFixture;
using ContentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentAPI.Test.UnitTests
{
    public class ContentModelTest
    {
        private readonly IFixture _ifixture = new Fixture();

        [Fact]
        public void ConstructorTest()
        {
            //Arrange
            var contentId = _ifixture.Create<int>();
            var category = "Series";
            var name = "After Earth Making of";
            var subject = "Thriller";
            var description = "Series about After Earth production";
            var cast = "Will Smith & Others";
            var duration = "130 minutes";
            var year = 2017;

            Content content = new Content(_ifixture.Create<int>(), "Movies", "After Earth",
                "Thriller", "Movie about post apocolyptical world", "Will Smith", "128 Minutes", 2015);

            //Act
            content.ContentId = contentId;
            content.Name = name;
            content.Category= category;
            content.Subject = subject;
            content.Description = description;
            content.Cast = cast;
            content.Duration = duration;
            content.Year = year;

            //Assert
            Assert.Equal(contentId, content.ContentId);
            Assert.Equal(category, content.Category);
            Assert.Equal(name, content.Name);
            Assert.Equal(subject, content.Subject);
            Assert.Equal(description, content.Description);
            Assert.Equal(cast, content.Cast);
            Assert.Equal(duration, content.Duration);
            Assert.Equal(year, content.Year);

        }
    }
}
