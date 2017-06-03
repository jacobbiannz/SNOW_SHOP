using SNOW.SHOP.API.src.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.Data
{
    public interface ISnowShopAPIRepository : IDisposable
    {
        IQueryable<Product> GetProducts(Int32 pageSize, Int32 pageNumber, String name);

        Task<Product> GetProductAsync(Product entity);

        Task<Product> AddProductAsync(Product entity);

        Task<Product> UpdateProductAsync(Product changes);

        Task<Product> DeleteProductAsync(Product changes);

        IQueryable<Category> GetCategories(Int32 pageSize, Int32 pageNumber, String name);

        Task<Category> GetCategoryAsync(Category entity);

        Task<Category> AddCategoryAsync(Category entity);

        Task<Category> UpdateCategoryAsync(Category changes);

        Task<Category> DeleteCategoryAsync(Category changes);
    }
}
