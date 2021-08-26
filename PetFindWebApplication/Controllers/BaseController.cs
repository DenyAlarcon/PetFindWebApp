using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetFindWebApplication.DAL;
using PetFindWebApplication.Data;
using PetFindWebApplication.Models;

namespace PetFindWebApplication.Controllers
{
    //public abstract class BaseController<T> : Controller where T : class
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData["currentUserId"] = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            base.OnActionExecuting(filterContext);
        }
        //public abstract AbstractDataGateway CreateGateway(PetFindWebApplicationContext context);
        //public abstract IDataGateway<T> CreateGateway();
    }
}