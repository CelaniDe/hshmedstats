using System.ComponentModel.DataAnnotations;

namespace Types
{
    public enum TmaDiseaseType
    {
        [Display(Name = "Οξεία λευχαιμία")]
        AcuteLeukemia,
        [Display(Name = "Μυελοΐνωση")]
        Myelofibrosis,
        [Display(Name = "Μυελοδυσπλαστικό σύνδρομο")]
        MyelodysplasticSyndrome,
        [Display(Name = "Άλλη")]
        Other
    }
}
