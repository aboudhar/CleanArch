using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using BLCLicenseManagement.Domain;
using MediatR;

namespace BLCLicenseManagement.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.id);
            }
            return _mapper.Map<UserDto>(user);

        }
    }
}
