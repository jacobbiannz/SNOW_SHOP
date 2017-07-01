using AutoMapper;
using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.API.ViewModel.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        : this("MyProfile")
        {
        }
        protected ViewModelToDomainMappingProfile(string profileName)
        : base(profileName)
        {
            CreateMap<CompanyViewModel, Company>()
             .ForMember(m => m.Name,
                  map => map.MapFrom(vm => vm.Name));

            CreateMap<CategoryViewModel, Category>()
               .ForMember(m => m.Name,
                  map => map.MapFrom(vm => vm.Name))
             .ForMember(m => m.Company,
                  map => map.MapFrom(vm => vm.Company));

            CreateMap<BrandViewModel, Brand>()
              .ForMember(m => m.Name,
                 map => map.MapFrom(vm => vm.Name))
            .ForMember(m => m.Company,
                 map => map.MapFrom(vm => vm.Company));

            //    .ForMember(m => m.AllProducts, map =>
            //          map.MapFrom(vm => vm.AllProducts.Select(a => a.Name)));

            CreateMap<ProductViewModel, Product>()
               .ForMember(m => m.Name,
                    map => map.MapFrom(vm => vm.Name))
               .ForMember(m => m.Description,
                    map => map.MapFrom(vm => vm.Description))
               .ForMember(m => m.MarketPrice,
                    map => map.MapFrom(vm => vm.MarketPrice))
               .ForMember(m => m.StockPrice,
                    map => map.MapFrom(vm => vm.StockPrice));
             //   .ForMember(m => m.Brand,
              //      map => map.MapFrom(vm => vm.Brand))
             //   .ForMember(m => m.Category,
             //       map => map.MapFrom(vm => vm.Category))
             //  .ForMember(m => m.Company,
             //       map => map.MapFrom(vm => vm.Company));

           
        }
    }
}
