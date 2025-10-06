using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(OrderViewModel orderViewModel);
        Task AcceptOrder(int id);
        Task RejectedOrder(int id);
        Task<OrderViewModel> GetById(int id);
        Task<PagedResultViewModel<OrderViewModel>> GetFilteredOrders
                                    (DatatableRequestViewModel datatableRequestViewModel);

    }
}
