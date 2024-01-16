using System;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Ημερομηνία δειγματοληψίας")]
        public string SampleDate { get; set; }
        [Display(Name = "Ομάδα αίματος ΑΒΟ")]
        public int BloodType { get; set; }
        [Display(Name = "Αιμοσφαιρίνη")]
        public decimal Hemoglobin { get; set; }
        [Display(Name = "MCV")]
        public decimal MCV { get; set; }
        [Display(Name = "Δικτυοερυθροκύτταρα")]
        public int? Reticulocytes { get; set; }
        [Display(Name = "Αιμοπετάλια")]
        public decimal Platelets { get; set; }
        [Display(Name = "Απτοσφαιρινη")]
        public decimal? Haptoglobulin { get; set; }
        [Display(Name = "Σχιστοκυτταρα")]
        public decimal Schistocytes { get; set; }
        [Display(Name = "Κρεατινινη")]
        public decimal Creatine { get; set; }
        [Display(Name = "Αιμοκάθαρση")]
        public bool BloodDialysis { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ημερομηνία έναρξης και διάγνωση")]
        public string? BloodDialysisDetails { get; set; }
        [Display(Name = "PT")]
        public decimal? PT { get; set; }
        [Display(Name = "APTT")]
        public decimal? APTT { get; set; }
        [Display(Name = "INR")]
        public decimal INR { get; set; }
        [Display(Name = "Ινωδογονο")]
        public decimal Fibrous { get; set; }
        [Display(Name = "Ανεπάρκεια ADAMTS13")]
        public int ADAMTS13Deficiency { get; set; }
        [Display(Name = "Προσδιορίστε Δραστικότητα ADAMTS13")]
        public decimal? DetermineADAMTS13Activity { get; set; }
        [Display(Name = "Γενετικός έλεγχος")]
        public bool GeneticTesting { get; set; }
        [Display(Name = "Προσδιορίστε λεπτομέρειες")]
        public string? GeneticTestingDetails { get; set; }
        [Display(Name = "Φύλαξη βιολογικού υλικού")]
        public bool StorageOfBiologicalMaterial { get; set; }
        [Display(Name = "Προσδιορίστε λεπτομέρειες")]
        public string? StorageOfBiologicalMaterialDetails { get; set; }
        [Display(Name = "Κύηση")]
        public bool Pregnancy { get; set; }
        [Display(Name = "Λοχεία")]
        public bool Puerperium { get; set; }
        [Display(Name = "ΠΡΟΣΒΟΛΗ ΚΝΣ")]
        public bool CnsInsult { get; set; }
        [Display(Name = "Εμβολιασμοί εντός 30 ημερών από το επεισόδιο")]
        public bool VaccinationsWithin30DaysOfTheEpisode { get; set; }
        [Display(Name = "Αρτηριακή Υπέρταση")]
        public bool ArterialHypertension { get; set; }
        [Display(Name = "Επίπεδα συστολικής ΑΠ")]
        public int? SystolicBPLevels { get; set; }
        [Display(Name = "Επίπεδα διαστολικής ΑΠ")]
        public int? DiastolicBPLevels { get; set; }
        [Display(Name = "Αντιυπερτασικά φάρμακα")]
        public int? AntihypertensiveDrugs { get; set; }
    }

    public class PatientExcusedConductViewModel
    {
        public PatientExcusedConductViewModel()
        {
            
        }

        [Display(Name = "Αντιαιμοπεταλιακά")]
        public bool Antiplatelet { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? AntiplateletDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? AntiplateletDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool AntiplatelContinues { get; set; }

        [Display(Name = "Αντιπηκτικά")]
        public bool Anticoagulants { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? AnticoagulantsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? AnticoagulantsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool AnticoagulantsContinues { get; set; }

        [Display(Name = "Υπολιπιδαιμικοί παράγοντες")]
        public bool LipidLoweringAgents { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? LipidLoweringAgentsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? LipidLoweringAgentsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool LipidLoweringAgentsContinues { get; set; }

        [Display(Name = "Διουρητικά")]
        public bool DiureticsAgents { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? DiureticsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? DiureticsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool DiureticsContinues { get; set; }

        [Display(Name = "Κορτικοστεροειδή")]
        public bool Corticosteroids { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? CorticosteroidsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? CorticosteroidsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool CorticosteroidsContinues { get; set; }

        [Display(Name = "Οιστρογόνα σαν υποκατάσταση")]
        public bool EstrogenAsReplacement { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? EstrogenAsReplacementDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? EstrogenAsReplacementDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool EstrogenAsReplacementContinues { get; set; }

        [Display(Name = "Άλλη ορμονική θεραπεία")]
        public bool OtherHormoneTherapy { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? OtherHormoneTherapyDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? OtherHormoneTherapyDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool OtherHormoneTherapyContinues { get; set; }

        [Display(Name = "Αναστολείς αντλίας πρωτονίων")]
        public bool ProtonPumpInhibitors { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? ProtonPumpInhibitorsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? ProtonPumpInhibitorsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool ProtonPumpInhibitorsContinues { get; set; }

        [Display(Name = "Αντιϋπερτασικά")]
        public bool Antihypertensives { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? AntihypertensivesDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? AntihypertensivesDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool AntihypertensivesContinues { get; set; }

        [Display(Name = "Αντιαρρυθμικά")]
        public bool Antiarrhythmics { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? AntiarrhythmicsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? AntiarrhythmicsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool AntiarrhythmicsContinues { get; set; }

        [Display(Name = "Εισπνεόμενα βρογχοδιασταλτικά")]
        public bool InhaledBronchodilators { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? InhaledBronchodilatorsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? InhaledBronchodilatorsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool InhaledBronchodilatorsContinues { get; set; }

        [Display(Name = "Αντικαταθλιπτικά")]
        public bool Antidepressants { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? AntidepressantsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? AntidepressantsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool AntidepressantsContinues { get; set; }

        [Display(Name = "Αντιδιαβητικά")]
        public bool Antidiabetic { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? AntidiabeticDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? AntidiabeticDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool AntidiabeticContinues { get; set; }

        [Display(Name = "Ακτινοθεραπεία")]
        public bool Radiotherapy { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? RadiotherapyDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? RadiotherapyDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool RadiotherapyContinues { get; set; }

        [Display(Name = "Ανοσοκατασταλτικά")]
        public bool Immunosuppressants { get; set; }
        [Display(Name = "Ημερομηνία Έναρξης")]
        public DateTime? ImmunosuppressantsDateFrom { get; set; }
        [Display(Name = "Ημερομηνία Λήξης")]
        public DateTime? ImmunosuppressantsDateTo { get; set; }
        [Display(Name = "Συνεχίζεται;")]
        public bool ImmunosuppressantsContinues { get; set; }

        [Display(Name = "Άλλα")]
        public string? Other { get; set; }
    }
}
