using Microsoft.AspNetCore.Mvc;
using RedBadgeFinal.Models.Models.EventEntityModel;
using RedBadgeFinal.Services.EventEntityServices;

namespace RedBadgeFinal.MVC.Controllers
{
    public class EventEntityController : Controller
    {
        private readonly IEventEntityService _evententityservice;
        public EventEntityController(IEventEntityService evententityservice)
        {
            _evententityservice = evententityservice;

        }
        public async Task<IActionResult> Index()
        {
            var evententity = await _evententityservice.GetEventEntityList();
            return View(evententity);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return BadRequest();

            var evententity = await _evententityservice.GetEventEntityDetails(id);
            if (evententity == null) return NotFound();
            return View(evententity);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _evententityservice.CreateEventEntity(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var evententity = await _evententityservice.GetEventEntityDetails(id.Value);
            if (evententity == null) return NotFound();

            return View(evententity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventEdit model)
        {
            if (id != model.Id || !ModelState.IsValid) return BadRequest(ModelState);

            if (await _evententityservice.UpdateEventEntity(id, model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var evententity = await _evententityservice.GetEventEntityDetails(id.Value);
            if (evententity == null) return NotFound();
            return View(evententity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _evententityservice.DeleteEventEntity(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
