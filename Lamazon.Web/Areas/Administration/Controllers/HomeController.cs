using Lamazon.Entities.Constants;
using Lamazon.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Admin)]
    public class HomeController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService)         
        {
         PageName = "Dashboard";
          _dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            var dashboardViewModel = _dashboardService.GetDashboardData();
            return View(dashboardViewModel);
        }
    }
}
