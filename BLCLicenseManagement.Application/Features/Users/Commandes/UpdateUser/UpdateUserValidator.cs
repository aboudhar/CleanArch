using BLCLicenseManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace BLCLicenseManagement.Application.Features.Users.Commandes.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserValidator(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            RuleFor(u => u.UserDto.id).NotEmpty().NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.UserDto)
                .MustAsync(EmailUnique).WithMessage("A User Type with the same Email already exists.");
        }

        private async Task<bool> EmailUnique(UserDto user, CancellationToken arg2)
        {
            return await _userRepository.IsUniqueEmailUpdate(user);
        }
    }
}
