using System.Diagnostics;
using Lamazon.Services.Interfaces;
using Lamazon.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var shoppingCart = GetShoppingCart();
            var featuredProducts = _productService.GetAllFeaturedProducts();
            featuredProducts.ForEach(product =>
            {
                product.IsAddedToCart = shoppingCart.ShoppingCartItems.Any(x => x.Id == product.Id);
            });

            return View(featuredProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
