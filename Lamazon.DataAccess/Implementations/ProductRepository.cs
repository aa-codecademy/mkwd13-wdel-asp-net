using Lamazon.DataAccess.DataContext;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Lamazon.Domain.Enums;
using Lamazon.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.Implementations
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public void DeleteById(int id)
        {
            var product = _applicationDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) 
            {
                throw new Exception($"Product with id {id} was not found!");
            }

            product.ProductStatusId = (int)ProductStatusEnum.Deleted;
            _applicationDbContext.Products.Update(product);
            _applicationDbContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _applicationDbContext.Products
                .Include(x=> x.ProductCategory)
                .Where(x=> x.ProductStatusId != (int)ProductStatusEnum.Deleted)
                .ToList();
        }

        public List<Product> GetAllFeaturedProducts()
        {
            return _applicationDbContext.Products
                .Include(x=>x.ProductCategory)
                .Where(x=>x.IsFeatured &&  x.ProductStatusId != (int)ProductStatusEnum.Deleted)
                .ToList();
        }

        public Product GetById(int id)
        {
            return _applicationDbContext.Products
                 .Include(x => x.ProductCategory)
                 .FirstOrDefault(x => x.Id == id & x.ProductStatusId != (int)ProductStatusEnum.Deleted);
        }

        public PageResultModel<Product> GetFilteredProducts(int? categoryId, int startIndex, int count, string searchValue, string orderByColumn, bool isAscending)
        {
            var result = new PageResultModel<Product>();

            var productQuery = _applicationDbContext.Products
                .Include(x => x.ProductCategory)
                .Where(x => x.ProductStatusId != (int)ProductStatusEnum.Deleted);

            result.TotalRecords = productQuery.Count();

            if (categoryId.HasValue)
            {
                productQuery = productQuery.Where(x => x.ProductCategoryId == categoryId);
            }

            productQuery = productQuery.Where(x=>x.Name.Contains(searchValue));
            result.TotalDisplayRecords = productQuery.Count();


            productQuery = ProcessProductsByQuery(productQuery, orderByColumn, isAscending);

            result.Items = productQuery.Skip(startIndex).Take(count).ToList();

            return result;

        }


        public int Insert(Product product)
        {
            _applicationDbContext.Products.Add(product);
            _applicationDbContext.SaveChanges();
            return product.Id;
        }

        public void Update(Product product)
        {
            if(_applicationDbContext.Products.Any(x=>x.Id == product.Id && x.ProductStatusId != (int)ProductStatusEnum.Deleted))
            {
                _applicationDbContext.Update(product);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Product with id {product.Id} was not found");
            }

        }


        private IQueryable<Product>ProcessProductsByQuery(IQueryable<Product> query, string orderByColumn, bool isAscending)
        {
            query = orderByColumn switch
            {
                "Name" => isAscending
                ? query.OrderBy(x => x.Name)
                : query.OrderByDescending(x => x.Name),
                "ProductCategory.Name" => isAscending
                ? query.OrderBy(x => x.ProductCategory.Name)
                : query.OrderByDescending(x => x.ProductCategory.Name),
                "Price" => isAscending
                ? query.OrderBy(x => x.Price)
                : query.OrderByDescending(x => x.Price),
                _ => throw new NotImplementedException()
            };

            return query;
        }
    }
}
