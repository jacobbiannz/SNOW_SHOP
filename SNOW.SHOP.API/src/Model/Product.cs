using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SNOW.SHOP.API.src.Model
{
    public class Product : AuditableEntity<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal StockPrice { get; set; }

        public decimal MarketPrice { get; set; }

        public int ClickCount { get; set; }

        public Company Company { get; set; }
        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public ICollection<PromotionProduct> AllPromotionProducts { get; set; }

        public ICollection<Inventory> AllInventories { get; set; }

        public ICollection<ImageInfo> AllImageInfos { get; set; }

        public ICollection<OrderDetail> AllOrderDetails { get; set; }
    }
}
