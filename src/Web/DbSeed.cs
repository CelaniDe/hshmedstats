using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using hshmedstats.Domain;
using hshmedstats.Persistence;
using System.Linq;
using hshmedstats.Application.Global;

namespace hshmedstats.Web
{
    public class DbSeed
    {
        public static async Task SeedAsync(HshDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                await roleManager.CreateAsync(new ApplicationRole { Name = Roles.Admin });
                await roleManager.CreateAsync(new ApplicationRole { Name = Roles.Doctor });
            }

            if (!context.Users.Any())
            {
                var admin = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@exis.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                };
                var result = await userManager.CreateAsync(admin, "Admin123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Roles.Admin);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
