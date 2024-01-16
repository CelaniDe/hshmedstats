using System.ComponentModel.DataAnnotations;

namespace Types
{
    public enum CMVSeropositivityType
    {
        [Display(Name = "Θετικός / θετικός")]
        PositivePositive,
        [Display(Name = "Αρνητικός / θετικός")]
        NegativePositive,
        [Display(Name = "Θετικός / αρνητικός")]
        PositiveNegative,
        [Display(Name = "Αρνητικός / αρνητικός")]
        NegativeNegative
    }
}
