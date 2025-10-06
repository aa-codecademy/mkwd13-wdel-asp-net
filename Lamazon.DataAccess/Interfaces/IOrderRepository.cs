using Lamazon.Domain.Entities;
using Lamazon.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> GetMaxIdAsync();
        Task<int> InsertAsync(Order order);
        Task UpdateAsync(Order order);
        Task<Order> GetByIdAsync(int id);
        Task<PageResultModel<Order>> GetFilteredOrdersAsync
            (int startIndex, int count, string searchValue, string orderByColumn, bool isAscending);

    }
}
