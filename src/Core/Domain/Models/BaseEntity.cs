using System;

namespace hshmedstats.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
    }
}
