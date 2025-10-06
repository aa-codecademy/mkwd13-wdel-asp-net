using Lamazon.Entities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lamazon.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Admin)]
    public class ControllerBase : Controller
    {
        protected string PageName { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.PageName = PageName;    
            base.OnActionExecuting(context);
        }

        protected void AddNotificationMessage(string message)
        {
            TempData["NoticationMessage"] = message;
        }
    }
}
