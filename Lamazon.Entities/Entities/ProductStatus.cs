namespace Lamazon.Domain.Entities
{
    public class ProductStatus : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ProductStatus()
        {
            Products = new HashSet<Product>();
        }
    }
}
