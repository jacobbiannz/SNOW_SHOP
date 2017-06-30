using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.API.ViewModel
{
    public class BrandViewModel
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public CompanyViewModel Company { get; set; }

        public ICollection<ProductViewModel> AllProducts { get; set; }
    }
}
