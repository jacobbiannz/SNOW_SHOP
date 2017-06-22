using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Company : AuditableEntity<Company>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public virtual ICollection<User> AllStores { get; set; }

        public virtual ICollection<Product> AllProducts { get; set; }

        public virtual ICollection<Promotion> AllPromotions { get; set; }
        public virtual ICollection<Brand> AllBrands { get; set; }

        public virtual ICollection<Category> AllCategories { get; set; }

        public virtual ICollection<OrderStatus> AllOrderStatus { get; set; }

        public virtual ICollection<PaymentType> AllPaymentTypes { get; set; }

        public virtual ICollection<User> AllUsers { get; set; }

        public virtual ICollection<Customer> AllCustomers { get; set; }
    }
}
