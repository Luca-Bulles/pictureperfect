using Microsoft.AspNetCore.Mvc;
using ReviewAPI.Interfaces;
using ReviewAPI.Models;

namespace ReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetAllReviews()
        {
            return Ok(await _reviewService.GetAllReview());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {
            var response = await _reviewService.GetReviewById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Review not found with given id");
        }

        [HttpPost]
        public async Task<ActionResult<List<Review>>> PostReview(Review review)
        {
            return Ok(await _reviewService.AddReview(review));
        }

        [HttpPut]
        public async Task<ActionResult<List<Review>>> UpdateReview(Review request)
        {
            var response = await _reviewService.UpdateReview(request);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Review not found with given id");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Review>>> DeleteReview(int id)
        {
            var response = await _reviewService.DeleteReview(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Review not found with given id");
        }
    }
}
