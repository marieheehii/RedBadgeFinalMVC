using Microsoft.AspNetCore.Mvc;
using RedBadgeFinal.Services.BlogServices;

namespace RedBadgeFinal.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogservice;
        public BlogController(IBlogService blogservice)
        {
            _blogservice = blogservice;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
