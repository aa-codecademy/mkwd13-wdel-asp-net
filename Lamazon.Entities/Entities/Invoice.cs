namespace Lamazon.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int InvoiceStatusId { get; set; }

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
        public virtual InvoiceStatus InvoiceStatus { get; set; }

        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }

        public Invoice()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
        }
    }
}
