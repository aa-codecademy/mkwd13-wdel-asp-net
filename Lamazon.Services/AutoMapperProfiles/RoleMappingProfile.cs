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
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile() 
        { 
         CreateMap<Role , RoleViewModel>().ReverseMap();
        }
    }
}
