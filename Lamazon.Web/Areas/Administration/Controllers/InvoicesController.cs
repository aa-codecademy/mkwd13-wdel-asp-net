using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using Lamazon.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Web.Areas.Administration.Controllers
{
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<JsonResult> GetInvoices(DatatableRequestViewModel model)
        {
            var paged = await _invoiceService.GetFilteredInvoices(model);
            return Json(paged.ToTableData());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id.HasValue)
            {
                var invoiceViewModel = await _invoiceService.GetInvoice(id.Value);
                return View(invoiceViewModel);
            }            
               
            return new EmptyResult();          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetAsPaid(int? id)
        {
            if(id.HasValue)
            {
             await _invoiceService.SetAsPaid(id.Value);
                return RedirectToAction(nameof(Index));

            }
            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CancelInvoice(int? id)
        {
            if (id.HasValue)
            {
                await _invoiceService.CancelInvoice(id.Value);
                return RedirectToAction(nameof(Index));

            }
            return new EmptyResult();
        }


    }
}
