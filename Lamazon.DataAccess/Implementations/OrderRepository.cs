using Lamazon.DataAccess.DataContext;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.Implementations
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<int> GetMaxIdAsync()
        {
           if( await _applicationDbContext.Orders.AnyAsync())
            {
                return _applicationDbContext.Orders.Max(x=>x.Id);
            }

           return 0;
        }

        public async Task<int> InsertAsync(Order order)
        {
            await _applicationDbContext.Orders.AddAsync(order);
            await _applicationDbContext.SaveChangesAsync();
            return order.Id;
        }
    }
}
