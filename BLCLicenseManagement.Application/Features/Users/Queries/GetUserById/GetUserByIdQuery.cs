using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(int id) : IRequest<UserDto>;
  
}
