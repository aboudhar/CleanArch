using BLCLicenseManagement.Application.Features.LicenseType.Queries.GetAllLicenseTypes;
using BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType;
using BLCLicenseManagement.Application.Features.LicenseTypes.Commands.DeleteLicenseType;
using BLCLicenseManagement.Application.Features.LicenseTypes.Commands.UpdateLicenseType;
using BLCLicenseManagement.Application.Features.LicenseTypes.Queries;
using BLCLicenseManagement.Application.Features.LicenseTypes.Queries.GetSingleLicenseType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLCLicenseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LicenseTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LicenseTypesController>
        [HttpGet]
        public async Task<List<LicenseTypeDto>> Get()
        {
            var licenseTypes = await _mediator.Send(new GetLicenseTypeQuery());
            return licenseTypes;
        }

        // GET api/<LicenseTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenseTypeDto>> Get(int id)
        {
            var licenseType = await _mediator.Send(new GetSingleLicenseTypeQuery(id));
            return Ok(licenseType);
        }

        // POST api/<LicenseTypesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateLicenseTypeCommand licenseType)
        {
            await _mediator.Send(licenseType);
            return CreatedAtAction("Get", new { Name = licenseType.Name }, licenseType);
        }

        // PUT api/<LicenseTypesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateLicenseTypeCommand updateLicenseTypeCommand)
        {
            await _mediator.Send(updateLicenseTypeCommand);
            return NoContent();
        }

        // DELETE api/<LicenseTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var licenseType = await _mediator.Send(new DeleteLicenseTypeCommand { Id = id });
            return Ok(licenseType);
        }
    }
}
