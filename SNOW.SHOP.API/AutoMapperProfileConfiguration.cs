using AutoMapper;
using SNOW.SHOP.API.API.ViewModel;
using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<Company, CompanyViewModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>()
            .ForMember(dest=>dest.Company, opt=>opt.MapFrom(src=>src.CompanyId) );
            
        }
    }
}
