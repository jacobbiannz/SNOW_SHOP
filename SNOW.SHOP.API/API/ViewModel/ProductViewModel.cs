using System;

namespace SNOW.SHOP.API.API.ViewModels
{
    public class ProductViewModel
    {
        public Int32? ID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public decimal StockPrice { get; set; }

        public decimal MarketPrice { get; set; }
    }
}
