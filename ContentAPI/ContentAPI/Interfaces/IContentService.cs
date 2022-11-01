using ContentAPI.Models;

namespace ContentAPI.Interfaces
{
    public interface IContentService
    {
        Task<List<Content>> GetAllContent();
        Task<Content> GetContentById(int id);
        Task<List<Content>> AddContent(Content content);
        Task<List<Content>> UpdateContent(Content request);
        Task<List<Content>> DeleteContent(int id);
    }
}
