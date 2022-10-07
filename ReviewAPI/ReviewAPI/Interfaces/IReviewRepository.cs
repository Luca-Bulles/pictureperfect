using ReviewAPI.Models;

namespace ReviewAPI.Interfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReview();
        Task<Review> GetReviewById(int id);
        Task<List<Review>> AddReview(Review review);
        Task<List<Review>> UpdateReview(Review request);
        Task<List<Review>> DeleteReview(int id);
    }
}
