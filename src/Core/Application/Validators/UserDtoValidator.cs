using FluentValidation;
using hshmedstats.Application.Dtos;

namespace hshmedstats.Application.Validators
{
    public sealed class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            
        }
    }
}
