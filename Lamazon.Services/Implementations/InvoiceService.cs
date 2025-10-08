using AutoMapper;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Lamazon.Entities.Enums;
using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task CancelInvoice(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            invoice.InvoiceStatusId = (int)InvoiceStatusEnum.Canceled;
            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task CreateInvoice(InvoiceViewModel invoice)
        {
            var invoiceDb = _mapper.Map<Invoice>(invoice);
            var invoiceId = await _invoiceRepository.InsertAsync(invoiceDb);

            if (invoiceId <= 0) 
            {
                throw new Exception("Something went wrong while saving the new invoice");
            }
        }

        public async Task<List<InvoiceViewModel>> GetAllInvoices()
        {
            var invoice = await _invoiceRepository.GetAllAsync();
            return _mapper.Map<List<InvoiceViewModel>>(invoice);
        }

        public async Task<PagedResultViewModel<InvoiceViewModel>> GetFilteredInvoices(DatatableRequestViewModel request)
        {
            var searchValue = request?.search?.value ?? string.Empty;
            var invoicePagedResult = await _invoiceRepository.GetFilteredAsync(
                request.start,
                request.length,
                searchValue,
                request.sortColumn,
                request.isAscending
                );

            return _mapper.Map<PagedResultViewModel<InvoiceViewModel>>(invoicePagedResult);

        }

        public async Task<InvoiceViewModel> GetInvoice(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            return _mapper.Map<InvoiceViewModel>(invoice);
        }

        public async Task SetAsPaid(int id)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(id);
            invoice.InvoiceStatusId = (int)InvoiceStatusEnum.Paid;
            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task UpdateInvoice(InvoiceViewModel invoice)
        {
            var invoiceDb = _mapper.Map<Invoice>(invoice);
            await _invoiceRepository.UpdateAsync(invoiceDb);
        }
    }
}
