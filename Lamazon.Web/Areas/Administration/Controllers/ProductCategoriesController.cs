using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Web.Areas.Administration.Controllers
{
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesService _productCategoriesService;

        public ProductCategoriesController(IProductCategoriesService productCategoriesService)
        {
            PageName = "Product Categories";
            _productCategoriesService = productCategoriesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetProductCategories(DatatableRequestViewModel datatableRequest)
        {
            var table = _productCategoriesService.GetPagedResultViewModel(datatableRequest);
            return Json(table.ToTableData());
        }

        public IActionResult Create() 
        {
            var productCategoryViewModel = new ProductCategoryViewModel();
            return View(productCategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategoryViewModel productCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _productCategoriesService.CreateProductCategory(productCategoryViewModel);
                return RedirectToAction("Index");
            }
            return View(productCategoryViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var productCategoryViewModel = _productCategoriesService.GetProductCategoryById(id.Value);
                return View(productCategoryViewModel);
            }
            return new EmptyResult();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategoryViewModel productCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _productCategoriesService.UpdateProductCategory(productCategoryViewModel);
                RedirectToAction("Index");
            }
            return View(productCategoryViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if(id.HasValue)
            {
                var productCategoryViewModel = _productCategoriesService.GetProductCategoryById(id.Value);
                return View(productCategoryViewModel);
            }
            return new EmptyResult();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id) 
        {
         if(id.HasValue)
            {
                _productCategoriesService.DeleteProductCategory(id.Value);
                return RedirectToAction("Index");
            }
         return new EmptyResult();
        }
    }
}
