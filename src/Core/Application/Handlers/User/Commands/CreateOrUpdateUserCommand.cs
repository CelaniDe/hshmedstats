using FluentValidation;
using hshmedstats.Application.Dtos;
using hshmedstats.Application.Interfaces;
using hshmedstats.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace hshmedstats.Application.Handlers.User.Commands
{
    public sealed class CreateOrUpdateUserCommand : IRequest<UserDto>
    {
        public UserDto User { get; set; }

        public sealed class CreateOrUpdateUserCommandHandler : HRequest<UserDto>, IRequestHandler<CreateOrUpdateUserCommand, UserDto>
        {
            private readonly UserManager<ApplicationUser> _UserManager;

            public CreateOrUpdateUserCommandHandler(UserManager<ApplicationUser> userManager, IHshDbContext dbContext,
                IValidator<UserDto> validator) : base(dbContext, null, validator)
            {
                _UserManager = userManager;
            }

            public async Task<UserDto> Handle(CreateOrUpdateUserCommand request, CancellationToken cancellationToken)
            {
                if (request.User != null)
                {
                    var validationResult = await Validate(request.User);

                    if (!validationResult) return request.User;

                    if (request.User.Id == null)
                    {
                        var appUser = new ApplicationUser
                        {
                            UserName = request.User.Username,
                            Email = request.User.Email,
                            PhoneNumber = request.User.PhoneNumber,
                            FirstName = request.User.FirstName,
                            LastName = request.User.LastName,
                        };

                        var result = await _UserManager.CreateAsync(appUser, request.User.Password);

                        if (result.Succeeded)
                        {
                            await _UserManager.AddToRoleAsync(appUser, request.User.Role);
                            await _UserManager.UpdateAsync(appUser);
                            return request.User;
                        }
                        else
                        {
                            request.User.Errors.Add("UserName", new List<string> { result.Errors.First().Description });
                            return request.User;
                        }
                    }
                    else
                    {
                        var appUser = await _DbContext.ApplicationUsers().FirstOrDefaultAsync(u => u.Id == request.User.Id);

                        appUser.UserName = request.User.Username;
                        appUser.Email = request.User.Email;
                        appUser.PhoneNumber = request.User.PhoneNumber;
                        appUser.FirstName = request.User.FirstName;
                        appUser.LastName = request.User.LastName;

                        if (request.User.Password != null)
                            appUser.PasswordHash = _UserManager.PasswordHasher.HashPassword(appUser, request.User.Password);

                        await _UserManager.UpdateAsync(appUser);

                        var currentRole = (await _UserManager.GetRolesAsync(appUser)).FirstOrDefault();
                        if (currentRole != request.User.Role)
                        {
                            await _UserManager.RemoveFromRoleAsync(appUser, currentRole);
                            await _UserManager.AddToRoleAsync(appUser, request.User.Role);
                        }
                    }
                }

                return request.User;
            }
        }
    }
}
