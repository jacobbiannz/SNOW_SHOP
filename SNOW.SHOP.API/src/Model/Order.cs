using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.src.Model
{
    public class Order : Entity
    {
        public DateTime DT { get; set; }

        public Decimal TotalAmount { get; set; }

       public Decimal PromotionAmount { get; set; }

       public Customer Customer { get; set; }

       public OrderStatus OrderStatus { get; set; }

        public User Store { get; set; }
        public ICollection<PromotionOrder> AllPromotionOrders { get; set; }

        public ICollection<OrderDetail> AllOrderDetails { get; set; }

        public ICollection<Receipt> AllReceipts { get; set; }
    }
}
