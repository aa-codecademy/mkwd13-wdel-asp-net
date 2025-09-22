using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
        List<ProductViewModel> GetAllFeaturedProducts();
        ProductViewModel GetProductById(int id);
    }
}
