using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<PromotionProduct> AllPromotionProducts { get; set; }

        public virtual ICollection<Inventory> AllInventories { get; set; }

        public virtual ICollection<ImageInfo> AllImageInfos { get; set; }

        public virtual ICollection<OrderDetail> AllOrderDetails { get; set; }
    }
}
