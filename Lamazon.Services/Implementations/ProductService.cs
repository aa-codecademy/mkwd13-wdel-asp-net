using AutoMapper;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Lamazon.Domain.Enums;
using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void CreateProduct(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);
            product.ProductStatusId = (int)ProductStatusEnum.Active;
            var productId = _productRepository.Insert(product);

            if(productId < 0)
            {
                throw new Exception("Something went wrong while saving new product");
            }
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteById(id);
        }

        public List<ProductViewModel> GetAllFeaturedProducts()
        {
           var featureProducts = _productRepository.GetAllFeaturedProducts();

           var mappedProducts = _mapper.Map<List<ProductViewModel>>(featureProducts);

            return mappedProducts;
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();

            var mappedProducts = _mapper.Map<List<ProductViewModel>>(products);

            return mappedProducts;
        }

        public PagedResultViewModel<ProductViewModel> GetFilteredProducts(ProductsDatatableRequestViewModel model)
        {
            var searchValue = model.search.value ?? string.Empty;

            var productPagedResult = _productRepository.GetFilteredProducts(
                model.CategoryId,
                model.start,
                model.length,
                searchValue,
                model.sortColumn,
                model.isAscending
                );

            return _mapper.Map<PagedResultViewModel<ProductViewModel>>(productPagedResult);
        }

        public ProductViewModel GetProductById(int id)
        {
            var product = _productRepository.GetById(id);   

            return _mapper.Map<ProductViewModel>(product);
        }

        public void UpdateProduct(ProductViewModel model)
        {
           var product = _mapper.Map<Product>(model);
            _productRepository.Update(product);
        }
    }
}
