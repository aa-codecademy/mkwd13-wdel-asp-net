using Lamazon.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Interfaces
{
    public interface IGeoTrackerService
    {
        string GetCountryFlagUrl(string countryCode);
        Task<IpGeoInfo> GetIpGeoInfoAsync(string ipAddress);
    }
}
