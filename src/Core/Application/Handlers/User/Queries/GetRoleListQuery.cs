using hshmedstats.Application.Dtos;
using hshmedstats.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hshmedstats.Application.Handlers.User.Queries
{
    public sealed class GetRoleListQuery : IRequest<List<RoleDto>>
    {
        public class GetRoleListQueryhandler : IRequestHandler<GetRoleListQuery, List<RoleDto>>
        {
            private readonly RoleManager<ApplicationRole> _RoleManager;

            public GetRoleListQueryhandler(RoleManager<ApplicationRole> roleManager)
            {
                _RoleManager = roleManager;
            }

            public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
            {
                var roles = await _RoleManager.Roles.ToListAsync();

                return roles.Select(r => new RoleDto
                {
                    Name = r.Name,
                }).ToList();
            }
        }
    }
}
