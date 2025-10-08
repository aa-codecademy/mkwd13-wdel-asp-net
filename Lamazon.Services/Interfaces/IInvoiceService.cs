using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<InvoiceViewModel>> GetAllInvoices();
        Task<InvoiceViewModel> GetInvoice(int id);
        Task CreateInvoice(InvoiceViewModel invoice);
        Task UpdateInvoice (InvoiceViewModel invoice);
        Task CancelInvoice (int id);
        Task SetAsPaid (int id);
        Task<PagedResultViewModel<InvoiceViewModel>> 
            GetFilteredInvoices(DatatableRequestViewModel request);
    }
}
