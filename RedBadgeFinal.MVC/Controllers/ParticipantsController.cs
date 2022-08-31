using Microsoft.AspNetCore.Mvc;
using RedBadgeFinal.Models.Models.ParticipantsModel;
using RedBadgeFinal.Services.ParticipantServices;

namespace RedBadgeFinal.MVC.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly IParticipationService _pservice;
        public ParticipantsController(IParticipationService pservice)
        {
            _pservice = pservice;
        }

        public async Task<IActionResult> Index()
        {
            var participant = await _pservice.GetParticipantList();
            return View(participant);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null) return BadRequest();

            var participant = await _pservice.GetParticipantDetail(id);
            if (participant == null) return NotFound();
            return View(participant);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateParticipant model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _pservice.CreateParticipant(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var participant = await _pservice.GetParticipantDetail(id.Value);
            if (participant == null) return NotFound();

            return View(participant);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditParticipant model)
        {
            if (id != model.Id || !ModelState.IsValid) return BadRequest(ModelState);

            if (await _pservice.UpdateParticipant(id, model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var participant = await _pservice.GetParticipantDetail(id.Value);
            if (participant == null) return NotFound();
            return View(participant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _pservice.DeleteParticipant(id))
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
