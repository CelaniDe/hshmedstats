using hshmedstats.Application.Helpers;
using System;
using System.Collections.Generic;
using Types;

namespace hshmedstats.Web.Models.Patient
{
    public class PatientViewModel
    {
        public PatientViewModel()
        {
            PatientVisits = new List<PatientVisitViewModel>
            {
                new PatientVisitViewModel
                {
                    Id = 1,
                    VisitDate = DateTime.Now.ToString(Format.DATE_FORMAT)
                },
                  new PatientVisitViewModel
                {
                    Id = 2,
                    VisitDate = DateTime.Now.ToString(Format.DATE_FORMAT)
                }
            };
        }



        public PatientDetailsViewModel PatientDetails { get; set; } = new();
        public PatientHistoryViewModel PatientHistory { get; set; } = new();
        public List<PatientVisitViewModel> PatientVisits { get; set; } = new();
        public PatientDiagnosyViewModel PatientDiagnosy { get; set; } = new();
    }


    public class PatientDetailsViewModel
    {
        public PatientDetailsViewModel()
        {
            CreatedAt = DateTime.Now.ToString(Format.DATE_FORMAT);
        }

        public int? Id { get;set; }
        public string Amka { get; set; }
        public string VisitDate { get; set; }
        public string CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Address { get; set; }
        public int Gender { get; set; }
        public string DiagnosisDate { get; set; }
        public int DiagnosisAge { get; set; }
        public string Job { get; set; }
        public int FamilyDisorderAnswer { get; set; }
        public string? FamilyDisorderAnswerDetails { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get; set; }
        public int KarnofskyPerformanceStatus { get; set; }
        public int ClinicId { get; set; }
    }

    public class PatientHistoryViewModel
    {
        public PatientHistoryViewModel()
        {
            
        }

        public bool PreviousEpisodeOfThromboticMicroangiopathy { get; set; }
        public string? ThromboticMicroangiopathyDetails { get; set; }
        public bool HeartDisease { get; set; }
        public string? HeartDiseaseDetails { get; set; }
        public bool RespiratoryDisease { get; set; }
        public string? RespiratoryDiseaseDetails { get; set; }
        public bool EndocrineDisease { get; set; }
        public string? EndocrineDiseaseDetails { get; set; }
        public bool KidneyDisease { get; set; }
        public string? KidneyDiseaseDetails { get; set; }
        public bool NeoplasticDisease { get; set; }
        public string? NeoplasticDiseaseDetails { get; set; }
        public bool AutoimmuneDisease { get; set; }
        public string? AutoimmuneDiseaseDetails { get; set; }
        public bool Transplant { get; set; }
        public string? TransplantDetails { get; set; }
    }

    public class PatientVisitViewModel
    {
        public PatientVisitViewModel()
        {
            
        }

        public int? Id { get; set; }
        public string VisitDate { get; set; }
    }

    public class PatientDiagnosyViewModel
    {
        public PatientDiagnosyViewModel()
        {
            
        }

        public int DiagnosisType { get; set; }
        //TTP
        public int ADAMTS13Inhibitors { get; set; }
        public bool PlasmaInjection { get; set; }
        public string? PlasmaInjectionDetails { get; set; }
        public bool Caplacizumab { get; set; }
        public string? CaplacizumabDetails { get; set; }
        public string? ADAMT13ActivityLevel { get; set; }

        //Hus or sTMA
        public bool ComplementInhibitor { get; set; }
        public string? ComplementInhibitorDetails { get; set; }



        //TaTma
        public int DonorType { get; set; }
        public string? DonorTypeDetails { get; set; }
        public int PreparatoryScheme { get; set; }
        public string? PreparatorySchemeAcronym { get; set; }
        public bool WholeBodyRadiation { get; set; }
        public int TmaDisease { get; set; }
        public string? IdentifyDisease { get; set; }
        public int DiseaseRiskIndex { get; set; }
        public int HCTCI { get; set; }
        public int HCTCILinesTreatment { get; set; }
        public int CMVSeropositivityOfPatientDonor { get; set; }
        public int GraftSource { get; set; }
        public int? CD34Graft { get; set; }
        public string TransplantDate { get; set; }
        public string? GVHDProphylaxis { get; set; }
        public bool ImplantationOfPolymorphonuclears { get; set; }
        public string? ImplantationOfPolymorphonuclearsDetails { get; set; }
        public bool PlateletImplantation { get; set; }
        public string? PlateletImplantationDetails { get; set; }
        public bool SeriousInfections { get; set; }
        public bool SuccessfulOutcome { get; set; }
        public bool CMVViremia { get; set; }
        public bool CMVInfection { get; set; }
        public bool CMVTherapy { get; set; }
        public bool CMVTherapySuccessfulOutcome { get; set; }
        public bool EBVViremia { get; set; }
        public bool EBVLymphoma { get; set; }
        public bool EBVTherapy { get; set; }
        public bool EBVTherapySuccessfulOutcome { get; set; }
        public bool VOD { get; set; }
        public bool aGVHD { get; set; }
        public int? aGVHDGrade { get; set; }
        public bool CorticoDependentOrResistant { get; set; }
        public int? CorticoDependentOrResistantTreatmentLine { get; set; }
        public bool ChronicGVHD { get; set; }
        public int ChronicGVHDGrade { get; set; }
        public bool CalcineurinInhibitor { get; set; }
        public bool mTORInhibitor { get; set; }
        public bool Ruxolitinib { get; set; }
        public string? RuxolitinibDetails { get; set; }

        //General
        public string DiagnosisDate { get; set; }
        public AnswerType AddOnActivation { get; set; }
        public string? AddOnActivationDetails { get; set; }
        public decimal? LevelOfDiagnosis { get; set; }
        public bool CorticosisDosage { get; set; }
        public string? CorticosisDosageDetails { get; set; }
        public bool Plasmapheresis { get; set; }
        public string? PlasmapheresisDetails { get; set; }
        public bool PlasmapheresisAnswer { get; set; }
        public bool Rituximab { get; set; }
        public string? RituximabDetails { get; set; }
        public bool RituximabAnswer { get; set; }
        public string? OtherImmunoSuppression { get; set; }
        public bool LowMolecularWeightHeparin { get; set; }
        public string? LowMolecularWeightHeparinDetails { get; set; }
        public bool AntiplateletAgents { get; set; }
        public string? AntiplateletAgentsDetails { get; set; }
        public bool Recession { get; set; }
        public bool Death { get; set; }
        public DateTime DateOfLastFollowUp { get; set; }
        public string CauseOfDeath { get; set; }
        public string OtherComments { get; set; }
    }
}
