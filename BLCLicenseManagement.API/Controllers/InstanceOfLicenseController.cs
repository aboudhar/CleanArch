using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.CreateInstanceOfLicense;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.DeleteInstanceOfLicense;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.UpdateInstanceOfLicense;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries.GetAllInstanceOfLicenses;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries.GetInstanceOfLicenseById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLCLicenseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstanceOfLicenseController : ControllerBase
    {
        readonly IMediator _mediator;
        public InstanceOfLicenseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<InstanceOfLicenseController>
        [HttpGet]
        public async Task<List<InstanceOfLicenseQueryDto>> Get()
        {
            var instances = await _mediator.Send(new GetInstanceOfLicensesQuery());
            return instances;
        }

        // GET api/<InstanceOfLicenseController>/5
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstanceOfLicenseQueryDto>> Get(int id)
        {
            var instance = await _mediator.Send(new GetInstanceOfLicenseQuery(id));
            return Ok(instance);
        }
        // POST api/<InstanceOfLicenseController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<InstanceOfLicenseCommandDto>> CreateAsync([FromBody] InstanceOfLicenseCommandDto instanceOfLicenseQueryDto)
        {
            var instanceOfLicense = await _mediator.Send(new CreateInstanceOfLicenseCommand(instanceOfLicenseQueryDto));
            return Created("Get", instanceOfLicense);
        }
        // PUT api/<InstanceOfLicenseController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditAsync([FromBody] InstanceOfLicenseCommandDto instanceOfLicenseCommandDto)
        {
            await _mediator.Send(new UpdateInstanceOfLicenseCommand(instanceOfLicenseCommandDto));
            return NoContent();
        }

        // DELETE api/<InstanceOfLicenseController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _mediator.Send(new DeleteInstanceOfLicenseCommand(id));
            return NoContent();
        }
    }
}
