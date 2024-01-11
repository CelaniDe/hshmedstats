using hshmedstats.Domain;
using Microsoft.EntityFrameworkCore;

namespace hshmedstats.Application.Interfaces
{
    public interface IHshDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers();
        public int UserId { get; set; }
    }
}
