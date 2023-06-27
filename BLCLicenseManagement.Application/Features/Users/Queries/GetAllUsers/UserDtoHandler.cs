using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Persistence;
using MediatR;

namespace BLCLicenseManagement.Application.Features.Users.Queries.GetAllUsers
{
    public class UserDtoHandler : IRequestHandler<GetUserQuery, List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        public UserDtoHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            this.userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
