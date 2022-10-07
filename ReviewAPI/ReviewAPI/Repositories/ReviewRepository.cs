using ReviewAPI.Interfaces;
using ReviewAPI.Models;

namespace ReviewAPI.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        async Task<List<Review>> IReviewRepository.AddReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return await _context.Reviews.ToListAsync();
        }

        async Task<List<Review>> IReviewRepository.DeleteReview(int id)
        {
            var dbReview = await _context.Reviews.FindAsync(id);
            if(dbReview != null)
            {
                _context.Reviews.Remove(dbReview);
                await _context.SaveChangesAsync();

                return _context.Reviews.ToList();
            }

            return null;
        }

        async Task<List<Review>> IReviewRepository.GetAllReview()
        {
            return await _context.Reviews.ToListAsync();
        }

        async Task<Review> IReviewRepository.GetReviewById(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                return review;
            }
            return null;
        }

        async Task<List<Review>> IReviewRepository.UpdateReview(Review request)
        {
            var dbReview = await _context.Reviews.FindAsync(request.ReviewId);
            if (dbReview != null)
            {
                dbReview.ReviewContent = request.ReviewContent;
                dbReview.ReviewTitle = request.ReviewTitle;
                dbReview.Reported = request.Reported;

                await _context.SaveChangesAsync();

                return await _context.Reviews.ToListAsync();
            }
            return null;
        }
    }
}
