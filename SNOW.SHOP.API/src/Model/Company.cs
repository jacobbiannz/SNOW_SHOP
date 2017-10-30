using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public  ICollection<User> AllStores { get; set; }

        public  ICollection<Product> AllProducts { get; set; }

        public  ICollection<Promotion> AllPromotions { get; set; }
        public  ICollection<Brand> AllBrands { get; set; }

        public  ICollection<Category> AllCategories { get; set; }

        public  ICollection<OrderStatus> AllOrderStatus { get; set; }

        public  ICollection<PaymentType> AllPaymentTypes { get; set; }

        public  ICollection<User> AllUsers { get; set; }

        public  ICollection<Customer> AllCustomers { get; set; }
    }
}
