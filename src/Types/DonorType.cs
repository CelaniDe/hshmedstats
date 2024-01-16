
using System.ComponentModel.DataAnnotations;

namespace Types
{
    public enum DonorType
    {
        [Display(Name = "Ταυτόσημος")]
        Identical,
        [Display(Name = "Πλήρως συμβατός εθελοντής")]
        FullyCompliantVolunteer,
        [Display(Name = "Απλοταυτόσημος")]
        SingleIdentical,
        [Display(Name = "Άλλος")]
        Other
    }
}
