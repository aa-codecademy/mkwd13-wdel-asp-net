using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Web.Areas.Administration.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<JsonResult> GetOrders(DatatableRequestViewModel datatableRequestView)
        {
            var tableResult = await _orderService.GetFilteredOrders(datatableRequestView);
            return Json(tableResult.ToTableData());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id.HasValue)
            {
                var orderViewModel = await _orderService.GetById(id.Value);
                return View(orderViewModel);
            }
            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> RejectOrder(int? id)
        {
            if (id.HasValue)
            {
                await _orderService.RejectedOrder(id.Value);
                AddNotificationMessage("Order was rejected");
                return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AcceptOrder(int? id)
        {
            if (id.HasValue)
            {
                await _orderService.AcceptOrder(id.Value);
                AddNotificationMessage("Order was accpeted!");
                return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}
