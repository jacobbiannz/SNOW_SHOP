using SNOW.SHOP.API.Data;
using SNOW.SHOP.API.src.Model;
using System;
using System.Linq;

namespace SNOW.SHOP.API.src.Data
{
    public class DbInitializer
    {
        public static void Initialize(SnowShopAPIDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var Companies = new Company[]
            {
                new Company{Name="SNOW", CreatedDate = DateTime.Now },
                new Company{Name="A.K", CreatedDate = DateTime.Now }

            };
            foreach (Company p in Companies)
            {
                context.Companies.Add(p);
            }
            context.SaveChanges();


            var Categories = new Category[]
        {
            new Category{Name="Clothes", Company = Companies.FirstOrDefault(), CreatedDate = DateTime.Now },
            new Category{Name="Accessaries", Company = Companies.FirstOrDefault(), CreatedDate = DateTime.Now },
            new Category{Name="Computer", Company = Companies.LastOrDefault(), CreatedDate = DateTime.Now },
            new Category{Name="Shoes", Company = Companies.LastOrDefault(), CreatedDate = DateTime.Now }
            
        };


            foreach (Category p in Categories)
            {
                context.Categories.Add(p);
            }
            context.SaveChanges();

            var Products = new Product[]
            {
            new Product{Name="laptop",Description="laptop", Category= Categories.FirstOrDefault(), Company= Companies.FirstOrDefault(),
                MarketPrice =2.11M, StockPrice=3.11M,  CreatedDate = DateTime.Now },
            new Product{Name="top",Description="top", Category= Categories.FirstOrDefault(), Company= Companies.FirstOrDefault(),
                MarketPrice =2.11M, StockPrice=3.11M, CreatedDate = DateTime.Now },
            new Product{Name="t-shirt",Description="t-shirt",Category= Categories.LastOrDefault(), Company= Companies.LastOrDefault(),
                MarketPrice =2.11M, StockPrice=3.11M, CreatedDate = DateTime.Now },
            new Product{Name="jeans",Description="jeans", Category= Categories.LastOrDefault(), Company= Companies.LastOrDefault(),
                MarketPrice =2.11M, StockPrice=3.11M, CreatedDate = DateTime.Now }
            };

            foreach (Product p in Products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

         

        }

    }
}
