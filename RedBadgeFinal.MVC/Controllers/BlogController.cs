using Microsoft.AspNetCore.Mvc;
using RedBadgeFinal.Models.Models.BlogModel;
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
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogservice.GetBlogList();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create(BlogCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _blogservice.CreateBlog(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }
    }
}
