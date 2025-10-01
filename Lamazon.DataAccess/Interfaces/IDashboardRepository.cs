using Lamazon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.Interfaces
{
    public interface IDashboardRepository
    {
        int CountCustomers();
        int CountActiveProducts();
        int CountDeletedProducts();
        int CountInvoices();
        int CountPendingInvoices();
        int CountPaidInvoices();
        int CountCanceledInvoices();
        decimal GetInvocicesTotalAmount();
        int CountOrders();
        int CountPendingOrders();
        int CountAcceptedOrders();
        int CountRejectedOrders();
        decimal GetOrdersTotalAmount();
        List<User> GetAdministrators();

    }
}
