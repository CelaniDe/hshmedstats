﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace hshmedstats.Domain.Models
{
    public sealed class TaTmaDiagnosis:BaseEntity, IHistoryEntity
    {

        public DonorType DonorType { get; set; }
        public string? DonorTypeDetails { get; set; }
        public PreparatorySchemeType PreparatoryScheme { get; set; }
        public string? PreparatorySchemeAcronym { get; set; }
        public bool WholeBodyRadiation { get; set; }
        public TmaDiseaseType TmaDisease { get; set; }
        public string? IdentifyDisease { get; set; }
        public RiskIndexType DiseaseRiskIndex { get; set; }
        public int HCTCI { get; set; }
        public int LinesTreatment { get; set; }
        public CMVSeropositivityType CMVSeropositivityOfPatientDonor { get; set; }
        public GraftSourceType GraftSource { get; set; }
        public int CD34Graft { get; set; }
        public DateTime TransplantDate { get; set; }
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
        public int Grade { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public bool CorticoDependentOrResistant { get; set; }

        public bool ChronicGVHD { get; set; }
        public bool CalcineurinInhibitor { get; set; }
        public bool mTORInhibitor { get; set; }
        public bool Ruxolitinib { get; set; }
        public string? RuxolitinibDetails { get; set; }
        public bool AddOnActivation { get; set; }
        public string? AddOnActivationDetails { get; set; }
        public bool CorticosisDosage { get;set; }
        public string? CorticosisDosageDetails { get; set; }
        public bool Plasmapheresis { get; set; }
        public string? PlasmapheresisDetails { get; set; }
        public bool AnswerPlasmapheresis { get; set; }
        public bool Rituximab { get; set; }
        public string? RituximabDetails { get; set; }
        public bool RituximabAnswer { get; set; }
        public string? OtherImmunoSuppression { get; set; }
        public bool ComplementInhibitor { get; set; }
        public string? ComplementInhibitorDetails { get; set; }
        public bool LowMolecularWeightHeparin { get; set; }
        public string LowMolecularWeightHeparinDetails { get; set; }
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
