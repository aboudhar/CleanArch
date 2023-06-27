using AutoMapper;
using BLCLicenseManagement.Application.Contracts.Persistence;
using BLCLicenseManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.DeleteLicenseType
{
    public class DeleteLicenseTypeCommandHandler : IRequestHandler<DeleteLicenseTypeCommand, Unit>
    {
        public readonly ILicenseTypeRepository _licenseTypeRepository;
        public DeleteLicenseTypeCommandHandler( ILicenseTypeRepository licenseTypeRepository)
        {
            _licenseTypeRepository = licenseTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLicenseTypeCommand request, CancellationToken cancellationToken)
        {
            var licenseType =  await _licenseTypeRepository.GetByIdAsync(request.Id);
            if (licenseType == null)
            {
                throw new NotFoundException(nameof(LicenseType), request.Id);
            }
            await _licenseTypeRepository.DeleteAsync(licenseType);
            return Unit.Value;
        }
    }
}
