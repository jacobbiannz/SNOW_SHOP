using SNOW.SHOP.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class PaymentType : AuditableEntity<PaymentType>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Company Company { get; set; }
    }
}
