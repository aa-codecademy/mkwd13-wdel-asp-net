using Lamazon.Services.Interfaces;
using Lamazon.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Implementations
{
    public class GeoTrackerService : IGeoTrackerService
    {
        private readonly HttpClient _httpClient;

        public GeoTrackerService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public string GetCountryFlagUrl(string countryCode)
        {
            return $"https://flagcdn.com/w320/{countryCode.ToLower()}.png";
        }

        public async Task<IpGeoInfo> GetIpGeoInfoAsync(string ipAddress)
        {
            var response = await _httpClient.GetAsync($"http://ip-api.com/json/{ipAddress}");
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IpGeoInfo>(jsonData);
        }
    }
}
