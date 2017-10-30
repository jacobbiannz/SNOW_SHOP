using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.API.ViewModel
{
    public class CategoryViewModel
    {
        public int ID { get; set; }

        public String Name { get; set; }

        [IgnoreDataMember]
        public CompanyViewModel Company { get; set; }

        [IgnoreDataMember]
        public ICollection<KeyValuePair<string, string>> AllProducts { get; set; }
    }
}
