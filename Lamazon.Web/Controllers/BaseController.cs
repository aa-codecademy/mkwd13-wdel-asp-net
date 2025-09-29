using Lamazon.Entities.Constants;
using Lamazon.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Lamazon.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            SetShoppingCartMetadata();
        }

        private void SetShoppingCartMetadata()
        {
            var shoppingCart = GetShoppingCart();
            ViewBag.ShoppingCartItemsCount = shoppingCart is null ? 0 : shoppingCart.ShoppingCartItems.Count;
        }

        protected ShoppingCartViewModel GetShoppingCart()
        {
            var shoppingCart = new ShoppingCartViewModel();

            if (Request.Cookies.ContainsKey(Cookies.ShoppingCart))
            {
                var cookieValue = Request.Cookies[Cookies.ShoppingCart];

                shoppingCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(cookieValue);
            }

            return shoppingCart;

        }

        protected void AddNotificationMessage(string message)
        {
            TempData["NoticationMessage"] = message;
        }
    }
}
