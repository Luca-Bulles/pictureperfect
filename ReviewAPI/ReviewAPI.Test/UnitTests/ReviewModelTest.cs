using AutoFixture;
using ReviewAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewAPI.Test.UnitTests
{
    public class ReviewModelTest
    {
        private readonly IFixture _ifixture = new Fixture();

        [Fact]
        public void Constructor()
        {
            //Arrange
            Review review = new Review(_ifixture.Create<int>(), "Good", 
                "Not great but good", "No");
            var reviewId = _ifixture.Create<int>();
            var title = "Bad";
            var content = "Worst thing i ever have watched";
            var reported = "Yes";

            //Act
            review.ReviewId= reviewId;
            review.ReviewTitle= title;
            review.ReviewContent= content;
            review.Reported=reported;

            //Assert
            Assert.Equal(reviewId, review.ReviewId);
            Assert.Equal(title, review.ReviewTitle);
            Assert.Equal(content, review.ReviewContent);
            Assert.Equal(reported, review.Reported);

        }
    }
}
