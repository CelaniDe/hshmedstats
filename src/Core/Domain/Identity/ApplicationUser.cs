using Microsoft.AspNetCore.Identity;
using System;


namespace hshmedstats.Domain
{
    public class ApplicationUser : IdentityUser<int>, IHistoryEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
