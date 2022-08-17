using Microsoft.AspNetCore.Mvc;

namespace RedBadgeFinal.MVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
