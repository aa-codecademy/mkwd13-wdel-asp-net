using Lamazon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
           _productService = productService;
        }
        public IActionResult Index()
        {
            var allProducts = _productService.GetAllProducts();
            return View(allProducts);
        }

        public IActionResult ProductDetails(int? id)
        {
            if(id.HasValue)
            {
                var product = _productService.GetProductById(id.Value);
                return View(product);
            }
            return new EmptyResult();
        }
    }
}
