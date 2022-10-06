using ContentAPI.Interfaces;
using ContentAPI.Models;

namespace ContentAPI.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly DataContext _context;

        public ContentRepository(DataContext context)
        {
            _context = context;
        }
        Task<List<Content>> IContentRepository.AddContent(Content content)
        {
            throw new NotImplementedException();
        }

        Task<List<Content>> IContentRepository.DeleteContent(int id)
        {
            throw new NotImplementedException();
        }

        async Task<List<Content>> IContentRepository.GetAllContent()
        {
            return await _context.Contents.ToListAsync();

        }

        async Task<Content> IContentRepository.GetContentById(int id)
        {
            var content = await _context.Contents.FindAsync(id);
            if (content != null)
            {
                return content;
            }
            return null;
        }

        Task<List<Content>> IContentRepository.UpdateContent(Content request)
        {
            throw new NotImplementedException();
        }
    }
}
