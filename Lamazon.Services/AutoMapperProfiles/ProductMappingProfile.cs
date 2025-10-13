using AutoMapper;
using Lamazon.Domain.Entities;
using Lamazon.Entities.Models;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.AutoMapperProfiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() 
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(x => x.ProductStatus, opt => opt.Ignore())
                .ForMember(x => x.Info, opt => opt.MapFrom(s => $"{s.Id.ToString("000")} - {s.Name} ({s.ProductCategory.Name})"))
                .ForMember(x => x.ProductStatus, opt => opt.MapFrom(s => s.ProductStatusId))
                .ReverseMap()
                .ForMember(x => x.ProductStatus, opt => opt.Ignore())
                .ForMember(x => x.ProductStatusId, opt => opt.MapFrom(x => x.ProductStatus));


            CreateMap<PageResultModel<Product>, PagedResultViewModel<ProductViewModel>>().ReverseMap();
        
        }
    }
}
