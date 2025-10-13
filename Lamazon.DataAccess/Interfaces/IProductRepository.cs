using Lamazon.Domain.Entities;
using Lamazon.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<Product> GetAllFeaturedProducts();
        Product GetById(int id);
        int Insert(Product product);
        void Update(Product product);
        void DeleteById(int id);
        PageResultModel<Product> GetFilteredProducts
            (int? categoryId, int startIndex, int count, string searchValue, string orderByColumn, bool isAscending);
    }
}
