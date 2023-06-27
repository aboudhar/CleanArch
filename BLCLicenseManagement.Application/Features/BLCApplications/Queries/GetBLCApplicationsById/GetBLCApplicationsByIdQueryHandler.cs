using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Queries.GetBLCApplicationsById
{
    public class GetBLCApplicationsByIdQueryHandler : IRequestHandler<GetBLCApplicationsByIdQuery, BLCApplicationDto>
    {
        private readonly IMapper _mapper;
        private readonly IBLCApplicationRepository _bLCApplicationRepository;
        public GetBLCApplicationsByIdQueryHandler(IMapper mapper, IBLCApplicationRepository bLCApplicationRepository)
        {
            _mapper = mapper;
            _bLCApplicationRepository = bLCApplicationRepository;
        }

        public async Task<BLCApplicationDto> Handle(GetBLCApplicationsByIdQuery request, CancellationToken cancellationToken)
        {
            var aplication = await _bLCApplicationRepository.GetByIdAsync(request.id);
            if (aplication == null)
            {
                throw new NotFoundException(nameof(aplication), request.id);
            }
            return _mapper.Map<BLCApplicationDto>(aplication);
        }
    }
}
