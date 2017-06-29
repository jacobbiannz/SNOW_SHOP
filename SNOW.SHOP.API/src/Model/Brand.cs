using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Brand : Entity
    {
        public string Name { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Product> AllProducts { get; set; }
    }
}
