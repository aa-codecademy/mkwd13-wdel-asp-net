using Lamazon.ViewModels.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Lamazon.Web.Helpers
{
    public static class AuthHelper
    {
        public static async Task SignInUser(UserViewModel userViewModel, HttpContext httpContext)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userViewModel.Id.ToString()),
                new Claim(ClaimTypes.Email, userViewModel.Email),
                new Claim(ClaimTypes.Name, userViewModel.FullName),
                new Claim(ClaimTypes.Role, userViewModel.Role.Key),
                new Claim(ClaimTypes.PrimaryGroupSid, userViewModel.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await httpContext.SignInAsync(
                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                principal: new ClaimsPrincipal(claimsIdentity),
                properties: new AuthenticationProperties
                {
                    IsPersistent = true
                }                
                );
        }

        public static async Task SignoutUser(HttpContext context)
        {
            await context.SignOutAsync();
        }
    }
}
