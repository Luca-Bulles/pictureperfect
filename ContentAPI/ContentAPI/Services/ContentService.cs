using ContentAPI.Interfaces;
using ContentAPI.Models;

namespace ContentAPI.Services
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _contentRepository;

        public ContentService(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public async Task<List<Content>> AddContent(Content content)
        {
            return await _contentRepository.AddContent(content);
        }

        public async Task<List<Content>> DeleteContent(int id)
        {
            return await _contentRepository.DeleteContent(id);
        }

        public async Task<List<Content>> GetAllContent()
        {
            return await _contentRepository.GetAllContent();
        }

        public async Task<Content> GetContentById(int id)
        {
            return await _contentRepository.GetContentById(id);
        }

        public async Task<List<Content>> UpdateContent(Content request)
        {
            return await _contentRepository.UpdateContent(request);
        }
    }
}
