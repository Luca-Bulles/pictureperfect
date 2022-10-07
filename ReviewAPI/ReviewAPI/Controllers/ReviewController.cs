using Microsoft.AspNetCore.Mvc;
using ReviewAPI.Interfaces;
using ReviewAPI.Models;

namespace ReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetAllReviews()
        {
            return Ok(await _reviewRepository.GetAllReview());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {
            var response = await _reviewRepository.GetReviewById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Review not found with given id");
        }

        [HttpPost]
        public async Task<ActionResult<List<Review>>> PostReview(Review review)
        {
            return Ok(await _reviewRepository.AddReview(review));
        }

        [HttpPut]
        public async Task<ActionResult<List<Review>>> UpdateReview(Review request)
        {
            var response = await _reviewRepository.UpdateReview(request);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Review not found with given id");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Review>>> DeleteReview(int id)
        {
            var response = await _reviewRepository.DeleteReview(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Review not found with given id");
        }
    }
}
