using hshmedstats.Application.Dtos;
using hshmedstats.Application.Global;
using hshmedstats.Application.Handlers.User.Commands;
using hshmedstats.Application.Handlers.User.Queries;
using hshmedstats.Application.Interfaces;
using hshmedstats.Web.Models;
using hshmedstats.Web.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace hshmedstats.Web.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class UserController : BaseController
    {
      
        public async Task<IActionResult> Index()
        {
            var users = await _Mediator.Send(new GetUserListQuery());

            return View(users.Select(u=> new UserViewModel(u)).ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            await LoadDetailsViewBag();

            if (id != null)
            {
                var user = await _Mediator.Send(new GetUserQuery { UserId = id.Value });
                return View(new UserViewModel(user));
            }

            return View(new UserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details([FromForm] UserViewModel model)
        {
            if (model.Id != null)
            {
                if (model.Password == null )
                {
                    ModelState["Password"].ValidationState = ModelValidationState.Valid;
                    ModelState["Password"].Errors.Clear();
                }
            }

            await LoadDetailsViewBag();

            if (!ModelState.IsValid) return View(model);

            var user = await _Mediator.Send(new CreateOrUpdateUserCommand { User = _Mapper.Map<UserDto>(model) });

            if (user.HasErrors)
            {
                AddModelErrors(user);
                return View(model);
            }

            return RedirectToAction("Index", new ToastModel(ToastType.success, model.Id, "User"));
        }

        private async Task LoadDetailsViewBag()
        {
            ViewBag.Roles = (await _Mediator.Send(new GetRoleListQuery())).Select(r => new SelectListItem { Text = r.Name, Value = r.Name });
        }

    }
}
