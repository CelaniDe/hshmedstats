using hshmedstats.Application.Extensions;
using hshmedstats.Application.Helpers;
using hshmedstats.Web.Models.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Types;

namespace hshmedstats.Web.Controllers
{
    public class PatientController:BaseController
    {
        public async Task<IActionResult> Index()
        {

            var patients = new List<PatientIntexViewModel>
            {
                new PatientIntexViewModel{Id=1, Amka = "12345678998", FullName = "Rimvydas Janusauskas"},
                new PatientIntexViewModel{Id=1, Amka = "12345678998", FullName = "Rimvydas Janusauskas"},
                new PatientIntexViewModel{Id=1, Amka = "12345678998", FullName = "Rimvydas Janusauskas"},
            };
            return View(patients);
        }


        public async Task<IActionResult> Details(int? id)
        {
            await LoadDetailsViewBag();
            return View(new PatientViewModel());
        }

        public async Task<IActionResult> VisitDetails(int? id)
        {
            await LoadVisitDetailsViewBag();
            return View(new PatientVisitDetailsViewModel());
        }


        private async Task LoadDetailsViewBag()
        {
            ViewBag.Clinics = new List<SelectListItem>
            {
                new SelectListItem("Clinic 1","1"),
                 new SelectListItem("Clinic 2", "2")
            };

            ViewBag.YesNo = new List<SelectListItem>
            {
                new SelectListItem("ΝΑΙ","true"),
                 new SelectListItem("ΌΧΙ", "false") 
            };
            ViewBag.Genders = Enum.GetValues<GenderType>().Select(g => g.GetSelectListItem());
            ViewBag.AnswerTypes = Enum.GetValues<AnswerType>().Select(g => g.GetSelectListItem());
            ViewBag.KarnofskyStatuses = KarnofskyPerformanceStatusScale.GetScaleStatuses();
            ViewBag.DiagnosisTypes = Enum.GetValues<DiagnosisType>().Select(g => g.GetSelectListItem());
            ViewBag.DonorTypes = Enum.GetValues<DonorType>().Select(g => g.GetSelectListItem());
            ViewBag.PreparatorySchemes = Enum.GetValues<PreparatorySchemeType>().Select(g => g.GetSelectListItem());
            ViewBag.TmaDiseases = Enum.GetValues<TmaDiseaseType>().Select(g => g.GetSelectListItem());
            ViewBag.DiseaseRiskIndexes = Enum.GetValues<RiskIndexType>().Select(g => g.GetSelectListItem());
            ViewBag.CMVSeropositivityOfPatientDonors = Enum.GetValues<CMVSeropositivityType>().Select(g => g.GetSelectListItem());
            ViewBag.GraftSourceTypes = Enum.GetValues<GraftSourceType>().Select(g => g.GetSelectListItem());
        }


        private async Task LoadVisitDetailsViewBag()
        {
            ViewBag.YesNo = new List<SelectListItem>
            {
                new SelectListItem("ΝΑΙ","true"),
                 new SelectListItem("ΌΧΙ", "false")
            };

            ViewBag.AnswerTypes = Enum.GetValues<AnswerType>().Select(g => g.GetSelectListItem());
            ViewBag.BloodTypes = Enum.GetValues<BloodType>().Select(g => g.GetSelectListItem());
        }
    }
}
