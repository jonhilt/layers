using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NeoFindR.Features.Inhabitants
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = await _mediator.Send(new ListAll.Query());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Search(Search.Query query)
        {
            var results = await _mediator.Send(query);
            return View(results);
        }

        [HttpDelete]
        public async Task<IActionResult> Destroy(Destroy.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}