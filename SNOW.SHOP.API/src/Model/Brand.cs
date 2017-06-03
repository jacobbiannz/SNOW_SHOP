using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Brand : AuditableEntity<Brand>
    {
        public string Name { get; set; }

        public Company Company { get; set; }

        public ICollection<Product> AllProducts { get; set; }
    }
}
