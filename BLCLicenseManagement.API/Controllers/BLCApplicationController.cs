using BLCLicenseManagement.Application.Features.BLCApplications;
using BLCLicenseManagement.Application.Features.BLCApplications.Commands.CreateBLCApplication;
using BLCLicenseManagement.Application.Features.BLCApplications.Commands.DeleteBLCApplication;
using BLCLicenseManagement.Application.Features.BLCApplications.Commands.UpdateBLCApplication;
using BLCLicenseManagement.Application.Features.BLCApplications.Queries.GetAllBLCApplications;
using BLCLicenseManagement.Application.Features.BLCApplications.Queries.GetBLCApplicationsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLCLicenseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLCApplicationController : ControllerBase
    {

        readonly IMediator _mediator;
        public BLCApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BLCApplicationController>
        [HttpGet]
        public async Task<List<BLCApplicationDto>> Get()
        {
            var applications = await _mediator.Send(new GetBLCApplicationsQuery());
            return applications;
        }

        // GET api/<BLCApplicationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLCApplicationDto>> Get(int id)
        {
            var application = await _mediator.Send(new GetBLCApplicationsByIdQuery(id));
            return Ok(application);
        }

        // POST api/<BLCApplicationController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BLCApplicationDto>> CreateAsync([FromBody] BLCApplicationDto applicationDto)
        {
            var application = await _mediator.Send(new CreateBLCApplicationCommand(applicationDto));
            return Created("Get", application);
        }

        // PUT api/<BLCApplicationController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditAsync([FromBody] BLCApplicationDto applicationDto)
        {
            await _mediator.Send(new UpdateBLCApplicationCommand(applicationDto));
            return NoContent();
        }

        // DELETE api/<BLCApplicationController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _mediator.Send(new DeleteBLCApplicationCommand(id));
            return NoContent();
        }
    }
}
