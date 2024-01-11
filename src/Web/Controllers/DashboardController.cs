using Microsoft.AspNetCore.Mvc;

namespace hshmedstats.Web.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
