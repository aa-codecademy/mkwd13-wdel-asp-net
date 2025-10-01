using Lamazon.Entities.Constants;
using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using Lamazon.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lamazon.Web.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IGeoTrackerService _geoTrackerService;

        public OrdersController(IOrderService orderService, IProductService productService, IGeoTrackerService geoTrackerService) 
        {
            _orderService = orderService;
            _productService = productService;
            _geoTrackerService = geoTrackerService;
        }

        public IActionResult ShoppingCart()
        {
            var shoppingCart = GetShoppingCart();

            if (!shoppingCart.ShoppingCartItems.Any())
            {
                return RedirectToAction("Index", "Products");
            }

            var orderLineItems = new List<OrderLineItemViewModel>();

            foreach (var shoppingCartItem in shoppingCart.ShoppingCartItems)
            {
                var product = _productService.GetProductById(shoppingCartItem.Id);

                var orderLineItem = new OrderLineItemViewModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.DiscountedPrice,
                    ProductDescription = product.Description,
                    ProductImage = product.ImageUrl,
                    Quantity = 1,
                    DiscountPercentage = product.DiscountPercentage,
                };

                orderLineItem.TotalPrice = orderLineItem.Quantity * orderLineItem.ProductPrice;

                orderLineItems.Add(orderLineItem);

            }

            return View(orderLineItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(List<OrderLineItemViewModel> orderLineItems)
        {
            var orderViewModel = new OrderViewModel();

            orderViewModel.UserId = User.GetUserId();
            orderViewModel.TotalAmount = orderLineItems.Sum(x=>x.TotalPrice);
            orderViewModel.OrderLineItems = orderLineItems;

            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            orderViewModel.IpAddress = ipAddress != null ? ipAddress.ToString() : "123";
            var ipGeoInfo = await _geoTrackerService.GetIpGeoInfoAsync(orderViewModel.IpAddress);
            orderViewModel.CountryCode = ipGeoInfo.CountryCode;
            orderViewModel.CountryFlagUrl = _geoTrackerService.GetCountryFlagUrl(ipGeoInfo.CountryCode);

            await _orderService.CreateOrder(orderViewModel);

            Response.Cookies.Delete(Cookies.ShoppingCart);
            AddNotificationMessage("Order was successfully created!");

            return RedirectToAction("Index", "Home");
            

        }
    }
}
