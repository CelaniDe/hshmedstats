using System;
using Types;

namespace hshmedstats.Domain.Models
{
    public sealed class PatientExam:BaseEntity, IHistoryEntity
    {

        public DateTime SampleDate { get; set; }
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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
