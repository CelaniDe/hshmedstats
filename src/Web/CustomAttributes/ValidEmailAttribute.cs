
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace hshmedstats.Web.CustomAttributes
{
    public class ValidEmailAttribute : ValidationAttribute
    {
        private readonly EmailAddressAttribute emailAddressAttribute = new EmailAddressAttribute();
        public override bool IsValid(object value)
        {
            return value == null ? true : value.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries).All(e => emailAddressAttribute.IsValid(e));
        }
    }
}
