using hshmedstats.Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "AMKA")]
        public string Amka { get; set; }
        [Display(Name = "Ημερομηνία επίσκεψης")]
        public string VisitDate { get; set; }
        [Display(Name = "Ημερομηνία καταγραφής")]
        public string CreatedAt { get; set; }
        [Display(Name = "Όνομα")]
        public string FirstName { get; set; }
        [Display(Name = "Επώνυμο")]
        public string LastName { get; set; }
        [Display(Name = "Πατρώνυμο")]
        public string FatherName { get; set; }
        [Display(Name = "Ημερομηνία γέννησης")]
        public string BirthDate { get; set; }
        [Display(Name = "Τόπος γέννησης")]
        public string? BirthPlace { get; set; }
        [Display(Name = "Τόπος διαμονής")]
        public string? Address { get; set; }
        [Display(Name = "Φύλο")]
        public int Gender { get; set; }
        [Display(Name = "Ημερομηνία διάγνωσης")]
        public string DiagnosisDate { get; set; }
        [Display(Name = "Ηλικία διάγνωσης")]
        public int DiagnosisAge { get; set; }
        [Display(Name = "Επάγγελμα")]
        public string Job { get; set; }
        [Display(Name = "Οικογενές ιστορικό αιματολογικής διαταραχής")]
        public int FamilyDisorderAnswer { get; set; }
        [Display(Name = "Αν ναι, προσδιοριστε")]
        public string? FamilyDisorderAnswerDetails { get; set; }
        [Display(Name = "Ύψος (m)")]
        public decimal Height { get; set; }
        [Display(Name = "Βάρος (kg)")]
        public decimal Weight { get; set; }
        [Display(Name = "BMI")]
        public decimal BMI { get; set; }
        [Display(Name = "Κατάσταση ικανότητος κατά Karnofsky")]
        public int KarnofskyPerformanceStatus { get; set; }
        [Display(Name = "Κλινική")]
        public int ClinicId { get; set; }
    }

    public class PatientHistoryViewModel
    {
        public PatientHistoryViewModel()
        {
            
        }
        [Display(Name = "Προηγούμενο επεισόδιο θρομβωτικής μικροαγγειοπάθειας")]
        public bool PreviousEpisodeOfThromboticMicroangiopathy { get; set; }
        [Display(Name = "Αν ναι, αναφέρετε ημερομηνίες ή έτη διάγνωσης")]
        public string? ThromboticMicroangiopathyDetails { get; set; }
        [Display(Name = "Καρδιακή νόσος")]
        public bool HeartDisease { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ")]
        public string? HeartDiseaseDetails { get; set; }
        [Display(Name = "Αναπνευστική νόσος")]
        public bool RespiratoryDisease { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ")]
        public string? RespiratoryDiseaseDetails { get; set; }
        [Display(Name = "Ενδοκρινική νόσος")]
        public bool EndocrineDisease { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ")]
        public string? EndocrineDiseaseDetails { get; set; }
        [Display(Name = "Νεφρική νόσος")]
        public bool KidneyDisease { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ")]
        public string? KidneyDiseaseDetails { get; set; }
        [Display(Name = "Νεοπλασματική νόσος")]
        public bool NeoplasticDisease { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ")]
        public string? NeoplasticDiseaseDetails { get; set; }
        [Display(Name = "Αυτοάνοση νόσος")]
        public bool AutoimmuneDisease { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ")]
        public string? AutoimmuneDiseaseDetails { get; set; }
        [Display(Name = "Μεταμόσχευση")]
        public bool Transplant { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ")]
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

        [Display(Name = "ΔΙΑΓΝΩΣΗ")]
        public int DiagnosisType { get; set; }
        //TTP
        [Display(Name = "Ανασταλτές ADAMTS13")]
        public int ADAMTS13Inhibitors { get; set; }
        [Display(Name = "ΕΓΧΥΣΗ ΠΛΑΣΜΑΤΟΣ")]
        public bool PlasmaInjection { get; set; }
        [Display(Name = "Αν ναι, ΑΡΙΘΜΟΣ")]
        public string? PlasmaInjectionDetails { get; set; }
        [Display(Name = "Caplacizumab")]
        public bool Caplacizumab { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ημερομηνία έναρξης, διάρκεια και δόση")]
        public string? CaplacizumabDetails { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε επίπεδα στη διάγνωση")]
        public string? ADAMT13ActivityLevel { get; set; }


        //Hus or sTMA
        [Display(Name = "Ενεργοποίηση συμπληρώματος")]
        public bool ComplementInhibitor { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε επίπεδα στη διάγνωση")]
        public string? ComplementInhibitorDetails { get; set; }



        //TaTma
        [Display(Name = "Τύπος δότη")]
        public int DonorType { get; set; }
        [Display(Name = "Αν άλλος, προσδιορίστε")]
        public string? DonorTypeDetails { get; set; }
        [Display(Name = "Προπαρασκευαστικό σχήμα")]
        public int PreparatoryScheme { get; set; }
        [Display(Name = "Προσδιορίστε ακρωνύμιο προπαρασκευαστικού σχήματος")]
        public string? PreparatorySchemeAcronym { get; set; }
        [Display(Name = "Ολόσωμη ακτινοβόληση")]
        public bool WholeBodyRadiation { get; set; }
        [Display(Name = "Νόσος")]
        public int TmaDisease { get; set; }
        [Display(Name = "Προσδιορίστε νόσο")]
        public string? IdentifyDisease { get; set; }
        [Display(Name = "Disease risk index")]
        public int DiseaseRiskIndex { get; set; }
        [Display(Name = "HCT-CI")]
        public int HCTCI { get; set; }
        [Display(Name = "Lines treatment")]
        public int HCTCILinesTreatment { get; set; }
        [Display(Name = "CMV οροθετικότητα ασθενούς / δότη")]
        public int CMVSeropositivityOfPatientDonor { get; set; }
        [Display(Name = "Graft source")]
        public int GraftSource { get; set; }
        [Display(Name = "CD34+μοσχεύματος")]
        public int? CD34Graft { get; set; }
        [Display(Name = "Ημερομηνία μεταμόσχευσης")]
        public string TransplantDate { get; set; }
        [Display(Name = "GVHD προφύλαξη")]
        public string? GVHDProphylaxis { get; set; }
        [Display(Name = "Εμφύτευση πολυμορφοπυρήνων")]
        public bool ImplantationOfPolymorphonuclears { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ημερομηνία")]
        public string? ImplantationOfPolymorphonuclearsDetails { get; set; }
        [Display(Name = "Εμφύτευση αιμοπεταλίων")]
        public bool PlateletImplantation { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε ημερομηνία")]
        public string? PlateletImplantationDetails { get; set; }
        [Display(Name = "Σοβαρές λοιμώξεις")]
        public bool SeriousInfections { get; set; }
        [Display(Name = "Επιτυχής έκβαση")]
        public bool SuccessfulOutcome { get; set; }
        [Display(Name = "CMV ιαιμία")]
        public bool CMVViremia { get; set; }
        [Display(Name = "CMV λοίμωξη")]
        public bool CMVInfection { get; set; }
        [Display(Name = "CMV θεραπεία")]
        public bool CMVTherapy { get; set; }
        [Display(Name = "Επιτυχής έκβαση")]
        public bool CMVTherapySuccessfulOutcome { get; set; }
        [Display(Name = "EBV ιαιμία")]
        public bool EBVViremia { get; set; }
        [Display(Name = "EBV λέμφωμα")]
        public bool EBVLymphoma { get; set; }
        [Display(Name = "EBV θεραπεία")]
        public bool EBVTherapy { get; set; }
        [Display(Name = "Επιτυχής έκβαση")]
        public bool EBVTherapySuccessfulOutcome { get; set; }
        [Display(Name = "VOD")]
        public bool VOD { get; set; }
        [Display(Name = "aGVHD")]
        public bool aGVHD { get; set; }
        [Display(Name = "Grade")]
        public int? aGVHDGrade { get; set; }
        [Display(Name = "Κορτικο-εξαρτώμενη ή ανθεκτική")]
        public bool CorticoDependentOrResistant { get; set; }
        [Display(Name = "Γραμμές θεραπείας")]
        public int? CorticoDependentOrResistantTreatmentLine { get; set; }
        [Display(Name = "Χρόνια GVHD")]
        public bool ChronicGVHD { get; set; }
        [Display(Name = "Grade")]
        public int ChronicGVHDGrade { get; set; }
        [Display(Name = "Αναστολέας καλσινευρίνης")]
        public bool CalcineurinInhibitor { get; set; }
        [Display(Name = "Αναστολέας mTOR")]
        public bool mTORInhibitor { get; set; }
        [Display(Name = "Ruxolitinib")]
        public bool Ruxolitinib { get; set; }
        [Display(Name = "Αν ναι, προσδιορίστε δόση και διάρκεια")]
        public string? RuxolitinibDetails { get; set; }

        //General
        [Display(Name = "Αν ναι, προσδιορίστε επίπεδα στη διάγνωση")]
        public decimal? LevelOfDiagnosis { get; set; }
        [Display(Name = "Κλινική")]
        public string? DiagnosisDate { get; set; }
        [Display(Name = "Κλινική")]
        public int AddOnActivation { get; set; }//Hus,TMA
        [Display(Name = "Κλινική")]
        public string? AddOnActivationDetails { get; set; }//Hus,TMA

        [Display(Name = "ΚΟΡΤΙΚΟΕΙΣΗ (ΔΟΣΗ)")]
        public bool CorticosisDosage { get; set; }//TTP,Hus,TMA
        [Display(Name = "Αν ναι, προσδιορίστε είδος, διάρκεια και δόση")]
        public string? CorticosisDosageDetails { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΠΛΑΣΜΑΦΑΙΡΕΣΕΙΣ ")]
        public bool Plasmapheresis { get; set; }//TTP,Hus,TMA
        [Display(Name = "Αν ναι, ΑΡΙΘΜΟΣ ΠΛΑΣΜΑΦΑΙΡΕΣΕΩΝ")]
        public string? PlasmapheresisDetails { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΑΠΑΝΤΗΣΗ ΣΤΙΣ ΠΛΑΣΜΑΦΑΙΡΕΣΕΙΣ")]
        public bool PlasmapheresisAnswer { get; set; } //TTP,Hus,TMA
        [Display(Name = "RITUXIMAB")]
        public bool Rituximab { get; set; }//TTP,Hus,TMA
        [Display(Name = "Αν ναι, προσδιορίστε ημερομηνία έναρξης, διάρκεια και δόση")]
        public string? RituximabDetails { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΑΠΑΝΤΗΣΗ")]
        public bool RituximabAnswer { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΆΛΛΗ ΑΝΟΣΟΚΑΤΑΣΤΟΛΗ")]
        public string? OtherImmunoSuppression { get; set; }//TTP,Hus,TMA
        [Display(Name = "Ηπαρίνη χαμηλού μοριακού βάρους")]
        public bool LowMolecularWeightHeparin { get; set; }//TTP,Hus,TMA
        [Display(Name = "Αν ναι, προσδιορίστε ημερομηνία έναρξης, διάρκεια και δόση")]
        public string? LowMolecularWeightHeparinDetails { get; set; }//TTP,Hus,TMA
        [Display(Name = "Αντιαιμοπεταλιακά")]
        public bool AntiplateletAgents { get; set; }//TTP,Hus,TMA
        [Display(Name = "Αν ναι, προσδιορίστε ημερομηνία έναρξης, διάρκεια και δόση")]
        public string? AntiplateletAgentsDetails { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΥΦΕΣΗ")]
        public bool Recession { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΘΑΝΑΤΟΣ")]
        public bool Death { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΗΜΕΡΟΜΗΝΙΑ ΤΕΛΕΥΤΑΙΟΥ FOLLOW-UP")]
        public string DateOfLastFollowUp { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΑΙΤΙΑ ΘΑΝΑΤΟΥ")]
        public string CauseOfDeath { get; set; }//TTP,Hus,TMA
        [Display(Name = "ΑΛΛΑ ΣΧΟΛΙΑ")]
        public string OtherComments { get; set; }//TTP,Hus,TMA
    }
}
