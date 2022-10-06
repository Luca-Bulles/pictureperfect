using Microsoft.AspNetCore.Mvc;

namespace Article.API.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
