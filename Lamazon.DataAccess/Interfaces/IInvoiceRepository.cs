using Lamazon.Domain.Entities;
using Lamazon.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<int> GetMaxIdAsync();
        Task<int> InsertAsync(Invoice invoice);
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(int id);
        Task UpdateAsync(Invoice invoice);

        Task<PageResultModel<Invoice>> GetFilteredAsync
            (int startIndex, int count, string searchValue, string orderByColumn, bool isAscending);
    }
}
