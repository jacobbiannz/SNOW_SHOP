using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Category : AuditableEntity<Category>
    {
        public string Name { get; set; }

        public Company Company { get; set; }

        public ICollection<Product> AllProducts { get; set; }

        public ICollection<Size> AllSizes { get; set; }
    }
}
