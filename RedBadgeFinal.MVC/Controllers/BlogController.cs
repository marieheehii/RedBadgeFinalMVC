using Microsoft.AspNetCore.Mvc;
using RedBadgeFinal.Models.Models.BlogModel;
using RedBadgeFinal.Services.BlogServices;
using System.Security.Claims;

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
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return BadRequest();

            var blog = await  _blogservice.GetBLogDetails(id);
            if (blog == null) return NotFound();
            return View(blog);

        }

        [HttpGet]
        public IActionResult Create()
        {
            if(User.Identity.IsAuthenticated)
            {
                BlogCreate model = new BlogCreate();
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                model.UserEntityId = claim;

                return View(model);
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
