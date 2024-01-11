using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace hshmedstats.Application.Dtos
{
    public interface IBaseDto
    {
        public int? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }
        public void SetValidationResult(ValidationResult result);
        public bool HasErrors { get; }
    }
}
