using SNOW.SHOP.API.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.API.ViewModel
{
    public class CategoryViewModel
    {
        public Int32? ID { get; set; }

        public String Name { get; set; }

        public CompanyViewModel Company { get; set; }

        public ICollection<ProductViewModel> AllProducts { get; set; }
    }
}
