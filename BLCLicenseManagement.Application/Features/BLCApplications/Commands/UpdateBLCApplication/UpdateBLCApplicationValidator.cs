using BLCLicenseManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Commands.UpdateBLCApplication
{
    public class UpdateBLCApplicationValidator : AbstractValidator<UpdateBLCApplicationCommand>
    {
        private readonly IBLCApplicationRepository _bLCApplicationRepository;
        public UpdateBLCApplicationValidator(IBLCApplicationRepository bLCApplicationRepository)
        {
            _bLCApplicationRepository = bLCApplicationRepository;
            RuleFor(u => u.BLCApplicationDto.Id).NotEmpty().NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.BLCApplicationDto)
                .MustAsync(NameUnique).WithMessage("An Application with the same Name already exists.");
        }

        private async Task<bool> NameUnique(BLCApplicationDto applicationDto, CancellationToken arg2)
        {
            return await _bLCApplicationRepository.IsUniqueNameUpdate(applicationDto);
        }
    }
}
