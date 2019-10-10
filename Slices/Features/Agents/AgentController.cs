using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NeoFindR.Features.Agents
{
    public class AgentController : Controller
    {
        private readonly IMediator _mediator;

        public AgentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Reboot(Reboot.Command command)
        {
            await _mediator.Send(command);
            return Ok(); // or view or redirect etc.
        }

        [HttpGet]
        public async Task<IActionResult> View()
        {
            var model = await _mediator.Send(new View.Query());
            return View(model);
        }
    }
}