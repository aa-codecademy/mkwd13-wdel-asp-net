using Lamazon.DataAccess.DataContext;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Lamazon.Domain.Enums;
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
    }
}
