using AutoMapper;
using hshmedstats.Application.Dtos;
using hshmedstats.Application.Interfaces;
using hshmedstats.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace hshmedstats.Application.Handlers.User.Queries
{
    public sealed class GetUserQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
        {
            private readonly UserManager<ApplicationUser> _UserManager;
            private readonly IHshDbContext _DbContext;
            private readonly IMapper _Mapper;

            public GetUserQueryHandler(UserManager<ApplicationUser> userManager, IHshDbContext dbContext, IMapper mapper)
            {
                _UserManager = userManager;
                _DbContext = dbContext;
                _Mapper = mapper;
            }

            public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _DbContext.ApplicationUsers().FirstOrDefaultAsync(u => u.Id == request.UserId);

                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = _UserManager.GetRolesAsync(user).Result.SingleOrDefault(),
                };
            }
        }
    }
}
