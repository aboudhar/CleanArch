using BLCLicenseManagement.Application.Features.BLCLicense.Commandes;
using BLCLicenseManagement.Application.Features.BLCLicense.Commandes.CreateLicense;
using BLCLicenseManagement.Application.Features.BLCLicense.Commandes.UpdateLicense;
using BLCLicenseManagement.Application.Features.BLCLicense.Queries;
using BLCLicenseManagement.Application.Features.BLCLicense.Queries.GetAllBLCLicenses;
using BLCLicenseManagement.Application.Features.BLCLicense.Queries.GetBLCLicensesById;
using BLCLicenseManagement.Application.Features.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLCLicenseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLCLicenseController : ControllerBase
    {
        readonly IMediator _mediator;
        public BLCLicenseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BLCLicenseController>
        [HttpGet]
        public async Task<List<LicenseDtoQuery>> Get()
        {
            var licenses = await _mediator.Send(new GetLicensesQuery());
            return licenses;
        }

        // GET api/<BLCLicenseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenseDtoQuery>> Get(int id)
        {
            var license = await _mediator.Send(new GetLicenseByIdQuery(id));
            return Ok(license);
        }

        // POST api/<BLCLicenseController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> CreateAsync([FromBody] LicenseDtoCommand licenseDtoCommand)
        {
            await _mediator.Send(new CreateLicenseCommand(licenseDtoCommand));
            return Created("Get", licenseDtoCommand);
        }

        // PUT api/<BLCLicenseController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditAsync([FromBody] LicenseDtoCommand licenseDtoCommand)
        {
            await _mediator.Send(new UpdateLicenseCommand(licenseDtoCommand));
            return NoContent();
        }

        // DELETE api/<BLCLicenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
