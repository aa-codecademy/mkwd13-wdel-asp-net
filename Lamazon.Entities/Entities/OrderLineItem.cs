namespace Lamazon.Domain.Entities
{
    public class OrderLineItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }

        public OrderLineItem()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
        }
    }
}
