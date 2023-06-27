using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries;
using BLCLicenseManagement.Application.Features.InstanceOfLicenses.Queries.GetAllInstanceOfLicenses;
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InstanceOfLicenseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InstanceOfLicenseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstanceOfLicenseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
