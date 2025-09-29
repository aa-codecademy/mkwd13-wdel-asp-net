using Lamazon.Domain.Entities;
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
    }
}
