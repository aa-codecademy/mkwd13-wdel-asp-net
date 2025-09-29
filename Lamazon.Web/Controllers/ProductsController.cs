using Lamazon.Entities.Constants;
using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lamazon.Web.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
           _productService = productService;
        }
        public IActionResult Index()
        {
            var shoppingCart = GetShoppingCart();
            var allProducts = _productService.GetAllProducts();

            allProducts.ForEach(product =>
            {
                product.IsAddedToCart = shoppingCart.ShoppingCartItems.Any(x=>x.Id == product.Id);
            });

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

        [HttpPost]
        public JsonResult AddToCart(ShoppingCartItemViewModel shoppingCart)
        {
            var shoppingCartItemsCount = AddShoppingCartItem(shoppingCart);

            return Json(new { ItemsCount = shoppingCartItemsCount });
        }

        private int AddShoppingCartItem(ShoppingCartItemViewModel shoppingCartItemViewModel)
        {
            var shoppingCart = GetShoppingCart();

            if(!shoppingCart.ShoppingCartItems.Any(x=>x.Id == shoppingCartItemViewModel.Id))
            {
                shoppingCart.ShoppingCartItems.Add(shoppingCartItemViewModel);
            }

            Response.Cookies.Append(
                key: Cookies.ShoppingCart,
                value: JsonConvert.SerializeObject(shoppingCart),
                options : new CookieOptions { Expires = DateTime.Now.AddDays(2)}
                );

            return shoppingCart.ShoppingCartItems.Count();

        }

        [HttpPost]

        public JsonResult RemoveFromCart (ShoppingCartItemViewModel shoppingCartItemView)
        {
            var shoppingCart = RemoveFromShoppingCart(shoppingCartItemView);
            return Json(new { ItemsCount = shoppingCart });
        }

        private int RemoveFromShoppingCart(ShoppingCartItemViewModel shoppingCartItemView)
        {
            var shoppingCart = GetShoppingCart();

            var cartItem = shoppingCart.ShoppingCartItems.FirstOrDefault(x => x.Id == shoppingCartItemView.Id);

            if (cartItem != null)
            {
                shoppingCart.ShoppingCartItems.Remove(cartItem);
            }

            if (shoppingCart.ShoppingCartItems.Any())
            {
                Response.Cookies.Append(
                    key : Cookies.ShoppingCart,
                    value: JsonConvert.SerializeObject(shoppingCart), 
                    options : new CookieOptions { Expires = DateTime.Now.AddDays(2) }                  
                    );
            }
            else
            {
                Response.Cookies.Delete(Cookies.ShoppingCart);
            }

            return shoppingCart.ShoppingCartItems.Count();
        
        }
    }
}
