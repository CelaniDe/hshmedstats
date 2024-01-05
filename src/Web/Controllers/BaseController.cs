using AutoMapper;
using hshmedstats.Application.Dtos;
using hshmedstats.Application.Interfaces;
using hshmedstats.Web.Filters;
using hshmedstats.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace hshmedstats.Web.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator _Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private LoggedInUser _loggedInUser;
        protected LoggedInUser _LoggedInUser => _loggedInUser ??= HttpContext.RequestServices.GetService<LoggedInUser>();

        private IMapper _mapper;
        protected IMapper _Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();


        protected RedirectToActionResult RedirectToAction(string actionName, ToastModel toast, object routeValues = null)
        {
            AddToast(toast);
            return RedirectToAction(actionName, routeValues);
        }

        protected RedirectResult RedirectToReturnUrl(ToastModel toast)
        {
            AddToast(toast);
            return Redirect(ViewBag.ReturnUrl);
        }

        protected void AddToast(ToastModel toast)
        {
            TempData["toast"] = JsonSerializer.Serialize(toast);
        }

        protected void AddModelErrors(IBaseDto dto)
        {
            foreach (var error in dto.Errors)
            {
                foreach (var message in error.Value)
                {
                    ModelState.AddModelError(error.Key, message);
                }
            }
        }
    }
}
