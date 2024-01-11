using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hshmedstats.Application.Dtos
{
    public class BaseDto : IBaseDto
    {
        public int? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; } = new();

        public bool HasErrors { get { return Errors.Count > 0; } }
        public void SetValidationResult(ValidationResult result)
        {
            Errors = result.Errors.GroupBy(e => e.PropertyName).ToDictionary(e => e.Key, e => e.Select(q => q.ErrorMessage).ToList());
        }
    }
}

