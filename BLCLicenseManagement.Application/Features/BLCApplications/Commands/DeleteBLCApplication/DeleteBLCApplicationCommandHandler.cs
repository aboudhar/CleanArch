using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using MediatR;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Commands.DeleteBLCApplication
{
    public class DeleteBLCApplicationCommandHandler : IRequestHandler<DeleteBLCApplicationCommand>
    {
        private readonly IBLCApplicationRepository _bLCApplicationRepository;
        public DeleteBLCApplicationCommandHandler(IBLCApplicationRepository bLCApplicationRepository)
        {
            _bLCApplicationRepository = bLCApplicationRepository;
        }

        public async Task Handle(DeleteBLCApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _bLCApplicationRepository.GetByIdAsync(request.Id);
            if (application == null)
            {
                throw new NotFoundException(nameof(application), request.Id);
            }

            await _bLCApplicationRepository.DeleteAsync(application);
        }
    }
}
