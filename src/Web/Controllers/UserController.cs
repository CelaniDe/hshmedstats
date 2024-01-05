using Microsoft.AspNetCore.Mvc;

namespace hshmedstats.Web.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
