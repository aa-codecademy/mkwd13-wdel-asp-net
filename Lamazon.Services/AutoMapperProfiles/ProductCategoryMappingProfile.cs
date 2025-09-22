using AutoMapper;
using Lamazon.Domain.Entities;
using Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamazon.Services.AutoMapperProfiles
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile() 
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>()
                   .ForMember(x => x.ProductCategoryStatus, opt => opt.Ignore())
                   .ForMember(x => x.ProductCategoryStatus,
                                   opt => opt.MapFrom(s => s.ProductCategoryStatusId))
                   .ReverseMap()
                   .ForMember(x => x.ProductCategoryStatus, opt => opt.Ignore())
                   .ForMember(x => x.ProductCategoryStatusId,
                                   opt => opt.MapFrom(s => s.ProductCategoryStatus));

        }
    }
}
