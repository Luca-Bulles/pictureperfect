using ReviewAPI.Interfaces;
using ReviewAPI.Models;

namespace ReviewAPI.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        Task<List<Review>> IReviewRepository.AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        Task<List<Review>> IReviewRepository.DeleteReview(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Review>> IReviewRepository.GetAllReview()
        {
            throw new NotImplementedException();
        }

        Task<Review> IReviewRepository.GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Review>> IReviewRepository.UpdateReview(Review request)
        {
            throw new NotImplementedException();
        }
    }
}
