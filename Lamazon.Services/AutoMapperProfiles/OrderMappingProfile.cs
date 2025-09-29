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
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() 
        {
            CreateMap<Order, OrderViewModel>()
                   .ForMember(x => x.OrderStatus, opt => opt.Ignore())
                   .ForMember(x => x.OrderStatus, opt => opt.MapFrom(y => y.OrderStatusId))
                   .ReverseMap()
                   .ForMember(x => x.OrderStatus, opt => opt.Ignore())
                   .ForMember(x => x.OrderStatusId, opt => opt.MapFrom(y => y.OrderStatus));

            CreateMap<OrderLineItem, OrderLineItemViewModel>()
                .ReverseMap()
                .ForMember(x=>x.Product, opt => opt.Ignore());
        
        }
    }
}
