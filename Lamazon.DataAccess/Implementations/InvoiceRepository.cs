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
    public class InvoiceRepository : BaseRepository, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<List<Invoice>> GetAllAsync()
        {
           return await _applicationDbContext.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Invoices
                .Include(x=>x.InvoiceLineItems)
                .Include(x=>x.User)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<PageResultModel<Invoice>> GetFilteredAsync(int startIndex, int count, string searchValue, string orderByColumn, bool isAscending)
        {
            var result = new PageResultModel<Invoice>();

            var invoiceQuery = _applicationDbContext.Invoices.Include(x=>x.User).AsQueryable();

            result.TotalRecords = invoiceQuery.Count();

            invoiceQuery = invoiceQuery.Where(x => x.InvoiceNumber.Contains(searchValue));
            result.TotalDisplayRecords = invoiceQuery.Count();

            invoiceQuery = ProcessInvoicesByQuery(invoiceQuery, orderByColumn, isAscending);

            result.Items = await invoiceQuery.Skip(startIndex).Take(count).ToListAsync();

            return result;
        
        }

        private IQueryable<Invoice> ProcessInvoicesByQuery(IQueryable<Invoice> invoiceQuery, string orderByColumn, bool isAscending)
        {
            invoiceQuery = orderByColumn switch
            {
                "InvoiceNumber" => isAscending 
                ? invoiceQuery.OrderBy(x=>x.InvoiceNumber)
                : invoiceQuery.OrderByDescending(x=>x.InvoiceNumber),
                "User.FullName" => isAscending
                ? invoiceQuery.OrderBy(x=>x.User.FullName)
                : invoiceQuery.OrderByDescending(x=>  x.User.FullName),
                "InvoiceStatus" => isAscending
                ? invoiceQuery.OrderBy(x=>x.InvoiceStatus)
                : invoiceQuery.OrderByDescending(x=>x.InvoiceStatus),
                "TotalAmount" => isAscending
                ? invoiceQuery.OrderBy(x=> x.TotalAmount)
                : invoiceQuery.OrderByDescending(x=>x.TotalAmount),
                _ => throw new NotImplementedException()
            };

            return invoiceQuery;
        }

        public async Task<int> GetMaxIdAsync()
        {
            if(await _applicationDbContext.Invoices.AnyAsync())
            {
                return _applicationDbContext.Invoices.Max(x => x.Id);
            }
           return 0;
        }

        public async Task<int> InsertAsync(Invoice invoice)
        {
            await _applicationDbContext.Invoices.AddAsync(invoice);
            await _applicationDbContext.SaveChangesAsync();

            return invoice.Id;
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            if(await _applicationDbContext.Invoices.AnyAsync(x=>x.Id == invoice.Id))
            {
                _applicationDbContext.Update(invoice);
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Invoice with id {invoice.Id} was not found.");
            }
        }
    }
}
