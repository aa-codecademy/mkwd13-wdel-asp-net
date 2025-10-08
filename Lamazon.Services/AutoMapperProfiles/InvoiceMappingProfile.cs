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
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile() 
        { 
         CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(x=>x.InvoiceStatus, opt => opt.Ignore())
                .ForMember(x=>x.InvoiceStatus, opt => opt.MapFrom(y=>y.InvoiceStatusId))
                .ReverseMap()
                .ForMember(x => x.InvoiceStatus, opt => opt.Ignore())
                .ForMember(x => x.InvoiceStatusId, opt => opt.MapFrom(y => y.InvoiceStatus));

            CreateMap<InvoiceLineItem, InvoiceLineItemViewModel>().ReverseMap();

            CreateMap<PagedResultViewModel<InvoiceViewModel>, PageResultModel<Invoice>>()
                .ReverseMap();
        
        }
    }
}
