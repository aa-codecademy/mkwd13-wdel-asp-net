using Lamazon.DataAccess.DataContext;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Lamazon.Entities.Enums;
using Lamazon.Entities.Models;


namespace Lamazon.DataAccess.Implementations
{
    public class ProductCategoryRepository : BaseRepository, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public void DeleteById(int id)
        {
            var productCategory = _applicationDbContext.ProductCategories.FirstOrDefault(c => c.Id == id);

            if (productCategory is null) 
            {
                throw new Exception($"Product Category with id {id} does not exist");
            }
            //soft delete
            productCategory.ProductCategoryStatusId = (int)ProductCategoryStatusEnum.Deleted;
            _applicationDbContext.Update(productCategory);
            _applicationDbContext.SaveChanges();

        }

        public ProductCategory GetById(int id)
        {
            return _applicationDbContext.ProductCategories
                .FirstOrDefault(x => x.Id == id  && x.ProductCategoryStatusId != (int)ProductCategoryStatusEnum.Deleted)!;
        }

        public PageResultModel<ProductCategory> GetFilteredProductCategories(int startIndex, int count, string searchValue, string orderByColumn, bool isAscending)
        {
            var result = new PageResultModel<ProductCategory>();

            var productCategoryQuery = _applicationDbContext.ProductCategories
                .Where(x => x.ProductCategoryStatusId != (int)ProductCategoryStatusEnum.Deleted);

            result.TotalRecords = productCategoryQuery.Count();

            productCategoryQuery = productCategoryQuery.Where(x=>x.Name.Contains(searchValue));

            result.TotalDisplayRecords = productCategoryQuery.Count();

            if(orderByColumn == "Name")
            {
                productCategoryQuery = isAscending 
                    ? productCategoryQuery.OrderBy(x=> x.Name)
                    : productCategoryQuery.OrderByDescending(x=> x.Name);
            }

            result.Items = productCategoryQuery.Skip(startIndex).Take(count).ToList();

            return result;
        }

        public int Insert(ProductCategory productCategory)
        {
           _applicationDbContext.ProductCategories.Add(productCategory);
            _applicationDbContext.SaveChanges();

            return productCategory.Id;
        }

        public void Update(ProductCategory productCategory)
        {
           if(!_applicationDbContext.ProductCategories
                .Any(x=>x.Id == productCategory.Id && x.ProductCategoryStatusId != (int)ProductCategoryStatusEnum.Deleted ))
            {
                throw new Exception($"ProductCategory with id {productCategory.Id} was not found");
            }

           _applicationDbContext.ProductCategories.Update(productCategory);
           _applicationDbContext.SaveChanges();
        }
    }
}
