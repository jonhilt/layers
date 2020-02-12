using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NeoFindR.Features.Inhabitants
{
    public class InhabitantController : Controller
    {
        private readonly IMediator _mediator;

        public InhabitantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Search(Search.Query query)
        {
            var model = await _mediator.Send(query);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Destroy(Destroy.Command command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Search));
        }
    }
}