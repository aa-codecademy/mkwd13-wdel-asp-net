using System.Net;

namespace Lamazon.Web.Middlewares
{
    public class DebugIpAddressMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly HttpClient _httpClient = new HttpClient();

        public DebugIpAddressMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ip = await GetPublicIPAddressAsync();

            if (ip != null) 
            {
             context.Connection.RemoteIpAddress = ip;
            }
            await _next(context);
        }

        private async Task<IPAddress> GetPublicIPAddressAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("http://checkip.dyndns.org/");
                var first = response.IndexOf("Address: ") + 9;
                var last = response.IndexOf("</body>");
                string address = response.Substring(first, last - first);
                return IPAddress.Parse(address);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
