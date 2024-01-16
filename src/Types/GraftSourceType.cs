
using System.ComponentModel.DataAnnotations;

namespace Types
{
    public enum GraftSourceType
    {
        [Display(Name = "Μυελός οστών")]
        BoneMarrow,
        [Display(Name = "PBMCs")]
        PBMCs,
        [Display(Name = "Ομφαλιοπλακουντικό αίμα")]
        UmbilicalCordBlood,
    }
}
