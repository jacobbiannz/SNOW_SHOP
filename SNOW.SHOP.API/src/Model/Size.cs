using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Size : AuditableEntity<Size>
    {
        public string Name { get; set; }

        public Category Category { get; set; }

        public ICollection<Inventory> AllInventories { get; set; }

        public ICollection<OrderDetail> AllOrderDetails { get; set; }
    }
}
