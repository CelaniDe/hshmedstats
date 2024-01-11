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

namespace hshmedstats.Application.Handlers.User.Queries
{
    public sealed record GetUserListQuery :IRequest<List<UserDto>>;
    public sealed class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        public GetUserListQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _UserManager = userManager;
        }

        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var usersDb = await _UserManager.Users.ToListAsync();

            var users = usersDb.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Username = u.UserName,
                Role = _UserManager.GetRolesAsync(u).Result.FirstOrDefault()
            }).ToList();

            return users;
        }
    }
}
