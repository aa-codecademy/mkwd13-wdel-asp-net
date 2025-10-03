using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Interfaces
{
    public interface IProductCategoriesService
    {
        void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel);
        void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel);
        void DeleteProductCategory(int id);
        ProductCategoryViewModel GetProductCategoryById(int id);

        PagedResultViewModel<ProductCategoryViewModel> 
            GetPagedResultViewModel(DatatableRequestViewModel datatableRequestViewModel);

    }
}
