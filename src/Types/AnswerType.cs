using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public enum AnswerType
    {
        [Display(Name = "ΑΓΝΩΣΤΟ")]
        None,
        [Display(Name = "ΝΑΙ")]
        Yes,
        [Display(Name = "ΌΧΙ")]
        No
    }
}
