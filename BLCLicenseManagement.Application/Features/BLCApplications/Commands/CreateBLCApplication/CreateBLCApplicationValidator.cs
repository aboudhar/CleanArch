using BLCLicenseManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace BLCLicenseManagement.Application.Features.BLCApplications.Commands.CreateBLCApplication
{
    public class CreateBLCApplicationValidator : AbstractValidator<CreateBLCApplicationCommand>
    {
        private readonly IBLCApplicationRepository _bLCApplicationRepository;
        public CreateBLCApplicationValidator(IBLCApplicationRepository bLCApplicationRepository)
        {
            RuleFor(a => a.blcApplicationDto.Name).NotEmpty().NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(69).WithMessage("{PropertyName} must not exceed 69 characters.")
                .MustAsync(UserNameUnique).WithMessage("Aa Application with the same Name already exists.");
            _bLCApplicationRepository = bLCApplicationRepository;
        }

        private async Task<bool> UserNameUnique(string name, CancellationToken arg2)
        {
            return await _bLCApplicationRepository.IsUniqueName(name);
        }
    }
}
