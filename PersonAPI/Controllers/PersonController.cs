using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.Features.People.Commands;
using PersonDirectory.Application.Features.People.Queries;
using PersonDirectory.Application.Features.Reports.Queries;
using PersonDirectory.Presentation.WebApi.ActionFilters;
using System.Threading;
using System.Threading.Tasks;

namespace PersonRegister.WebApi.Controllers
{
    [Route("api/[controller]")]
    [InvalidModelActionFilter]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;
        public PersonController(IMediator mediator) => this.mediator = mediator;

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] AddPersonCommand request,CancellationToken token)
        {
            var result = await mediator.Send(request,token);
            return CreatedAtRoute("GetPersonById", new { id = result }, result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdatePersonCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeletePersonCommand request, CancellationToken token)
        {
            await mediator.Send(request,token);
            return NoContent();
        }
        [HttpPost("UploadPicture")]
        public async Task<IActionResult> AddEditPicture([FromForm] AddPersonPictureCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost("Relation")]
        public async Task<IActionResult> AddRelation([FromForm] AddPersonRelationCommand request)
        {
            await mediator.Send(request);
            return Created("",request);
        }
        [HttpDelete("Relation")]
        public async Task<IActionResult> RemoveRelation([FromForm] DeletePersonRelationCommand request)
        {
            await mediator.Send(request);
            return NoContent();
        }
        [HttpGet("{id}",Name ="GetPersonById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new GetPersonByIdQuery { Id=id});
            return Ok(result);
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> GetPeopleFiltered([FromQuery] GetPeopleFilteredQuery request)
        {
            var result = await mediator.Send(request);

            Response.Headers.Add("CurrentPage", result.CurrentPage.ToString());
            Response.Headers.Add("PageSize", result.PageSize.ToString());

            Response.Headers.Add("TotalPages", result.TotalPages.ToString());
            Response.Headers.Add("TotalCount", result.TotalCount.ToString());

            return Ok(result.Items);
        }
        [HttpGet("QuickFilter")]
        public async Task<IActionResult> GetPeopleFilteredQuick([FromQuery] GetPeopleFilteredQuickQuery request)
        {
            var result = await mediator.Send(request);

            Response.Headers.Add("CurrentPage", result.CurrentPage.ToString());
            Response.Headers.Add("PageSize", result.PageSize.ToString());

            Response.Headers.Add("TotalPages", result.TotalPages.ToString());
            Response.Headers.Add("TotalCount", result.TotalCount.ToString());

            return Ok(result.Items);
        }
        [HttpGet("PeopleReport")]
        public async Task<IActionResult> PeopleReportWithRelationTypesGroupedCount()
        {
            var result = await mediator.Send(new GetPeopleWIthRelatedTypesCountQuery());
            return Ok(result);
        }




    }
}
