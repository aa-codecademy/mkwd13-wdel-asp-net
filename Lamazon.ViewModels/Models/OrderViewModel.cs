using Lamazon.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.ViewModels.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public decimal TotalAmount { get; set; }
        public string IpAddress { get; set; }
        public string CountryCode { get; set; }
        public string CountryFlagUrl { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public string OrderStatusString
        {
            get { return OrderStatus.ToString(); }
        }
        public List<OrderLineItemViewModel> OrderLineItems { get; set; }
    }
}
