using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Store : Entity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public Company Company { get; set; }
        public ICollection<Inventory> AllInventories { get; set; }

       
        public ICollection<Order> AllOrders { get; set; }
    }
}
