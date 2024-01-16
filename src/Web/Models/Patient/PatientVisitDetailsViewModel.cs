using System;
using Types;

namespace hshmedstats.Web.Models.Patient
{
    public class PatientVisitDetailsViewModel
    {
        public PatientVisitDetailsViewModel()
        {
            

        }


        public PatientBloodTestViewModel PatientBloodTest { get; set; } = new();

        public PatientExcusedConductViewModel PatientExcusedConduct { get; set; } = new();
    }

    public class PatientBloodTestViewModel
    {
        public PatientBloodTestViewModel()
        {
            
        }

        public string SampleDate { get; set; }
        public BloodType BloodType { get; set; }
        public decimal Hemoglobin { get; set; }
        public decimal MCV { get; set; }
        public int? Reticulocytes { get; set; }
        public decimal Platelets { get; set; }
        public decimal? Haptoglobulin { get; set; }
        public decimal Schistocytes { get; set; }
        public decimal Creatine { get; set; }
        public bool BloodDialysis { get; set; }
        public string? BloodDialysisDetails { get; set; }
        public decimal? PT { get; set; }
        public decimal? APTT { get; set; }
        public decimal INR { get; set; }
        public decimal Fibrous { get; set; }
        public AnswerType ADAMTS13Deficiency { get; set; }
        public decimal? DetermineADAMTS13Activity { get; set; }
        public bool GeneticTesting { get; set; }
        public string? GeneticTestingDetails { get; set; }
        public bool StorageOfBiologicalMaterial { get; set; }
        public string? StorageOfBiologicalMaterialDetails { get; set; }
        public bool Pregnancy { get; set; }
        public bool Puerperium { get; set; }
        public bool CnsInsult { get; set; }
        public bool VaccinationsWithin30DaysOfTheEpisode { get; set; }
        public bool ArterialHypertension { get; set; }
        public int? SystolicBPLevels { get; set; }
        public int? DiastolicBPLevels { get; set; }
        public int? AntihypertensiveDrugs { get; set; }
    }

    public class PatientExcusedConductViewModel
    {
        public PatientExcusedConductViewModel()
        {
            
        }

        public bool Antiplatelet { get; set; }
        public DateTime? AntiplateletDateFrom { get; set; }
        public DateTime? AntiplateletDateTo { get; set; }
        public bool AntiplatelContinues { get; set; }

        public bool Anticoagulants { get; set; }
        public DateTime? AnticoagulantsDateFrom { get; set; }
        public DateTime? AnticoagulantsDateTo { get; set; }
        public bool AnticoagulantsContinues { get; set; }

        public bool LipidLoweringAgents { get; set; }
        public DateTime? LipidLoweringAgentsDateFrom { get; set; }
        public DateTime? LipidLoweringAgentsDateTo { get; set; }
        public bool LipidLoweringAgentsContinues { get; set; }

        public bool DiureticsAgents { get; set; }
        public DateTime? DiureticsDateFrom { get; set; }
        public DateTime? DiureticsDateTo { get; set; }
        public bool DiureticsContinues { get; set; }

        public bool Corticosteroids { get; set; }
        public DateTime? CorticosteroidsDateFrom { get; set; }
        public DateTime? CorticosteroidsDateTo { get; set; }
        public bool CorticosteroidsContinues { get; set; }

        public bool EstrogenAsReplacement { get; set; }
        public DateTime? EstrogenAsReplacementDateFrom { get; set; }
        public DateTime? EstrogenAsReplacementDateTo { get; set; }
        public bool EstrogenAsReplacementContinues { get; set; }

        public bool OtherHormoneTherapy { get; set; }
        public DateTime? OtherHormoneTherapyDateFrom { get; set; }
        public DateTime? OtherHormoneTherapyDateTo { get; set; }
        public bool OtherHormoneTherapyContinues { get; set; }

        public bool ProtonPumpInhibitors { get; set; }
        public DateTime? ProtonPumpInhibitorsDateFrom { get; set; }
        public DateTime? ProtonPumpInhibitorsDateTo { get; set; }
        public bool ProtonPumpInhibitorsContinues { get; set; }

        public bool Antihypertensives { get; set; }
        public DateTime? AntihypertensivesDateFrom { get; set; }
        public DateTime? AntihypertensivesDateTo { get; set; }
        public bool AntihypertensivesContinues { get; set; }

        public bool Antiarrhythmics { get; set; }
        public DateTime? AntiarrhythmicsDateFrom { get; set; }
        public DateTime? AntiarrhythmicsDateTo { get; set; }
        public bool AntiarrhythmicsContinues { get; set; }

        public bool InhaledBronchodilators { get; set; }
        public DateTime? InhaledBronchodilatorsDateFrom { get; set; }
        public DateTime? InhaledBronchodilatorsDateTo { get; set; }
        public bool InhaledBronchodilatorsContinues { get; set; }

        public bool Antidepressants { get; set; }
        public DateTime? AntidepressantsDateFrom { get; set; }
        public DateTime? AntidepressantsDateTo { get; set; }
        public bool AntidepressantsContinues { get; set; }

        public bool Antidiabetic { get; set; }
        public DateTime? AntidiabeticDateFrom { get; set; }
        public DateTime? AntidiabeticDateTo { get; set; }
        public bool AntidiabeticContinues { get; set; }

        public bool Radiotherapy { get; set; }
        public DateTime? RadiotherapyDateFrom { get; set; }
        public DateTime? RadiotherapyDateTo { get; set; }
        public bool RadiotherapyContinues { get; set; }

        public bool Immunosuppressants { get; set; }
        public DateTime? ImmunosuppressantsDateFrom { get; set; }
        public DateTime? ImmunosuppressantsDateTo { get; set; }
        public bool ImmunosuppressantsContinues { get; set; }


        public string? Other { get; set; }
    }
}
