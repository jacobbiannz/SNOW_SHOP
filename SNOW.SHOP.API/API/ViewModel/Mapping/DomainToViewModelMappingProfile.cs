using AutoMapper;
using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.API.ViewModel.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        : this("MyProfile")
        {
        }
        protected DomainToViewModelMappingProfile(string profileName)
        : base(profileName)
        {
            CreateMap<Company, CompanyViewModel>()
              .ForMember(vm => vm.Name,
                   map => map.MapFrom(s => s.Name));

            CreateMap<Category, CategoryViewModel>()
             .ForMember(vm => vm.Name,
                  map => map.MapFrom(s => s.Name))
             //.ForMember(vm => vm.Company,
             //     map => map.MapFrom(s => s.Company))
             .ForMember(vm => vm.AllProducts, s => s.ResolveUsing(src=> ConvertProducts(src.AllProducts)));

            CreateMap<Brand, BrandViewModel>()
            .ForMember(vm => vm.Name,
                 map => map.MapFrom(s => s.Name))
            .ForMember(vm => vm.AllProducts, map =>
                      map.MapFrom(s => s.AllProducts.Select(a => a.Name)))
            .ForMember(vm => vm.Company,
                 map => map.MapFrom(s => s.Company))
            .ForMember(vm => vm.AllProducts, s => s.ResolveUsing(src => ConvertProducts(src.AllProducts)));

            //   .ForMember(vm => vm.AllProducts, map =>
            //           map.MapFrom(s => s.AllProducts.Select(a => a.Name)));

            CreateMap<Product, ProductViewModel>()
               .ForMember(vm => vm.Name,
                    map => map.MapFrom(s => s.Name))
               .ForMember(vm => vm.Description,
                    map => map.MapFrom(s => s.Description))
               .ForMember(vm => vm.MarketPrice,
                    map => map.MapFrom(s => s.MarketPrice))
               .ForMember(vm => vm.StockPrice,
                    map => map.MapFrom(s => s.StockPrice))
               .ForMember(vm => vm.BrandInfo,
                    map => map.MapFrom(s => new KeyValuePair<string, string>(s.Brand.Id.ToString(), s.Brand.Name)))
                .ForMember(vm => vm.CategoryInfo,
                    map => map.MapFrom(s => new KeyValuePair<string, string>(s.Category.Id.ToString(), s.Category.Name)))
               .ForMember(vm => vm.CompanyInfo,
                    map => map.MapFrom(s => new KeyValuePair<string, string>(s.Company.Id.ToString(), s.Company.Name)));
            //   .ForMember(vm => vm.Attendees, map =>
            //         map.MapFrom(s => s.Attendees.Select(a => a.UserId)));


           
            //  CreateMap<Schedule, ScheduleDetailsViewModel>()
            //    .ForMember(vm => vm.Creator,
            //          map => map.MapFrom(s => s.Creator.Name))
            //     .ForMember(vm => vm.Attendees, map =>
            //          map.UseValue(new List<UserViewModel>()))
            //      .ForMember(vm => vm.Status, map =>
            //          map.MapFrom(s => ((ScheduleStatus)s.Status).ToString()))
            //       .ForMember(vm => vm.Type, map =>
            //         map.MapFrom(s => ((ScheduleType)s.Type).ToString()))
            //     .ForMember(vm => vm.Statuses, map =>
            //        map.UseValue(Enum.GetNames(typeof(ScheduleStatus)).ToArray()))
            //    .ForMember(vm => vm.Types, map =>
            //         map.UseValue(Enum.GetNames(typeof(ScheduleType)).ToArray()));


        }

        private object ConvertProducts(ICollection<Product> src)
        {
            ICollection<KeyValuePair<string, string>> products = new Dictionary<string, string>();
            foreach ( var p in src )
            {
                products.Add( new KeyValuePair<string, string>(p.Id.ToString(), p.Name));
            }

            return products;
        }
    }
}
