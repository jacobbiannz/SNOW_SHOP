using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class OrderDetail : AuditableEntity<OrderDetail>
    {
        public int Quality { get; set; }
    
        public Decimal Price { get; set; }
        public Order Order { get; set; }
        public Size Size { get; set; }
        public Product Product { get; set; }
    }
}
