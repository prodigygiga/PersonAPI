using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.Features.People.Commands;
using System.Threading.Tasks;

namespace PersonRegister.WebApi.Controllers
{
    [Route("api/[controller]")]

    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;
        public PersonController(IMediator mediator) => this.mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddPersonCommand request)
        {

            await mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdatePersonCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeletePersonCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }



    }
}
