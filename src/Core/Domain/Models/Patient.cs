using System;
using Types;

namespace hshmedstats.Domain.Models
{
    public sealed class Patient:BaseEntity, IHistoryEntity
    {
        public string Amka { get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Address { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public int DiagnosisAge { get; set; }
        public string Job { get; set; }
        public AnswerType FamilyDisorderAnswer { get; set; }
        public string? FamilyDisorderAnswerDetails { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get; set; }

        public bool PreviousEpisodeOfThromboticMicroangiopathy { get; set; }
        public string ThromboticMicroangiopathyDetails { get; set; }
        public bool HeartDisease { get; set; }
        public string HeartDiseaseDetails { get; set; }
        public bool RespiratoryDisease { get; set; }
        public string RespiratoryDiseaseDetails { get; set; }
        public bool EndocrineDisease { get; set; }
        public string EndocrineDiseaseDetails { get; set; }
        public bool KidneyDisease { get; set; }
        public string KidneyDiseaseDetails { get; set; }
        public bool NeoplasticDisease { get; set; }
        public string NeoplasticDiseaseDetails { get; set; }
        public bool AutoimmuneDisease { get; set; }
        public string AutoimmuneDiseaseDetails { get; set; }
        public bool Transplant { get; set; }
        public string TransplantDetails { get; set; }


        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
