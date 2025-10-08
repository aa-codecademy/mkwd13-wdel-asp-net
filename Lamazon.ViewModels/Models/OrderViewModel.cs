using Lamazon.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.ViewModels.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }
        public string IpAddress { get; set; }
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Display(Name = "Country Flag")]
        public string CountryFlagUrl { get; set; }
        [Display(Name = "Order Status")]
        public OrderStatusEnum OrderStatus { get; set; }
        public string OrderStatusString
        {
            get { return OrderStatus.ToString(); }
        }
        public List<OrderLineItemViewModel> OrderLineItems { get; set; }
    }
}
