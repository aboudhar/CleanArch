using BLCLicenseManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace BLCLicenseManagement.Application.Features.LicenseTypes.Commands.CreateLicenseType
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(p => p.user.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(69).WithMessage("{PropertyName} must not exceed 69 characters.");
            RuleFor(u => u.user.Email).NotEmpty().NotNull()
                .MustAsync(UserEmailUnique).WithMessage("A User with the same Email already exists.");
        }

        private async Task<bool> UserEmailUnique(string email, CancellationToken arg2)
        {
            return await _userRepository.IsUniqueEmail(email);

        }
    }
}
