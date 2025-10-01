using Lamazon.Web.Middlewares;

namespace Lamazon.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDebugIpAddressMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DebugIpAddressMiddleware>();
        }
    }
}
