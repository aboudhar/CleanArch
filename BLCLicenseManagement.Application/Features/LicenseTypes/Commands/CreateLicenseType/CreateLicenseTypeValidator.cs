using BLCLicenseManagement.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType
{
    public class CreateLicenseTypeValidator:AbstractValidator<CreateLicenseTypeCommand>
    {
       private readonly ILicenseTypeRepository _licenseTypeRepository;
        public CreateLicenseTypeValidator(ILicenseTypeRepository licenseTypeRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(69).WithMessage("{PropertyName} must not exceed 69 characters.");
            RuleFor(p=>p)
                .MustAsync(LicenseTypeUnique).WithMessage("A License Type with the same name already exists.");
            this._licenseTypeRepository = licenseTypeRepository;
        }
        private async Task<bool> LicenseTypeUnique(CreateLicenseTypeCommand command, CancellationToken token)
        {
           return await _licenseTypeRepository.IsUniqueName(command.Name);
        }
    }
}
