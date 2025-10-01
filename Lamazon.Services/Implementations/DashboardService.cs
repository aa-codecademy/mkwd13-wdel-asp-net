using Lamazon.DataAccess.Interfaces;
using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public DashboardViewModel GetDashboardData()
        {
            return new DashboardViewModel 
            { 
                TotalOrders = _dashboardRepository.CountOrders()
            };

        }
    }
}
