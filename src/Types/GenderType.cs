using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public enum GenderType
    {
        [Display(Name = "ΑΡΣΕΝΙΚΟ")]
        Male,
        [Display(Name = "ΘΗΛΥΚΟ")]
        Female,
    }
}
