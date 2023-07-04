using BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType;
using BLCLicenseManagement.Application.Features.Users;
using BLCLicenseManagement.Application.Features.Users.Commandes.DeleteUser;
using BLCLicenseManagement.Application.Features.Users.Commandes.UpdateUser;
using BLCLicenseManagement.Application.Features.Users.Queries.GetAllUsers;
using BLCLicenseManagement.Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLCLicenseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            var users = await _mediator.Send(new GetUserQuery());
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> CreateAsync([FromBody] UserDto userDto)
        {
            var user = await _mediator.Send(new CreateUserCommand(userDto));
            return Created("Get", user);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EditAsync([FromBody] UserDto userDto)
        {
            await _mediator.Send(new UpdateUserCommand(userDto));
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _mediator.Send(new DeleteUserByIdCommand(id));
            return NoContent();
        }
    }
}
