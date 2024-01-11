using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace hshmedstats.Domain.Models
{
    public class ExcusedConduct:BaseEntity, IHistoryEntity
    {
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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
