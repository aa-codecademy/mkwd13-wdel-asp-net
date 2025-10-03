using AutoMapper;
using Lamazon.DataAccess.Interfaces;
using Lamazon.Domain.Entities;
using Lamazon.Services.Interfaces;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.Implementations
{
    public class ProductCategoriesService : IProductCategoriesService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoriesService(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);
            var productCategoryId = _productCategoryRepository.Insert(productCategory);
            if (productCategoryId <= 0) 
            {
                throw new Exception("Something went wrong while saving the new product category!");
            }
        }

        public void DeleteProductCategory(int id)
        {
            _productCategoryRepository.DeleteById(id);
        }

        public PagedResultViewModel<ProductCategoryViewModel> GetPagedResultViewModel(DatatableRequestViewModel datatableRequestViewModel)
        {
            var searchValue = datatableRequestViewModel.search?.value ?? string.Empty;

            var productCategoryPagedResult = _productCategoryRepository.GetFilteredProductCategories
                (
                 startIndex: datatableRequestViewModel.start,
                 count: datatableRequestViewModel.length,
                 searchValue: searchValue,
                 orderByColumn: datatableRequestViewModel.sortColumn,
                 isAscending: datatableRequestViewModel.isAscending
                );

            var mappedPagedResult = _mapper.Map<PagedResultViewModel<ProductCategoryViewModel>>(productCategoryPagedResult);

            return mappedPagedResult;
        }


        public ProductCategoryViewModel GetProductCategoryById(int id)
        {
            var productCategory = _productCategoryRepository.GetById(id);

            return _mapper.Map<ProductCategoryViewModel>(productCategory);
        }

        public void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);

            _productCategoryRepository.Update(productCategory);
        }
    }
}
