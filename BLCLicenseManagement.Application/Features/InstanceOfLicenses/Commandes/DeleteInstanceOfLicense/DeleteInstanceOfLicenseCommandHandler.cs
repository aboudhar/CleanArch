using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using MediatR;

namespace BLCLicenseManagement.Application.Features.InstanceOfLicenses.Commandes.DeleteInstanceOfLicense
{
    public class DeleteInstanceOfLicenseCommandHandler : IRequestHandler<DeleteInstanceOfLicenseCommand>
    {
        private readonly IInstanceOfLicenseRepository _instanceOfLicenseRepository;
        public DeleteInstanceOfLicenseCommandHandler(IInstanceOfLicenseRepository instanceOfLicenseRepository)
        {
            _instanceOfLicenseRepository = instanceOfLicenseRepository;
        }
        public async Task Handle(DeleteInstanceOfLicenseCommand request, CancellationToken cancellationToken)
        {
            var instance = await _instanceOfLicenseRepository.GetByIdAsync(request.id);
            if (instance == null)
            {
                throw new NotFoundException(nameof(instance), request.id);
            }

            await _instanceOfLicenseRepository.DeleteAsync(instance);
        }
    }
}
