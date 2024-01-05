using Microsoft.AspNetCore.Mvc;

namespace hshmedstats.Web.Controllers
{
    public class PatientController:BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
