using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class OrderStatus : Entity
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public Company Company { get; set; }

        public ICollection<Order> AllOrders { get; set; }
    }
}
