using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace hshmedstats.Application.Dtos
{
    public interface IBaseDto
    {
        public int? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }
        public void SetValidationResult(ValidationResult result);
        public bool HasErrors { get; }
    }
}
