using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class PromotionOrder : Entity
    {
        public Promotion Promotion { get; set; }
        public Order Order { get; set; }
    }
}
