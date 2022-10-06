using ContentAPI.Models;

namespace ContentAPI
{
    public interface IContentRepository
    {
        Task<List<Content>> GetAllContent();
        Task<Content> GetContentById(int id);
        Task<IEnumerable<Content>> PostContent(Content content);
        Task<IEnumerable<Content>> UpdateContent(Content request);
        void DeleteContent(int id);

    }
}