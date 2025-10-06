using Lamazon.DataAccess.DataContext;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Lamazon.Entities.Models;
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

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Orders
                .Include(x=>x.OrderLineItems)
                .Include(x=> x.User)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<PageResultModel<Order>> GetFilteredOrdersAsync(int startIndex, int count, string searchValue, string orderByColumn, bool isAscending)
        {
            var result = new PageResultModel<Order>();

            var ordersQuery = _applicationDbContext.Orders.Include(x => x.User).AsQueryable();

            result.TotalRecords = ordersQuery.Count();

            ordersQuery = ordersQuery.Where(x => x.OrderNumber.Contains(searchValue));
            result.TotalDisplayRecords = ordersQuery.Count();

            ordersQuery = await ProcessOrderByQuery(ordersQuery, orderByColumn, isAscending);

            result.Items = await ordersQuery.Skip(startIndex).Take(count).ToListAsync();

            return result;
        }

        private Task<IQueryable<Order>> ProcessOrderByQuery(IQueryable<Order> ordersQuery, string orderByColumn, bool isAscending)
        {
            ordersQuery = orderByColumn switch
            {
                "OrderNumber" => isAscending
                ? ordersQuery.OrderBy(x => x.OrderNumber)
                : ordersQuery.OrderByDescending(x => x.OrderNumber),
                "User.FullName" => isAscending
                ? ordersQuery.OrderBy(x => x.User.FullName)
                : ordersQuery.OrderByDescending(x=> x.User.FullName),
                "CountryCode" => isAscending
                ? ordersQuery.OrderBy(x=>x.CountryCode)
                : ordersQuery.OrderByDescending(x=>x.CountryCode),
                "TotalAmount" => isAscending
                ? ordersQuery.OrderBy(x=>x.TotalAmount)
                : ordersQuery.OrderByDescending(x=>x.TotalAmount),
                "OrderStatus" => isAscending
                ? ordersQuery.OrderBy(x=>x.OrderStatus)
                : ordersQuery.OrderByDescending(x=>x.OrderStatus),
                _ => throw new NotImplementedException()
            };

            return Task.FromResult(ordersQuery);
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

        public async Task UpdateAsync(Order order)
        {
            if (await _applicationDbContext.Orders.AnyAsync(x => x.Id == order.Id)) 
            { 
             _applicationDbContext.Update(order);
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Order with id {order.Id} was not found");
            }
        }
    }
}
