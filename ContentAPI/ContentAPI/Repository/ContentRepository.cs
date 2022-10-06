using ContentAPI.Models;

namespace ContentAPI.Repository
{
    public class ContentRepository : IContentRepository
    {
        private readonly DataContext _context;

        public ContentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Content>> GetAllContent()
        {
            return await _context.Contents.ToListAsync();
        }

        public async Task<Content> GetContentById(int id)
        {
            return await _context.Contents.SingleOrDefaultAsync(c => c.ContentId == id);
        }

        public async Task<IEnumerable<Content>> PostContent(Content content)
        {
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();

            return await _context.Contents.ToListAsync();
        }

        public async Task<IEnumerable<Content>> UpdateContent(Content request)
        {
            var dbContent = await _context.Contents.FindAsync(request.ContentId);
            if (dbContent != null)
            {
                dbContent.Category = request.Category;
                dbContent.Name = request.Name;
                dbContent.Subject = request.Subject;
                dbContent.Description = request.Description;
                dbContent.Cast = request.Cast;
                dbContent.Duration = request.Duration;
                dbContent.Year = request.Year;

                await _context.SaveChangesAsync();

                return await _context.Contents.ToListAsync();
            }

            return null;

        }

        public async void DeleteContent(int id)
        {
            var dbContent = await _context.Contents.FindAsync(id);
            if (dbContent != null)
            {
                _context.Contents.Remove(dbContent);
                await _context.SaveChangesAsync();

            }

        }
    }
}
