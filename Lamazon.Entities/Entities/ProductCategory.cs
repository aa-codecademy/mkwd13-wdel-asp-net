namespace Lamazon.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public int ProductCategoryStatusId { get; set; }

        public virtual ProductCategoryStatus ProductCategoryStatus { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
    }
}
