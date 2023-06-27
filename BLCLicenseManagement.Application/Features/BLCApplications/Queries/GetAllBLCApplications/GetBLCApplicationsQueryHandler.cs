using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Persistence;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Queries.GetAllBLCApplications
{
    public class GetBLCApplicationsQueryHandler : IRequestHandler<GetBLCApplicationsQuery, List<BLCApplicationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBLCApplicationRepository _bLCApplicationRepository;
        public GetBLCApplicationsQueryHandler(IMapper mapper, IBLCApplicationRepository bLCApplicationRepository)
        {
            _mapper = mapper;
            this._bLCApplicationRepository = bLCApplicationRepository;
        }
        async Task<List<BLCApplicationDto>> IRequestHandler<GetBLCApplicationsQuery, List<BLCApplicationDto>>.Handle(GetBLCApplicationsQuery request, CancellationToken cancellationToken)
        {
            var blcApplications = await _bLCApplicationRepository.GetAllAsync();
            return _mapper.Map<List<BLCApplicationDto>>(blcApplications);
        }
    }
}
