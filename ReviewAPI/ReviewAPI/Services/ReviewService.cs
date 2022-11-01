using ReviewAPI.Interfaces;
using ReviewAPI.Models;

namespace ReviewAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Review>> AddReview(Review review)
        {
            return await _reviewRepository.AddReview(review);
        }

        public async Task<List<Review>> DeleteReview(int id)
        {
            return await _reviewRepository.DeleteReview(id);
        }

        public async Task<List<Review>> GetAllReview()
        {
            return await _reviewRepository.GetAllReview();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await _reviewRepository.GetReviewById(id);
        }

        public async Task<List<Review>> UpdateReview(Review request)
        {
            return await _reviewRepository.UpdateReview(request);
        }
    }
}
