using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.ViewModels.Models
{
    public class DashboardViewModel
    {
        public DashboardViewModel() 
        {
         Administrators = new List<UserViewModel>();
        }
        public int TotalCustomers { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalOrdersAmount { get; set; }
        public int TotalPendingOrders {  get; set; }
        public int TotalRejectedOrders { get; set; }
        public int TotalAcceptedOrders { get; set; }
        public int TotalDeletedProducts { get; set; }
        public int TotalActiveProducts { get; set;}
        public int TotalInvoices { get; set; }
        public decimal TotalInvoicesAmount { get; set; }
        public int TotalPendingInvoices { get;set; }
        public int TotalPaidInvoices { get; set; }   
        public int TotalCanceledInvoices { get; set; }
        public List<UserViewModel> Administrators { get; set; }

    }
}
