using SNOW.SHOP.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class PromotionOrder :  AuditableEntity<PromotionOrder>
    {
        public Promotion Promotion { get; set; }
        public Order Order { get; set; }
    }
}
