
using System.ComponentModel.DataAnnotations;

namespace Types
{
    public enum DiagnosisType
    {
        [Display(Name = "TTP")]
        TTP,
        [Display(Name = "HUS")]
        HUS,
        [Display(Name = "sTMA")]
        sTMA,
        [Display(Name = "TA-TMA")]
        TaTma
    }
}
