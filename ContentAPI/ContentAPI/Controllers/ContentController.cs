using ContentAPI.Interfaces;
using ContentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//
    public class ContentController : ControllerBase
    {
        private readonly IContentService _ContentService;

        public ContentController(IContentService contentService)
        {
            _ContentService = contentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Content>>> GetAllContent()
        {
            return Ok(await _ContentService.GetAllContent());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Content>> GetContentById(int id)
        {
            var response = await _ContentService.GetContentById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound("Content not found with given id");
        }

        [HttpPost]
        public async Task<ActionResult<List<Content>>> PostContent(Content content)
        {
            return Ok(await _ContentService.AddContent(content));
        }

        [HttpPut]
        public async Task<ActionResult<List<Content>>> UpdateContent(Content request)
        {
            var response = await _ContentService.UpdateContent(request);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Content not found with given id");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Content>>> DeleteContent(int id)
        {
            var Response = await _ContentService.DeleteContent(id);
            if(Response != null)
            {
                return Ok(Response);
            }

            return NotFound("Content not found with given id");
        }
    }
}
