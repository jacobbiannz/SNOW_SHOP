using Microsoft.EntityFrameworkCore;
using SNOW.SHOP.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOW.SHOP.API.Data
{
    public class SnowShopAPIRepository : ISnowShopAPIRepository
    {
        private readonly SnowShopAPIDbContext DbContext;
        private Boolean Disposed;

        public SnowShopAPIRepository(SnowShopAPIDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }

        public IQueryable<Product> GetProducts(Int32 pageSize, Int32 pageNumber, String name)
        {
            var query = DbContext.Set<Product>().Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (!String.IsNullOrEmpty(name))
            {
                query = query.Where(item => item.Name.ToLower().Contains(name.ToLower()));
            }

            return query;
        }

        public Task<Product> GetProductAsync(Product entity)
        {
            return DbContext.Set<Product>().FirstOrDefaultAsync(item => item.Id == entity.Id);
        }

        public async Task<Product> AddProductAsync(Product entity)
        {
            entity.Name = entity.Name;
            entity.Description = entity.Description;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "user";


            DbContext.Set<Product>().Add(entity);

            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> UpdateProductAsync(Product changes)
        {
            var entity = await GetProductAsync(changes);

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Description = changes.Description;

                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = "user";

                await DbContext.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<Product> DeleteProductAsync(Product changes)
        {
            var entity = await GetProductAsync(changes);

            if (entity != null)
            {
                DbContext.Set<Product>().Remove(entity);

                await DbContext.SaveChangesAsync();
            }

            return entity;
        }
    }
}
