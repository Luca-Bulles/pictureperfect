using ContentAPI.Interfaces;
using ContentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IContentRepository _contentRepository;

        //public ContentController(DataContext context)
        //{
        //    _context = context;
        //}

        public ContentController(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Content>>> GetAllContent()
        {
            //return Ok(await _context.Contents.ToListAsync());
            return Ok(await _contentRepository.GetAllContent());
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Content>> GetContentById(int id)
        //{
        //    var content = await _context.Contents.FindAsync(id);
        //    if (content == null)
        //    {
        //        return BadRequest("Content not found");
        //    }
        //    return Ok(content);
        //}

        //[HttpPost]
        //public async Task<ActionResult<List<Content>>> PostContent(Content content)
        //{
        //    _context.Contents.Add(content);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Contents.ToListAsync());
        //}

        //[HttpPut]
        //public async Task<ActionResult<List<Content>>> UpdateContent(Content request)
        //{
        //    var dbContent = await _context.Contents.FindAsync(request.ContentId);
        //    if (dbContent == null)
        //    {
        //        return BadRequest("Content not found.");
        //    }

        //    dbContent.Category = request.Category;
        //    dbContent.Name = request.Name;
        //    dbContent.Subject = request.Subject;
        //    dbContent.Description = request.Description;
        //    dbContent.Cast = request.Cast;
        //    dbContent.Duration = request.Duration;
        //    dbContent.Year = request.Year;

        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Contents.ToListAsync());
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<Content>>> DeleteContent(int id)
        //{
        //    var dbContent = await _context.Contents.FindAsync(id);
        //    if (dbContent == null)
        //    {
        //        return BadRequest("Content not found.");
        //    }

        //    _context.Contents.Remove(dbContent);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Contents.ToListAsync());
        //}
    }
}
