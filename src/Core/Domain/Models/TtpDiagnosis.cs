using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace hshmedstats.Domain.Models
{
    public sealed class TtpDiagnosis:BaseEntity, IHistoryEntity
    {

        public AnswerType ADAMTS13Inhibitors { get;set; }
        public decimal LevelOfDiagnosis { get; set; }
        public bool CorticosisDosage { get; set; }
        public string? CorticosisDosageDetails { get; set; }
        public bool PlasmaInjection { get; set; }
        public string? PlasmaInjectionDetails { get; set; }
        public bool ResponseToPlasmapheresis { get; set; }
        public bool Plasmapheresis { get; set; }
        public string? PlasmapheresisDetails { get; set; }
        public bool Rituximab { get; set; }
        public string? RituximabDetails { get; set; }
        public bool RituximabAnswer { get; set; }
        public string? OtherImmunoSuppression { get; set; }
        public bool Caplacizumab { get; set; }
        public string? CaplacizumabDetails { get; set; }
        public bool LowMolecularWeightHeparin { get; set; }
        public string? LowMolecularWeightHeparinDetails { get; set; }
        public bool AntiplateletAgents { get; set; }
        public string? AntiplateletAgentsDetails { get; set; }
        public bool Recession { get; set; }
        public bool Death { get; set; }
        public DateTime DateOfLastFollowUp { get; set; }
        public string CauseOfDeath { get; set; }
        public string OtherComments { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }

}
