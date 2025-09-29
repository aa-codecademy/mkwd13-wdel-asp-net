using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.ViewModels.Models
{
    public class OrderLineItemViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public  int  DiscountPercentage { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
