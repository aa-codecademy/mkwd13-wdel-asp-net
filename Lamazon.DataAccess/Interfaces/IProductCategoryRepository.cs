using Lamazon.Domain.Entities;
using Lamazon.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.DataAccess.Interfaces
{
    public interface IProductCategoryRepository
    {
        int Insert(ProductCategory productCategory);
        void Update (ProductCategory productCategory);
        void DeleteById(int id);
        ProductCategory GetById(int id);
        PageResultModel<ProductCategory> GetFilteredProductCategories
            (int startIndex, int count, string searchValue, string orderByColumn, bool isAscending);

    }
}
