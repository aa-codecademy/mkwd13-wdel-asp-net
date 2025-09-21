namespace Lamazon.Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }
    }
}
