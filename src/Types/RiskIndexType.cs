using System.ComponentModel.DataAnnotations;


namespace Types
{
    public enum RiskIndexType
    {
        [Display(Name = "Low")]
        Low,
        [Display(Name = "Intermediate")]
        Intermediate,
        [Display(Name = "High")]
        High,
        [Display(Name = "Very High")]
        VeryHigh
    }
}
