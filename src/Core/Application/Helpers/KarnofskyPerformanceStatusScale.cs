using hshmedstats.Application.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hshmedstats.Application.Helpers
{
    public static class KarnofskyPerformanceStatusScale
    {

        public static List<SelectListItem> GetScaleStatuses()
        {
            return new List<SelectListItem>
            {
                new SelectListItem(){Value="100" ,Text="Normal no complaints; no evidence of disease"},
                new SelectListItem(){Value="90" ,Text="Able to carry on normal activity; minor signs or symptoms of disease"},
                new SelectListItem(){Value="80" ,Text="Normal activity with effort; some signs or symptoms of disease"},
                new SelectListItem(){Value="70" ,Text="Cares for self; unable to carry on normal activity or to do active work"},
                new SelectListItem(){Value="60" ,Text="Requires occasional assistance, but is able to care for most of his personal needs"},
                new SelectListItem(){Value="50" ,Text="Requires considerable assistance and frequent medical care"},
                new SelectListItem(){Value="40" ,Text="Disable; requires special care and assistance" },
                new SelectListItem(){Value="30" ,Text="Severely disabled; hospital admission is indicated although death not imminent"},
                new SelectListItem(){Value="20" ,Text="Very sick; hospital admission necessary; active supportive treatment necessary"},
                new SelectListItem(){Value="10" ,Text="Moribund; fatal processes progressing rapidly"},
                new SelectListItem(){Value="0" ,Text="Dead"}

            };
        }

        public static string ScaleDefinition(int rating)
        {
            return rating switch
            {
                100 => "Normal no complaints; no evidence of disease",
                90 => "Able to carry on normal activity; minor signs or symptoms of disease",
                80 => "Normal activity with effort; some signs or symptoms of disease",
                70 => "Cares for self; unable to carry on normal activity or to do active work",
                60 => "Requires occasional assistance, but is able to care for most of his personal needs",
                50 => "Requires considerable assistance and frequent medical care",
                40 => "Disable; requires special care and assistance",
                30 => "Severely disabled; hospital admission is indicated although death not imminent",
                20 => "Very sick; hospital admission necessary; active supportive treatment necessary",
                10 => "Moribund; fatal processes progressing rapidly",
                0 => "Dead",
                _ => "Dead"
            };

        }
    }
}
