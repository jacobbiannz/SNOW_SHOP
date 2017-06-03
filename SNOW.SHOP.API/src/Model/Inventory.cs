using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Inventory : AuditableEntity<Inventory>
    {
        public int Quality { get; set; }
        public Store Store { get; set; }

        public Product Product { get; set; }

        public Size Size { get; set; }
    }
}
