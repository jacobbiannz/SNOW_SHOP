using SNOW.SHOP.API.API.ViewModel;
using System;
using System.Collections.Generic;

namespace SNOW.SHOP.API.API.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public decimal StockPrice { get; set; }

        public decimal MarketPrice { get; set; }

        public KeyValuePair<String, String> CompanyInfo { get; set; }

        public KeyValuePair<String, String> CategoryInfo { get; set; }

        public KeyValuePair<String, String> BrandInfo { get; set; }

    }
}
