namespace Lamazon.Domain.Entities
{
    public class InvoiceStatus : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public InvoiceStatus()
        {
            Invoices = new HashSet<Invoice>();
        }
    }
}
